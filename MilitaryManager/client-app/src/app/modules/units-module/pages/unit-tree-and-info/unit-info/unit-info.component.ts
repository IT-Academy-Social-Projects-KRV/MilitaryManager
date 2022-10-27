import {Component, Input, OnInit} from '@angular/core';
import {UnitModel} from "../../../../shared/models/unit.model";
import {UnitsService} from "../../../../shared/services/api/unit.service";
import {PositionService} from "../../../../shared/services/api/position.service";
import {RankService} from "../../../../shared/services/api/rank.service";
import {DivisionsService} from "../../../../shared/services/api/division.service";
import {ProfileModel} from "../../../../shared/models/profile.model";
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

  public lastNameInput = document.querySelector('#lastNameInput');
  // public firstNameInput = document.querySelector('#firstNameInput');
  public secondNameInput = document.querySelector('#secondNameInput');

  public divisionInput = document.querySelector('#divisionInput');
  public commanderInput = document.querySelector('#commanderInput');
  public rankInput = document.querySelector('#rankInput');
  public positionInput = document.querySelector('#positionInput');

  public profile1 = document.querySelector('#profile1');

  // @ts-ignore
  public unitProfiles: ProfileModel[] = [];

  public unit: UnitModel = new UnitModel(0);
  // public unit: UnitModel = new UnitModel();

  public propName = "123";
  @Input() id: number;

  public loading: boolean = false;

  ngOnInit(): void {
    // this.unit = new UnitModel();
  }


  getSelectedUnitDataById(): void {
    // let firstNameInput = document.querySelector('#inputFirstName');
    // let nameInput = document.querySelector('#inputFirstName');
    //  let divisionNameInput = document.querySelector('#divisionNameInput');
    this.loading = true;
    this.unitsService.single.getById(this.id)
      .subscribe((u) => {
        this.unit = u;
        // this.unit.firstName = u.firstName;
        // console.log(this.unit.firstName);


        // // @ts-ignore
        // this.lastNameInput.value = this.unit.lastName;
        // // @ts-ignore
        // // this.firstNameInput.value = this.unit.firstName;
        // // @ts-ignore
        // this.secondNameInput.value = this.unit.secondName;
        //
        // // division
        // // @ts-ignore
        // this.divisionInput.value = this.unit.division.name;
        //
        // // parent
        // if (this.unit.parent == null) {
        //   // @ts-ignore
        //   this.commanderInput.value = 'Немає'
        // } else {
        //   // @ts-ignore
        //   this.commanderInput.value = this.unit.parent.lastName + ' ' + this.unit.parent.firstName + ' ' + this.unit.parent.secondName;
        // }
        //
        // // rank
        // // @ts-ignore
        // this.rankInput.value = this.unit.rank;
        //
        // // position
        // // @ts-ignore
        // this.positionInput.value = this.unit.position;
        //
        // // @ts-ignore
        // this.unitProfiles = this.unit.profiles;
        //
        // // console.log(this.unitProfiles[0])
        // // console.log('')
        //
        // for (let p of this.unitProfiles) {
        //   // console.log(p.attribute.name)
        //   console.log(p.name)
        //   console.log(p.value)
        // }
        //
        // let profiles_id = document.querySelector('#profiles_id');
        // // @ts-ignore
        // profiles_id.value = this.unitProfiles[0].name;
        //
        // let profiles_id2 = document.querySelector('#profiles_id2');
        // // @ts-ignore
        // profiles_id2.value = this.unitProfiles[0].value;


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

  profiles_id() {
    let profiles_id = document.querySelector('#profiles_id');


    // @ts-ignore
    console.log("unit info");
    // console.log(this.unit);

    // console.log(this.unitProfiles);
    // // @ts-ignore
    // console.log(this.unit.profiles);
    // @ts-ignore
    // profiles_id.value = this.unit.profiles[0].value;
  }
}
