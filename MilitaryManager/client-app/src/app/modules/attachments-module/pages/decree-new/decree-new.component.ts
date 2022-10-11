import { Component, OnInit, ViewChildren, ViewContainerRef } from '@angular/core';
import { Test1Component } from 'src/app/components/test1/test1.component';
import { ApiService } from 'src/app/shared/services/api/api.service';

@Component({
  selector: 'app-decree-new',
  templateUrl: './decree-new.component.html',
  styleUrls: ['./decree-new.component.scss']
})
export class DecreeNewComponent implements OnInit {
  
  //@ts-ignore
  templates: TemplateModel[];
  //@ts-ignore
  tabs: string[] = []
  currentTab: number = 0;
  //@ts-ignore
  @ViewChildren('tabDoc', {static : false, read : ViewContainerRef}) targets: QueryList<any>;
  //@ts-ignore
  private componentRef: ComponentRef<any>;

  constructor(public apiService: ApiService) { }

  ngOnInit(): void {
    this.apiService.templates.collection.getAll().subscribe(res => { this.templates = res })
  }  

  addNewDocument() {
    this.tabs.push('Новий документ ' + (this.tabs.length + 1));

    setTimeout(() => {
      this.currentTab = this.tabs.length
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

}
