import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {UnitsListComponent} from './pages/units-list/units-list.component';
import {UnitEditComponent} from './pages/unit-edit/unit-edit.component';
import {RouterModule} from '@angular/router';
import {PrimeNgComponentsModule} from '../primeng-components-module/primeng-components.module';
import {UnitInfoComponent} from './pages/unit-info/unit-info.component';
import {FormsModule} from "@angular/forms";

@NgModule({
  declarations: [
    UnitsListComponent,
    UnitEditComponent,
    UnitInfoComponent
  ],
  imports: [
    CommonModule,
    PrimeNgComponentsModule,
    FormsModule,
    RouterModule.forChild([
      {path: '', redirectTo: 'list', pathMatch: 'full'},
      {path: 'list', component: UnitsListComponent},
      {path: 'edit', component: UnitEditComponent},
      {path: '**', redirectTo: 'list'}
    ])
  ]
})
export class UnitsModule {
}
