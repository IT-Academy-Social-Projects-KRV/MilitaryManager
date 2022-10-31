import {Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges} from '@angular/core';
import {UnitModel} from "../../../../shared/models/unit.model";
import {UnitsService} from "../../../../shared/services/api/unit.service";

import {
  logExperimentalWarnings
} from "@angular-devkit/build-angular/src/builders/browser-esbuild/experimental-warnings";


@Component({
  selector: 'app-unit-info',
  templateUrl: './unit-info.component.html',
  styleUrls: ['./unit-info.component.scss']
})
export class UnitInfoComponent implements OnInit, OnChanges {

  @Input() idChild1: number;

  unit: UnitModel = new UnitModel();
  parentFullName: string = "";
  divisionName: string = "";

  constructor(private unitsService: UnitsService) {
  }

  ngOnInit(): void {
    console.log('onInit');
  }

  ngOnChanges(changes: SimpleChanges): void {
    console.log('onChanges');
    if (this.idChild1 == null) {
      console.log('this.idChild1 == null')
    }
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
      });
  }
}
