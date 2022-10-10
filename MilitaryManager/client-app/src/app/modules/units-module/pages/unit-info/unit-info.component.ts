import {Component, OnInit} from '@angular/core';
import {UnitModel} from "../../../../shared/models/unit.model";
import {UnitsService} from "../../../../shared/services/api/unit.service";
import {ClientConfigurationService} from "../../../../shared/services/core/client-configuration.service";
import {map, Observable, pipe} from "rxjs";

@Component({
  selector: 'app-unit-info',
  templateUrl: './unit-info.component.html',
  styleUrls: ['./unit-info.component.scss']
})
export class UnitInfoComponent implements OnInit {

  constructor(private unitsService: UnitsService) {
  }

  // private nameInput = document.querySelector('#inputFirstName');
  public unit: UnitModel = new UnitModel(0);

  loading: boolean = false;

  // nameInput = document.querySelector('#inputFirstName');

  ngOnInit(): void {
    this.loading = true;


    this.loading = false;
  }

  public pushTheButton(): void {
    let nameInput = document.querySelector('#inputFirstName');

    // @ts-ignore
    nameInput.value = '';

    this.unitsService.single.getById(9)
      .subscribe((u) => {
        this.unit = u;

        // @ts-ignore
        nameInput.value = this.unit.firstName;
      });
  }

  getSelectedUnitData(): void {
    console.log(this.unit.id);

    let nameInput = document.querySelector('#inputFirstName');

    // @ts-ignore
    let aaa = document.activeElement.innerHTML;
    //
    console.log(aaa)

    // @ts-ignore
    nameInput.value = '2';
    // @ts-ignore
    // this.nameInput.value = aaa;
  }

  getSelectedUnitDataById(id: number): void {

    let nameInput = document.querySelector('#inputFirstName');


    // @ts-ignore
    nameInput.value = '';

    this.unitsService.single.getById(id)
      .subscribe((u) => {
        this.unit = u;
        console.log(u.children)
        // this.unit.subUnits = u.children;

        // @ts-ignore
        nameInput.value = this.unit.firstName;
        console.log(this.unit)
        // console.log(this.unit.subUnits)
      });
  }

  allocateData(unit: UnitModel): void {
    let subUnits = document.querySelector('#subUnits');
    // @ts-ignore
    subUnits.innerHTML= "333";
  }
}
