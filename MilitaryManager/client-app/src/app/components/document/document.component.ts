import { HttpErrorResponse, HttpEventType, HttpResponse } from '@angular/common/http';
import { AfterViewChecked, AfterViewInit, Component, ComponentFactoryResolver, ComponentRef, OnInit, ViewChild, ViewChildren, ViewContainerRef } from '@angular/core';
import { FormControl } from '@angular/forms';
import { DecreeModel } from 'src/app/shared/models/decree.model';
import { TemplateModel } from 'src/app/shared/models/template.model';
import { ApiService } from 'src/app/shared/services/api/api.service';
import { Test1Component } from '../test1/test1.component';

@Component({
  selector: 'app-document',
  templateUrl: './document.component.html',
  styleUrls: ['./document.component.scss']
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
  isDownloading: boolean = false;

  //@ts-ignore
  cols: any[];

  //@ts-ignore
  @ViewChildren('tabDoc', {static : false, read : ViewContainerRef}) targets: QueryList<any>;
  //@ts-ignore
  private componentRef: ComponentRef<any>;

  constructor(public apiService: ApiService) { }

  ngOnInit(): void {
    // this.decrees = [
    //   { id: 1, _id: 1, name: 'Наказ від 04.09.2022', path: '', pathSigned: '', createdBy: 'userId', timeStamp: new Date(), templateId: 1, statusId: 1},
    //   { id: 2, _id: 2, name: 'Наказ від 05.09.2022', path: '', pathSigned: '', createdBy: 'userId', timeStamp: new Date(), templateId: 1, statusId: 1},
    //   { id: 3, _id: 3, name: 'Наказ від 06.09.2022', path: '', pathSigned: '', createdBy: 'userId', timeStamp: new Date(), templateId: 1, statusId: 1},
    //   { id: 4, _id: 4, name: 'Наказ від 07.09.2022', path: '', pathSigned: '', createdBy: 'userId', timeStamp: new Date(), templateId: 1, statusId: 1}
    // ];

    //this.apiService.decree.single.get().subscribe(res => { this.decrees = [res]; console.log(res) })
    this.apiService.decree.collection.getAll().subscribe(res => { this.decrees = res })
    this.apiService.templates.collection.getAll().subscribe(res => { this.templates = res })

    this.cols = [
      { field: 'id', header: 'Id', width: '5%' },
      { field: 'name', header: 'Name' },
      { field: 'path', header: 'Path' },
      { field: 'pathSigned', header: 'Path Signed' },
      { field: 'createdBy', header: 'Created By' },
      { field: 'timeStamp', header: 'Time Stamp', date: true, format: 'dd.MM.yyyy HH:mm' },
      { field: 'template', header: 'Template' },
      { field: 'status', header: 'Status' }
  ];
  }

  addNewDocument() {
    this.tabs.push('Новий документ ' + (this.tabs.length + 1));

    setTimeout(() => {
      this.currentTab = this.tabs.length + 1
      if(this.targets.length > 0)
      {
        const target: ViewContainerRef = this.targets.toArray()[this.tabs.length - 1];
        this.componentRef = target.createComponent(Test1Component);
      }
    }, 1)
    
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
    
    //this.http.post('https://localhost:5001/api/upload', formData, {reportProgress: true, observe: 'events'})
    this.apiService.decree.uploadSign(id, formData)
      .subscribe({
        next: (event) => {
        if (event.type === HttpEventType.UploadProgress)
        {
          //this.progress = Math.round(100 * event.loaded / event.total);
          this.isUploading = event.loaded != event.total;
        }
        /*else if (event.type === HttpEventType.Response) {
          this.message = 'Upload success.';
          this.onUploadFinished.emit(event.body);
        }*/
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

}
