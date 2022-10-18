import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DivisionListComponent } from './pages/division-list/division-list.component';
import { DivisionEditComponent } from './pages/division-edit/division-edit.component';
import { RouterModule } from '@angular/router';
import { PrimeNgComponentsModule } from '../primeng-components-module/primeng-components.module';
import { DivisionNewComponent } from './pages/division-new/division-new.component';

@NgModule({
  declarations: [
    DivisionListComponent,
    DivisionEditComponent,
    DivisionNewComponent
  ],
  imports: [
    CommonModule,
    PrimeNgComponentsModule,
    RouterModule.forChild([
        { path: '', redirectTo: 'list', pathMatch: 'full' },
        { path: 'list', component: DivisionListComponent },
        { path: 'edit', component: DivisionEditComponent },
        { path: 'new', component: DivisionNewComponent},
        { path: '**', redirectTo: 'list' }
      ])
  ]
})
export class DivisionModule { }
