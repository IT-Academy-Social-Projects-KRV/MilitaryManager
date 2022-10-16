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
import { AttributeModel } from 'src/app/shared/models/attribute.model';
import { AttributeService } from 'src/app/shared/services/api/attribute.service';
import { ProfileModel } from 'src/app/shared/models/profile.model';

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
  foot_size?: string | null = null;
  head_size?: string | null = null;
  gas_mask_size?: string | null = null;

  divisions: DivisionModel[] = [];
  positions: PositionModel[] = [];
  attributes: AttributeModel[] = [];
  profiles: ProfileModel[] = [];
  ranks: RankModel[] = [];
  uniforms: string[] = [];
  blood_types: string[] = [];

  selected_division?: DivisionModel;
  selected_position?: PositionModel;
  selected_rank?: RankModel;
  selected_uniform?: string;
  selected_blood_type?: string;

  constructor(private _unitUserService : UnitUserService,
    private _divisionsService: DivisionsService,
    private _positionService: PositionService,
    private _rankService: RankService,
    private _attributeService: AttributeService,
    private messageService: MessageService,
    private _router: Router) { }

  ngOnInit(): void {
    this._divisionsService.GetAllDivisions().subscribe((divisions)=>{this.divisions = divisions});
    this._positionService.collection.getAll().subscribe((positions)=>{this.positions = positions});
    this._rankService.collection.getAll().subscribe((ranks)=>{this.ranks = ranks});
    this._attributeService.collection.getAll().subscribe((attributes)=>{this.attributes = attributes});
    this.blood_types = ['I', 'II', 'III', 'IV'];
    this.uniforms = ["A Tacs AU", "A Tacs FG Folliage Camo", "ACU PAT",
     "3 Color Desert", "6 Color Desert", "CCE", "Marpat Desert"]
  }

  EndRegistrationBtn(){
    if (!(this.firstname == '' || this.lastname == '' || this.middlename =='' || this.selected_position == null
      || this.selected_rank == null || this.selected_division == null || this.selected_blood_type==null
      || this.selected_uniform == null || this.foot_size == '' || this.head_size == '' || this.gas_mask_size == '')) {

      this.useRedClass = false;

      this.profiles.push(new ProfileModel(0, this.attributes.filter(x=>x.name?.includes("Розмір ноги"))[0].id, 0, this.foot_size));
      this.profiles.push(new ProfileModel(0, this.attributes.filter(x=>x.name?.includes("Розмір голови"))[0].id, 0, this.head_size));
      this.profiles.push(new ProfileModel(0, this.attributes.filter(x=>x.name?.includes("Розмір протигазу"))[0].id, 0, this.gas_mask_size));
      this.profiles.push(new ProfileModel(0, this.attributes.filter(x=>x.name?.includes("Тип форми"))[0].id, 0, this.selected_uniform));
      this.profiles.push(new ProfileModel(0, this.attributes.filter(x=>x.name?.includes("Група крові"))[0].id, 0, this.selected_blood_type));
     
      this._unitUserService.single.create(
        new UnitModel(0, this.lastname, this.firstname, this.middlename, this.selected_division.id,
        this.selected_rank._id, this.selected_position._id,null, this.profiles))
        .subscribe(
        data => {
          this.messageService.add({ severity: 'success', summary: 'Дані оновлено!'});
          setTimeout(() => {this._router.navigate(['/'], { replaceUrl: true })}, 2000);
        },
        error => {
          this.messageService.add({ severity: 'error', summary: 'Помилка оновлення даних!',detail: String((error as HttpErrorResponse).error).split('\n')[0] });
          this.useRedClass = true;
        });
        this.profiles = [];
    }
    else {
      this.useRedClass = true;
    }
  }
}
