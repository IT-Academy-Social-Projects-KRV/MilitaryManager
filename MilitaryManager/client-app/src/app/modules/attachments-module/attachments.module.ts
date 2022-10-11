import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PrimeNgComponentsModule } from '../primeng-components-module/primeng-components.module';
import { RouterModule } from '@angular/router';
import { DecreeListComponent } from './pages/decree-list/decree-list.component';
import { DecreeNewComponent } from './pages/decree-new/decree-new.component';
import { DecreeAddComponent } from './pages/decree-add/decree-add.component';
import { RouterModule } from '@angular/router';
import { TableModule } from 'primeng/table';
import  {ButtonModule } from 'primeng/button';
import { DropdownModule } from 'primeng/dropdown';
import { InputTextModule } from 'primeng/inputtext';
import { FormsModule } from '@angular/forms';
import { ToastModule } from 'primeng/toast';


@NgModule({
  declarations: [
    DecreeListComponent,
    DecreeNewComponent
  
    DecreeAddComponent
  ],
  imports: [
    CommonModule,
    PrimeNgComponentsModule,
    RouterModule.forChild([
      { path: '', redirectTo: 'list', pathMatch: 'full' },
      { path: 'list', component: DecreeListComponent },
      { path: 'new', component: DecreeNewComponent },
      { path: '**', redirectTo: 'list' }
    ]),
    TableModule,
		DropdownModule,
    ButtonModule,
    InputTextModule,
    FormsModule,
    ToastModule,
    RouterModule.forChild([
      { path: 'add', component: DecreeAddComponent },
    ])
  ]
})
export class AttachmentsModule { }
