import { HttpClient, HttpErrorResponse, HttpEventType, HttpRequest, HttpResponse } from '@angular/common/http';
import { AfterViewChecked, AfterViewInit, Component, ComponentFactoryResolver, ComponentRef, OnInit, ViewChild, ViewChildren, ViewContainerRef } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DecreeModel } from 'src/app/shared/models/decree.model';
import { TemplateModel } from 'src/app/shared/models/template.model';
import { ApiService } from 'src/app/shared/services/api/api.service';
import { Test1Component } from '../test1/test1.component';

@Component({
  selector: 'app-document',
  templateUrl: './document.component.html',
  styleUrls: ['./document.component.scss'],
  providers: [ConfirmationService, MessageService]
})
export class DocumentComponent implements OnInit {

  //@ts-ignore
  decrees: DecreeModel[];
  //@ts-ignore
  decree: DecreeModel;
  //@ts-ignore
  templates: TemplateModel[];
  //@ts-ignore
  tabs: string[] = []
  currentTab: number = 0;
  isUploading: boolean = false;
  uploadingId: number = 0;
  isDownloading: boolean = false;

  //@ts-ignore
  cols: any[];

  //@ts-ignore
  @ViewChildren('tabDoc', {static : false, read : ViewContainerRef}) targets: QueryList<any>;
  //@ts-ignore
  private componentRef: ComponentRef<any>;

  constructor(public apiService: ApiService, 
              private confirmationService: ConfirmationService, 
              private messageService: MessageService,
              private router: Router) { }

  ngOnInit(): void {
    this.apiService.decree.collection.getAll().subscribe(res => { this.decrees = res })
    this.apiService.templates.collection.getAll().subscribe(res => { this.templates = res })

    this.cols = [
      //{ field: 'id', header: 'Id', width: '5%' },
      { field: 'name', header: 'Name' },
      { field: 'path', header: 'Path' },
      { field: 'pathSigned', header: 'Path Signed' },
      //{ field: 'createdBy', header: 'Created By' },
      { field: 'timeStamp', header: 'Time Stamp', date: true, format: 'dd.MM.yyyy HH:mm' },
      { field: 'template', header: 'Template' },
      { field: 'status', header: 'Status' },
      { field: 'buttons', header: '', width: '5%'}

  ];
  }

  addNewDocument() {
    this.router.navigate(['/attachments/add'], { replaceUrl: true });
    // this.tabs.push('Новий документ ' + (this.tabs.length + 1));

    // setTimeout(() => {
    //   this.currentTab = this.tabs.length + 1
    //   if(this.targets.length > 0)
    //   {
    //     const target: ViewContainerRef = this.targets.toArray()[this.tabs.length - 1];
    //     this.componentRef = target.createComponent(Test1Component);
    //   }
    // }, 1)
    
  }

  //@ts-ignore
  handleClose(e) {
    this.tabs.splice(e.index - 2, 1);
    if(this.currentTab == e.index)
      this.currentTab = e.index - 1;
  }

  //@ts-ignore
  uploadFile = (id, files) => {
    if (files.length === 0) {
      return;
    }
    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('id', id);
    formData.append('file', fileToUpload, fileToUpload.name);

    this.apiService.decree.uploadSign(id, formData)
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

  //@ts-ignore
  download = (id, filePath) => {
    this.apiService.decree.download(id).subscribe((event) => {
        if (event.type === HttpEventType.UploadProgress)
            //this.progress = Math.round((100 * event.loaded) / event.total);
          this.isDownloading = event.loaded != event.total;
        else if (event.type === HttpEventType.Response) {
            //this.message = 'Download success.';
            this.downloadFile(event, filePath);
            this.apiService.decree.collection.getAll().subscribe(res => { this.decrees = res })
        }
    });
  }

  //@ts-ignore
  downloadSigned = (id, filePath) => {
    this.apiService.decree.downloadSigned(id).subscribe((event) => {
        if (event.type === HttpEventType.UploadProgress)
            //this.progress = Math.round((100 * event.loaded) / event.total);
          this.isDownloading = event.loaded != event.total;
        else if (event.type === HttpEventType.Response) {
            //this.message = 'Download success.';
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
      //@ts-ignore
      target: event.target,
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

}
