import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {UnitModel} from "../../../../../shared/models/unit.model";
import {UnitsService} from "../../../../../shared/services/api/unit.service";

import {
  logExperimentalWarnings
} from "@angular-devkit/build-angular/src/builders/browser-esbuild/experimental-warnings";


@Component({
  selector: 'app-unit-info',
  templateUrl: './unit-info.component.html',
  styleUrls: ['./unit-info.component.scss']
})
export class UnitInfoComponent implements OnInit {

  constructor(private unitsService: UnitsService) {
  }

  @Input() idChild1: UnitModel;

  unit: UnitModel = new UnitModel(0);
  parentFullName: string = "";
  divisionName: string = "";

  ngOnInit(): void {

  }


  showLastName() {

    console.log(this.idChild1);
    // this.unitsService.single.getById(this.idChild1)
    //   .subscribe((u) => {
    //     this.unit = u;
    //
    //
    //     if (this.unit.parent != null) {
    //       this.parentFullName = `${this.unit?.parent?.lastName} ${this.unit?.parent?.firstName} ${this.unit?.parent?.secondName}`;
    //     } else {
    //       this.parentFullName = 'Немає';
    //     }
    //
    //     this.divisionName = this.unit?.division.name;
    //
    //
    //     console.log(this.unit)
    //     // console.log(this.unit.profiles[0].name);
    //     // console.log(this.unit.profiles[0].value);
    //   });
  }


}
