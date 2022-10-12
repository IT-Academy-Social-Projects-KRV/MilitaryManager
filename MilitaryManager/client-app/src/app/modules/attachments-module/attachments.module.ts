import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PrimeNgComponentsModule } from '../primeng-components-module/primeng-components.module';
import { RouterModule } from '@angular/router';
import { DecreeListComponent } from './pages/decree-list/decree-list.component';
import { DecreeNewComponent } from './pages/decree-new/decree-new.component';
import { DecreeAddComponent } from './pages/decree-add/decree-add.component';


@NgModule({
  declarations: [
    DecreeListComponent,
    DecreeNewComponent,
    DecreeAddComponent
  ],
  imports: [
    CommonModule,
    PrimeNgComponentsModule,
    RouterModule.forChild([
      { path: '', redirectTo: 'list', pathMatch: 'full' },
      { path: 'list', component: DecreeListComponent },
      { path: 'new', component: DecreeNewComponent },
      { path: 'add', component: DecreeAddComponent },
      { path: '**', redirectTo: 'list' }
    ]),
  ]
})
export class AttachmentsModule { }
