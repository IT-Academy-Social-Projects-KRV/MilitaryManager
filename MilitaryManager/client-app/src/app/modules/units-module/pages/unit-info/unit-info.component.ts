import {Component, OnInit} from '@angular/core';
import {UnitModel} from "../../../../shared/models/unit.model";
import {UnitsService} from "../../../../shared/services/api/unit.service";


@Component({
  selector: 'app-unit-info',
  templateUrl: './unit-info.component.html',
  styleUrls: ['./unit-info.component.scss']
})
export class UnitInfoComponent implements OnInit {

  constructor(private unitsService: UnitsService) {
  }

  public lastNameInput = document.querySelector('#inputLastName');
  public firstNameInput = document.querySelector('#inputFirstName');
  public secondNameInput = document.querySelector('#inputSecondName');

  public unit: UnitModel = new UnitModel(0);

  ngOnInit(): void {
  }


  getSelectedUnitDataById(id: number): void {
    // let firstNameInput = document.querySelector('#inputFirstName');
    // let nameInput = document.querySelector('#inputFirstName');


    this.unitsService.single.getById(id)
      .subscribe((u) => {
        this.unit = u;

        // @ts-ignore
        this.lastNameInput.value = this.unit.lastName;
        // @ts-ignore
        this.firstNameInput.value = this.unit.firstName;
        // @ts-ignore
        this.secondNameInput.value = this.unit.secondName;
        // @ts-ignore
        this.firstNameInput.value = this.unit.firstName;
        // @ts-ignore
        this.firstNameInput.value = this.unit.firstName;
        // @ts-ignore
        this.firstNameInput.value = this.unit.firstName;
        // @ts-ignore
        this.firstNameInput.value = this.unit.firstName;
      });
  }

  clearFields(): void {
    let lastNameInput = document.querySelector('#inputLastName');
    let firstNameInput = document.querySelector('#inputFirstName');
    let secondNameInput = document.querySelector('#inputSecondName');
    // @ts-ignore
    lastNameInput.value = '';
    // @ts-ignore
    firstNameInput.value = '';
    // @ts-ignore
    secondNameInput.value = '';
  }
}
