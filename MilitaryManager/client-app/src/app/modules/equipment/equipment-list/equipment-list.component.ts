import { Component, ComponentRef, OnInit, QueryList, ViewContainerRef } from '@angular/core';
import { EntityModel } from 'src/app/shared/models/entity.model';
import { EquipmentService } from 'src/app/shared/services/api/equipment.service';
import {FieldsetModule} from 'primeng/fieldset';
import { UnitModel } from 'src/app/shared/models/unit.model';

@Component({
  selector: 'app-equipment-list',
  templateUrl: './equipment-list.component.html',
  styleUrls: ['./equipment-list.component.scss']
})
export class EquipmentListComponent implements OnInit {
  empty : string = "немає даних"

  currentTab: number = 0;
  tabs: EntityModel[] = [];
  equipment: EntityModel[]=[]
  cols: any[] = [];
  fullNames:string[] = [];

  constructor(public equipmentService: EquipmentService) { }

  ngOnInit(): void {
    this.cols = [
      { field: 'regNum', header: 'Реєстраційний номер' },
      { field: 'soldier', header: 'Надано до' },
      { field: 'division', header: 'Частина' },
      { field: 'date', header: 'Дата видачі' },
      { field: 'buttons', header: '', width: '5%'}
    ];
    this.equipmentService.collection.getAll().subscribe(res => {this.equipment = res})
  }

  handleClose(e: any) {
    this.tabs.splice(e.index - 2, 1);
    if(this.currentTab == e.index)
      this.currentTab = e.index - 1;
  }

  showAttributesInfo(entity: EntityModel){
    this.equipmentService.single.getById(entity._id == null? 0: entity._id).subscribe(res => {
      this.tabs.push(res);
      this.fullNames[this.tabs.length] = res.warehouseman?.lastName + ' ' + res.warehouseman?.firstName + ' ' + res.warehouseman?.secondName
    })
    this.currentTab = this.tabs.length;
  }

}
