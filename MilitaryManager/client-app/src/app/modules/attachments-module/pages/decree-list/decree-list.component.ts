import { HttpErrorResponse, HttpEventType, HttpResponse } from '@angular/common/http';
import { Component, ComponentRef, OnInit, ViewChild } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { DecreeModel } from 'src/app/shared/models/decree.model';
import { ApiService } from 'src/app/shared/services/api/api.service';

@Component({
  selector: 'app-decree-list',
  templateUrl: './decree-list.component.html',
  styleUrls: ['./decree-list.component.scss']
})
export class DecreeListComponent implements OnInit {

  decrees: DecreeModel[] = [];
  decree!: DecreeModel;
  isUploading: boolean = false;
  uploadingId: number = 0;
  isDownloading: boolean = false;

  cols: any[] = [];
  statuses: any[] = [];

  @ViewChild('dt') 
  table!: Table;
  private componentRef!: ComponentRef<any>;

  constructor(public apiService: ApiService, 
              private confirmationService: ConfirmationService, 
              private messageService: MessageService) { }

  ngOnInit(): void {
    this.apiService.decree.collection.getAll().subscribe(res => { this.decrees = res })

    this.cols = [
      { field: 'name', header: 'Назва' },
      { field: 'path', header: 'Файл' },
      { field: 'pathSigned', header: 'Файл підписаний' },
      { field: 'timeStamp', header: 'Час', date: true, format: 'dd.MM.yyyy HH:mm' },
      { field: 'template', header: 'Шаблон' },
      { field: 'status', header: 'Статус' },
      { field: 'buttons', header: '', width: '5%'}
    ];

    this.statuses = [
      { status: 'Created', name: 'Створено' },
      { status: 'Downloaded', name: 'Завантажено' },
      { status: 'Signed', name: 'Підписано' },
      { status: 'Completed', name: 'Завершено' }
    ]
  }

  uploadFile = (id: number, files: FileList | null) => {
    if (files!.length === 0) {
      return;
    }
    let fileToUpload = <File>files![0];
    const formData = new FormData();
    formData.append('id', id.toString());
    formData.append('file', fileToUpload, fileToUpload.name);

    this.apiService.pdfs.uploadSign(formData)
      .subscribe({
        next: (event) => {
        if (event.type === HttpEventType.UploadProgress)
        {
          this.uploadingId = id;
          this.isUploading = event.loaded != event.total;
        }
        else if (event.type === HttpEventType.Response) {
          this.apiService.decree.collection.getAll().subscribe(res => { this.decrees = res })
        }
      },
      error: (err: HttpErrorResponse) => console.log(err)
    });
  }

  download = (id: number, filePath: string) => {
    this.apiService.pdfs.download(id).subscribe((event) => {
        if (event.type === HttpEventType.UploadProgress)
          this.isDownloading = event.loaded != event.total;
        else if (event.type === HttpEventType.Response) {
            this.downloadFile(event, filePath);
            this.apiService.decree.collection.getAll().subscribe(res => { this.decrees = res })
        }
    });
  }

  downloadSigned = (id: number, filePath: string) => {
    this.apiService.pdfs.downloadSigned(id).subscribe((event) => {
        if (event.type === HttpEventType.UploadProgress)
          this.isDownloading = event.loaded != event.total;
        else if (event.type === HttpEventType.Response) {
            this.downloadFile(event, filePath);
        }
    });
  }

  private downloadFile = (data: HttpResponse<Blob>, filePath: String) => {
      //@ts-ignore
      const downloadedFile = new Blob([data.body], { type: data.body.type });
      const a = document.createElement('a');
      a.setAttribute('style', 'display:none;');
      document.body.appendChild(a);
      var filename = filePath.replace(/^.*[\\\/]/, '')
      a.download = filename;
      a.href = URL.createObjectURL(downloadedFile);
      a.target = '_blank';
      a.click();
      document.body.removeChild(a);
  }

  completeDecree = (event: Event, id: number) => {
    console.log("clicked on complete " + id)
    this.confirmationService.confirm({
      target: event.target as HTMLButtonElement,
      message: 'This action will change decree status to Comleted. Continue?',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.apiService.decree.completeDecree(id).subscribe(res => {
          this.messageService.add({severity:'success', summary:'Confirmed', detail:'You have completed decree'});
          this.apiService.decree.collection.getAll().subscribe(res => { this.decrees = res })
        })
      },
      reject: () => {
          this.messageService.add({severity:'error', summary:'Rejected', detail:'You have rejected'});
      }
  });
  }

  applyFilterGlobal($event: Event, stringVal: string) {
    this.table.filterGlobal(($event.target as HTMLInputElement).value, stringVal);
  }

}
