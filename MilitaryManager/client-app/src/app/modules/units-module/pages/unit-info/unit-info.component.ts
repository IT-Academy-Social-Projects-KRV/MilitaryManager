import {Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges, ViewChild} from '@angular/core';
import {UnitModel} from "../../../../shared/models/unit.model";
import {UnitsService} from "../../../../shared/services/api/unit.service";

import {
  logExperimentalWarnings
} from "@angular-devkit/build-angular/src/builders/browser-esbuild/experimental-warnings";
import { EntityModel } from 'src/app/shared/models/entity.model';
import { Table } from 'primeng/table';
import { EquipmentService } from 'src/app/shared/services/api/equipment.service';
import { UnitToEquipmentModel } from 'src/app/shared/models/unitToEquipment.model';


@Component({
  selector: 'app-unit-info',
  templateUrl: './unit-info.component.html',
  styleUrls: ['./unit-info.component.scss']
})
export class UnitInfoComponent implements OnInit, OnChanges {

  @Input() idChild1: number;

  empty : string = "немає даних"
  equipment: UnitToEquipmentModel[]=[];
  cols: any[] = [];
  @ViewChild('dt') 
  table!: Table;


  unit: UnitModel = new UnitModel();
  parentFullName: string = "";
  divisionName: string = "";
  readonly: boolean = true;

  constructor(private unitsService: UnitsService, public equipmentService: EquipmentService) {
  }

  ngOnInit(): void {
    this.cols = [
      { field: 'regNum', header: 'Реєстраційний номер' },
      { field: 'soldier', header: 'Надано ким' },
      { field: 'division', header: 'Частина' },
      { field: 'date', header: 'Дата видачі' }
    ];
    this.equipmentService.collection.getAll().subscribe(res => {this.equipment = res})
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (this.idChild1 != null) {
      this.showFullUnitInfo();
    }
  }

  showFullUnitInfo() {
    this.unitsService.single.getById(this.idChild1)
      .subscribe((u) => {
        this.unit = u;

        if (this.unit.parent != null) {
          this.parentFullName = `${this.unit.parent.lastName} ${this.unit.parent.firstName} ${this.unit.parent.secondName}`;
        } else {
          this.parentFullName = 'Немає';
        }

        this.divisionName = this.unit.division.name;

        this.equipment = this.unit.unitToEquipments
      });

  }

  edit(){
    this.readonly = false;
  }

  show(): void{
    console.log(this.unit);
    console.log(this.unit.unitToEquipments);
  }

  applyFilterGlobal($event: Event, stringVal: string) {
    this.table.filterGlobal(($event.target as HTMLInputElement).value, stringVal);
  }
}
