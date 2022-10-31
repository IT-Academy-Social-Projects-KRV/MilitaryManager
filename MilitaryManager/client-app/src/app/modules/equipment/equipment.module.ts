import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EquipmentListComponent } from './equipment-list/equipment-list.component';
import { RouterModule } from '@angular/router';
import { PrimeNgComponentsModule } from '../primeng-components-module/primeng-components.module';
import { EquipmentAddComponent } from './equipment-add/equipment-add.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    EquipmentListComponent,
    EquipmentAddComponent
  ],
  imports: [
    CommonModule,
    PrimeNgComponentsModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      { path: '', redirectTo: 'list', pathMatch: 'full' },
      { path: 'list', component: EquipmentListComponent },
      { path: 'new', component:  EquipmentAddComponent},
      { path: '**', redirectTo: 'list' }
    ])
  ]
})
export class EquipmentModule { }
