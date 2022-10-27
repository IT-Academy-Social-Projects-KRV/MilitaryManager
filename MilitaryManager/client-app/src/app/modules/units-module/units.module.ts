import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {UnitsListComponent} from './pages/unit-tree-and-info/units-list/units-list.component';
import {UnitEditComponent} from './pages/unit-edit/unit-edit.component';
import {RouterModule} from '@angular/router';
import {PrimeNgComponentsModule} from '../primeng-components-module/primeng-components.module';
import {UnitInfoComponent} from './pages/unit-tree-and-info/unit-info/unit-info.component';
import {FormsModule} from "@angular/forms";
import { UnitTreeAndInfoComponent } from './pages/unit-tree-and-info/unit-tree-and-info.component';

@NgModule({
  declarations: [
    UnitsListComponent,
    UnitEditComponent,
    UnitInfoComponent,
    UnitTreeAndInfoComponent
  ],
  imports: [
    CommonModule,
    PrimeNgComponentsModule,
    FormsModule,
    RouterModule.forChild([
      {path: '', redirectTo: 'list', pathMatch: 'full'},
      {path: 'list', component: UnitTreeAndInfoComponent},
      {path: 'edit', component: UnitEditComponent},
      {path: '**', redirectTo: 'list'}
    ])
  ]
})
export class UnitsModule {
}
