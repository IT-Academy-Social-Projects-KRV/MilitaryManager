import { Component, OnInit } from '@angular/core';
import { DivisionModel } from 'src/app/shared/models/division.model';
import { UnitUserModel } from 'src/app/shared/models/unit-user.model';
import { UnitModel } from 'src/app/shared/models/unit.model';
import { DivisionsService } from 'src/app/shared/services/api/division.service';
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

  divisions: DivisionModel[] = [];

  selected_division?: DivisionModel;

  constructor(private _unitUserService : UnitUserService, private _divisionsService: DivisionsService) { }

  ngOnInit(): void {
    this._divisionsService.GetAllDivisions().subscribe((divisions)=>{this.divisions = divisions});
  }

  EndRegistrationBtn(){
    let unit;
    unit = {
      firstName: this.firstname,
      lastName: this.lastname,
      //middlename: this.middlename,
      position: this.position,
      rank: this.rank,
      selected_division: this.selected_division?._id
    };

    this._unitUserService.single.create(unit).subscribe({});
  }
}
