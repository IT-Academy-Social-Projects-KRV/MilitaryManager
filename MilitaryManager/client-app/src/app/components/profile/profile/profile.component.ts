import { Component, OnInit } from '@angular/core';
import {UnitUserService} from "../../../shared/services/api/unit-user.service";
import {AuthService} from "../../../shared/services/auth.service";
import {UnitsService} from "../../../shared/services/api/unit.service";
import {UnitModel} from "../../../shared/models/unit.model";




@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})

export class ProfileComponent implements OnInit {

  userName: string | null | undefined = '';
  weight: number = 0;
  height: number = 0;
  rank: string | null | undefined = '';
  position: string | null | undefined = '';
  footSize: string | null | undefined = '';
  headSize: string | null | undefined = '';
  gasMaskSize: string | null | undefined = '';
  uniform: string = '';
  bloodType: string = '';
  userId: Promise<string> =  this._authService.getUserId();
  unitModel: UnitModel | undefined;

  constructor(private _unitUserService : UnitUserService, private _authService: AuthService, private _unitService: UnitsService) {
  }

  ngOnInit(): void {
    const userId = Promise.resolve(this.userId);
    userId.then((value) => {
      this._unitUserService.GetUnitUser(value)
        .subscribe(result => {
          this._unitService.single.getById(result["id"])
            .subscribe(result => {
              console.log(result)
              this.unitModel = result;
              this.userName = this.unitModel?.lastName?.concat(" " + <string>this.unitModel?.firstName + " ").concat(<string>this.unitModel?.secondName);
              // @ts-ignore
              this.height = this.unitModel?.profiles["6"].value
              // @ts-ignore
              this.weight = this.unitModel?.profiles["5"].value
              this.rank = this.unitModel?.rank
              this.position = this.unitModel?.position
              // @ts-ignore
              this.footSize = this.unitModel?.profiles["0"].value
              // @ts-ignore
              this.headSize = this.unitModel?.profiles["1"].value
              // @ts-ignore
              this.gasMaskSize = this.unitModel?.profiles["2"].value
              // @ts-ignore
              this.uniform = this.unitModel?.profiles["3"].value
              // @ts-ignore
              this.bloodType = this.unitModel?.profiles["4"].value
            })
        })
    })
  }
}
