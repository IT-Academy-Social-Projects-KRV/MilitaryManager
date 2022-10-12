import { Component, OnInit } from '@angular/core';
import { DivisionModel } from 'src/app/shared/models/division.model';
import { PositionModel } from 'src/app/shared/models/position.model';
import { RankModel } from 'src/app/shared/models/rank.model';
import { DivisionsService } from 'src/app/shared/services/api/division.service';
import { UnitUserService } from 'src/app/shared/services/api/unit-user.service';
import { PositionService } from 'src/app/shared/services/api/position.service';
import { RankService } from 'src/app/shared/services/api/rank.service';
import { MessageService } from 'primeng/api';
import { HttpErrorResponse } from '@angular/common/http';
import { UnitModel } from 'src/app/shared/models/unit.model';

@Component({
  selector: 'app-finish-registration',
  templateUrl: './finish-registration.component.html',
  styleUrls: ['./finish-registration.component.scss']
})
export class FinishRegistrationComponent implements OnInit {

  useRedClass: boolean = false;
  firstname: string | null = null;
  lastname: string | null = null;
  middlename?: string | null = null;

  divisions: DivisionModel[] = [];
  positions: PositionModel[] = [];
  ranks: RankModel[] = [];

  selected_division?: DivisionModel;
  selected_position?: PositionModel;
  selected_rank?: RankModel;

  constructor(private _unitUserService : UnitUserService,
    private _divisionsService: DivisionsService,
    private _positionService: PositionService,
    private _rankService: RankService,
    private messageService: MessageService) { }

  ngOnInit(): void {
    console.log(this._divisionsService.GetAllDivisions())
    this._divisionsService.GetAllDivisions().subscribe((divisions)=>{this.divisions = divisions});
    this._positionService.collection.getAll().subscribe((positions)=>{this.positions = positions});
    this._rankService.collection.getAll().subscribe((ranks)=>{this.ranks = ranks});
  }

  EndRegistrationBtn(){
    if (!(this.firstname == '' || this.lastname == '' || this.selected_position == null
      || this.selected_rank == null || this.selected_division == null)) {

      this.useRedClass = false;
      // unit = {
      //   firstName: this.firstname,
      //   lastName: this.lastname,
      //   //middlename: this.middlename,
      //   positionId: this.selected_position?.id,
      //   rankId: this.selected_rank?.id,
      //   divisionId: this.selected_division?._id
      // };
      this._unitUserService.single.create(
        new UnitModel(0, this.lastname, this.firstname, this.middlename, this.selected_division.id,
        this.selected_rank._id, this.selected_position._id,null))
        .subscribe(
        data => this.messageService.add({ severity: 'success', summary: 'Дані оновлено!'}),
        error => {
          this.messageService.add({ severity: 'error', summary: 'Командира не створено!', detail: String((error as HttpErrorResponse).error)});
          this.useRedClass = true;
        });
    }
    else {
      this.useRedClass = true;
    }
  }
}
