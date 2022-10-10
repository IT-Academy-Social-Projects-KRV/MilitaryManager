import { Component, OnInit } from '@angular/core';
import { UnitUserModel } from 'src/app/shared/models/unit-user.model';
import { UnitModel } from 'src/app/shared/models/unit.model';
import { UnitUserService } from 'src/app/shared/services/api/unit-user.service.service';

@Component({
  selector: 'app-finish-registration',
  templateUrl: './finish-registration.component.html',
  styleUrls: ['./finish-registration.component.scss']
})
export class FinishRegistrationComponent implements OnInit {

  firstname?: string;
  lastname?: string;
  middlename?: string;
  position?: string;
  rank?: string;

  divisions: string[] = [
    'division1',
    'division2',
    'division3'
  ];

  selected_division?: string;

  constructor(private _unitUserService : UnitUserService) { }

  ngOnInit(): void {
  }

  EndRegistrationBtn(){
    let unit, user;
    unit = {
      firstname: this.firstname,
      lastname: this.lastname,
      middlename: this.middlename,
      position: this.position,
      rank: this.rank,
      selected_division: this.selected_division
    };

    this._unitUserService.single.create(unit).subscribe({});
  }
}
