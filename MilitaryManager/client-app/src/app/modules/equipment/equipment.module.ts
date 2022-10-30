import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EquipmentListComponent } from './equipment-list/equipment-list.component';
import { RouterModule } from '@angular/router';
import { PrimeNgComponentsModule } from '../primeng-components-module/primeng-components.module';


@NgModule({
  declarations: [
    EquipmentListComponent
  ],
  imports: [
    CommonModule,
    PrimeNgComponentsModule,
    RouterModule.forChild([
      { path: '', redirectTo: 'list', pathMatch: 'full' },
      { path: 'list', component: EquipmentListComponent },
      //{ path: 'new', component:  },
      { path: '**', redirectTo: 'list' }
    ])
  ]
})
export class EquipmentModule { }
