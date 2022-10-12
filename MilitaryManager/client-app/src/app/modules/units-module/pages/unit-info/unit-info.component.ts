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

  constructor(private unitsService: UnitsService,
              private positionService: PositionService,
              private rankService: RankService,
              private divisionsService: DivisionsService
              ) {
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

        console.log('clearFields() begin');
        console.log(this.unit.id);
        // console.log(this.unit.firstName);
        // console.log(this.unit.rankId);;
        // console.log();
        // console.log('');
        //
        // console.log(this.unit.divisionId);
        // console.log(this.unit.positionId);


        console.log(this.unit.division);
        console.log(this.unit.rank);
        console.log(this.unit.position);
        console.log(this.unit.parent)


        console.log(this.unit.profiles);
        console.log(this.unit.unitToEquipments);

        console.log('clearFields() end');
        console.log('');
      });
  }

  clearFields(): void {


    // let lastNameInput = document.querySelector('#inputLastName');
    // let firstNameInput = document.querySelector('#inputFirstName');
    // let secondNameInput = document.querySelector('#inputSecondName');
    // // @ts-ignore
    // lastNameInput.value = '';
    // // @ts-ignore
    // firstNameInput.value = '';
    // // @ts-ignore
    // secondNameInput.value = '';
  }
}
