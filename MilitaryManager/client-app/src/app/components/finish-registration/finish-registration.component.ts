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
import { delay, timeout } from 'rxjs';
import { Router } from '@angular/router';
import { AttributeModel } from 'src/app/shared/models/attribute.model';
import { AttributeService } from 'src/app/shared/services/api/attribute.service';
import { ProfileModel } from 'src/app/shared/models/profile.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UnitModel } from 'src/app/shared/models/unit.model';

@Component({
  selector: 'app-finish-registration',
  templateUrl: './finish-registration.component.html',
  styleUrls: ['./finish-registration.component.scss']
})
export class FinishRegistrationComponent implements OnInit {

  useRedClass: boolean = false;

  commanderForm: FormGroup = this._fb.group({
    firstName: ["", Validators.required],
    lastName: ["", Validators.required],
    secondName: ["", Validators.required],
    divisionId: [0, Validators.required],
    positionId: [0, Validators.required],
    rankId: [0, Validators.required],
    footSize: ["", Validators.required],
    headSize: ["", Validators.required],
    gasMaskSize: ["", Validators.required],
    uniform: ["", Validators.required],
    bloodType: ["", Validators.required],
    weight: ["", Validators.required],
    height: ["", Validators.required]
  })

  divisions: DivisionModel[] = [];
  positions: PositionModel[] = [];
  attributes: AttributeModel[] = [];
  ranks: RankModel[] = [];
  uniforms: string[] = [];
  blood_types: string[] = [];

  constructor(private _unitUserService : UnitUserService,
    private _divisionsService: DivisionsService,
    private _positionService: PositionService,
    private _rankService: RankService,
    private _attributeService: AttributeService,
    private messageService: MessageService,
    private _router: Router,
    private _fb: FormBuilder) { }

  ngOnInit(): void {
    this._divisionsService.GetAllDivisions().subscribe((divisions)=>{this.divisions = divisions});
    this._positionService.collection.getAll().subscribe((positions)=>{this.positions = positions});
    this._rankService.collection.getAll().subscribe((ranks)=>{this.ranks = ranks});
    this._attributeService.collection.getAll().subscribe((attributes)=>
    {
      this.attributes = attributes
      this._attributeService.GetAttributeValues(this.attributes.filter(x=>x.name?.includes("Група крові"))[0].id).subscribe((blood_types) => {this.blood_types = blood_types});
      this._attributeService.GetAttributeValues(this.attributes.filter(x=>x.name?.includes("Тип форми"))[0].id).subscribe((uniforms) => {this.uniforms = uniforms});
    });
  }

  EndRegistrationBtn(){
      if(this.commanderForm.valid){

      let newUnit: UnitModel = this.commanderForm.value;
      newUnit.profiles = [];

      newUnit.profiles.push(new ProfileModel(0, this.attributes.find(x => x.name=="Розмір ноги")?.id, 0, this.commanderForm.get("footSize")?.value, null));
      newUnit.profiles.push(new ProfileModel(0, this.attributes.find(x => x.name=="Розмір голови")?.id, 0, this.commanderForm.get("headSize")?.value, null));
      newUnit.profiles.push(new ProfileModel(0, this.attributes.find(x => x.name=="Розмір протигазу")?.id, 0, this.commanderForm.get("gasMaskSize")?.value, null));
      newUnit.profiles.push(new ProfileModel(0, this.attributes.find(x => x.name=="Тип форми")?.id, 0, this.commanderForm.get("uniform")?.value, null));
      newUnit.profiles.push(new ProfileModel(0, this.attributes.find(x => x.name=="Група крові")?.id, 0, this.commanderForm.get("bloodType")?.value, null));
      newUnit.profiles.push(new ProfileModel(0, this.attributes.find(x => x.name=="Вага")?.id, 0, this.commanderForm.get("weight")?.value, null));
      newUnit.profiles.push(new ProfileModel(0, this.attributes.find(x => x.name=="Зріст")?.id, 0, this.commanderForm.get("height")?.value, null));

      this._unitUserService.single.create(newUnit)
        .subscribe(
        data => {
          this.messageService.add({ severity: 'success', summary: 'Дані оновлено!'});
          setTimeout(() => {this._router.navigate(['/'], { replaceUrl: true })}, 2000);
        },
        error => {
          this.messageService.add({ severity: 'error', summary: 'Помилка оновлення даних!',detail: String((error as HttpErrorResponse).error).split('\n')[0] });
        });
    }
  }
}
