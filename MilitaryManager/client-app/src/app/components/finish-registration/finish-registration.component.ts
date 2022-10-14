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
import { delay, timeout } from 'rxjs';
import { Router } from '@angular/router';

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
    private messageService: MessageService,
    private _router: Router) { }

  ngOnInit(): void {
    this._divisionsService.GetAllDivisions().subscribe((divisions)=>{this.divisions = divisions});
    this._positionService.collection.getAll().subscribe((positions)=>{this.positions = positions});
    this._rankService.collection.getAll().subscribe((ranks)=>{this.ranks = ranks});
  }

  EndRegistrationBtn(){
    if (!(this.firstname == '' || this.lastname == '' || this.middlename =='' || this.selected_position == null
      || this.selected_rank == null || this.selected_division == null)) {

      this.useRedClass = false;

      this._unitUserService.single.create(
        new UnitModel(0, this.lastname, this.firstname, this.middlename, this.selected_division.id,
        this.selected_rank._id, this.selected_position._id,null))
        .subscribe(
        data => {
          this.messageService.add({ severity: 'success', summary: 'Дані оновлено!'});
          setTimeout(() => {this._router.navigate(['/'], { replaceUrl: true })}, 2000);
        },
        error => {
          this.messageService.add({ severity: 'error', summary: 'Помилка оновлення даних!',detail: String((error as HttpErrorResponse).error).split('\n')[0] });
          this.useRedClass = true;
        });
    }
    else {
      this.useRedClass = true;
    }
  }
}
