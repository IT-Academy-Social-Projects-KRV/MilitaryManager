import {Component, OnInit} from '@angular/core';
import {UnitModel} from "../../../../shared/models/unit.model";
import {UnitsService} from "../../../../shared/services/api/unit.service";
import {PositionService} from "../../../../shared/services/api/position.service";
import {RankService} from "../../../../shared/services/api/rank.service";
import {DivisionsService} from "../../../../shared/services/api/division.service";


@Component({
  selector: 'app-unit-info',
  templateUrl: './unit-info.component.html',
  styleUrls: ['./unit-info.component.scss']
})
export class UnitInfoComponent implements OnInit {

  constructor(private unitsService: UnitsService) {
  }

  public lastNameInput = document.querySelector('#lastNameInput');
  public firstNameInput = document.querySelector('#firstNameInput');
  public secondNameInput = document.querySelector('#secondNameInput');

  public divisionInput = document.querySelector('#divisionInput');
  public commanderInput = document.querySelector('#commanderInput');
  public rankInput = document.querySelector('#rankInput');
  public positionInput = document.querySelector('#positionInput');


  public unit: UnitModel = new UnitModel(0);

  ngOnInit(): void {
  }


  getSelectedUnitDataById(id: number): void {
    // let firstNameInput = document.querySelector('#inputFirstName');
    // let nameInput = document.querySelector('#inputFirstName');
    //  let divisionNameInput = document.querySelector('#divisionNameInput');

    this.unitsService.single.getById(id)
      .subscribe((u) => {
        this.unit = u;

        console.log(this.unit)
        console.log(this.unit.profiles)
        console.log(this.unit.unitToEquipments)

        // @ts-ignore
        this.lastNameInput.value = this.unit.lastName;
        // @ts-ignore
        this.firstNameInput.value = this.unit.firstName;
        // @ts-ignore
        this.secondNameInput.value = this.unit.secondName;

        // division
        // @ts-ignore
        this.divisionInput.value = this.unit.division.name;

        // parent
        if (this.unit.parent == null) {
          // @ts-ignore
          this.commanderInput.value = 'Немає'
        } else {
          // @ts-ignore
          this.commanderInput.value = this.unit.parent.lastName + ' ' + this.unit.parent.firstName + ' ' + this.unit.parent.secondName;
        }

        // rank
        // @ts-ignore
        this.rankInput.value = this.unit.rank;

        // position
        // @ts-ignore
        this.positionInput.value = this.unit.position;
      });
  }

  clearFields(): void {
    let lastNameInput = document.querySelector('#lastNameInput');
    let firstNameInput = document.querySelector('#firstNameInput');
    let secondNameInput = document.querySelector('#secondNameInput');
    let divisionInput = document.querySelector('#divisionInput');
    let commanderInput = document.querySelector('#commanderInput');
    let rankInput = document.querySelector('#rankInput');
    let positionInput = document.querySelector('#positionInput');

    // @ts-ignore
    lastNameInput.value = '';
    // @ts-ignore
    firstNameInput.value = '';
    // @ts-ignore
    secondNameInput.value = '';

    // @ts-ignore
    divisionInput.value = '';
    // @ts-ignore
    commanderInput.value = '';
    // @ts-ignore
    rankInput.value = '';
    // @ts-ignore
    positionInput.value = '';
  }
}
