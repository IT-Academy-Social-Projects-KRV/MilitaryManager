import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
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
    DecreeAddComponent
  ],
  imports: [
    CommonModule,
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
