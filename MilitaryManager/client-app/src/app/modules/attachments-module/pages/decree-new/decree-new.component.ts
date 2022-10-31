import { Component, ComponentRef, OnInit, QueryList, ViewChildren, ViewContainerRef } from '@angular/core';
import { TemplateModel } from 'src/app/shared/models/template.model';
import { ApiService } from 'src/app/shared/services/api/api.service';
import { DecreeAddComponent } from '../decree-add/decree-add.component';
import { TransferComponent } from '../templates/transfer/transfer.component';

@Component({
  selector: 'app-decree-new',
  templateUrl: './decree-new.component.html',
  styleUrls: ['./decree-new.component.scss']
})
export class DecreeNewComponent implements OnInit {
  
  templates: TemplateModel[] = [];
  tabs: string[] = []
  currentTab: number = 0;
  @ViewChildren('tabDoc', { read: ViewContainerRef })
  targets!: QueryList<any>;
  private componentRef!: ComponentRef<any>;

  constructor(public apiService: ApiService) { }

  ngOnInit(): void {
    this.apiService.templates.collection.getAll().subscribe(res => { this.templates = res })
  }  

  addNewDocument(id: number | null, type: string | null) {
    this.tabs.push('Новий документ ' + (this.tabs.length + 1));

    setTimeout(() => {
      this.currentTab = this.tabs.length
      if(this.targets.length > 0)
      {
        const target: ViewContainerRef = this.targets.toArray()[this.tabs.length - 1];
        switch(id) {
          case 3: {
            this.componentRef = target.createComponent(TransferComponent);
            this.componentRef.instance.templateId=id;
            break;
          }
          default: {
            this.componentRef = target.createComponent(DecreeAddComponent);
            this.componentRef.instance.templateId=id;
            this.componentRef.instance.templateType=type;
          }
        }
      }
    }, 1)    
  }

  handleClose(e: any) {
    this.tabs.splice(e.index - 2, 1);
    if(this.currentTab == e.index)
      this.currentTab = e.index - 1;
  }

}
