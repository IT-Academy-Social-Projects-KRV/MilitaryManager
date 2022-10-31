import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UnitsListComponent } from './pages/units-list/units-list.component';
import { UnitEditComponent } from './pages/unit-edit/unit-edit.component';
import { RouterModule } from '@angular/router';
import { PrimeNgComponentsModule } from '../primeng-components-module/primeng-components.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {UnitInfoComponent} from './pages/unit-info/unit-info.component';
import { UnitTreeAndInfoComponent } from './pages/unit-tree-and-info/unit-tree-and-info.component';
import { UnitAddComponent } from './pages/unit-add/unit-add.component';

@NgModule({
  declarations: [
    UnitsListComponent,
    UnitEditComponent,
    UnitInfoComponent,
    UnitTreeAndInfoComponent,
    UnitAddComponent
  ],
  imports: [
    CommonModule,
    PrimeNgComponentsModule,
    FormsModule, 
    ReactiveFormsModule,
    RouterModule.forChild([
      {path: '', redirectTo: 'list', pathMatch: 'full'},
      {path: 'list', component: UnitTreeAndInfoComponent},
      {path: 'edit', component: UnitEditComponent},
      { path: 'add', component: UnitAddComponent },
      {path: '**', redirectTo: 'list'}
    ])
  ]
})
export class UnitsModule {
}
