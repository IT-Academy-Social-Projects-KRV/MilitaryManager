import { Component, OnInit } from '@angular/core';
import {UnitUserService} from "../../../shared/services/api/unit-user.service";
import {AuthService} from "../../../shared/services/auth.service";
import {UnitsService} from "../../../shared/services/api/unit.service";
import {UnitModel} from "../../../shared/models/unit.model";
import {Router} from "@angular/router";

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})

export class ProfileComponent implements OnInit {

  userName: string | null | undefined = '';
  rank: string | null | undefined = '';
  position: string | null | undefined = '';
  unitModel: UnitModel;

  constructor(private _unitUserService : UnitUserService,
              private _authService: AuthService,
              private _unitService: UnitsService,
              private _router: Router) {
  }

  ngOnInit(): void {
    const userId = this._authService.getUserId();
    userId.then((value) => {
      this._unitUserService.GetUnitUser(value)
        .subscribe(result => {
          this._unitService.single.getById(result["id"])
            .subscribe(result => {
              this.unitModel = result;
              this.userName = this.unitModel?.lastName?.concat(" " + <string>this.unitModel?.firstName + " ").concat(<string>this.unitModel?.secondName);
              this.rank = this.unitModel?.rank
              this.position = this.unitModel?.position
            })
        })
    })
  }
  navigateToUpdate() {
    this._router.navigate(["/updateProfile"])
  }
}
