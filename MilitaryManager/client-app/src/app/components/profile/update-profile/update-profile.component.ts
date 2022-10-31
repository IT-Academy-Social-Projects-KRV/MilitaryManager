import { Component, OnInit } from '@angular/core';
import {PositionModel} from "../../../shared/models/position.model";
import {AttributeModel} from "../../../shared/models/attribute.model";
import {RankModel} from "../../../shared/models/rank.model";
import {Router} from "@angular/router";
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {UnitModel} from "../../../shared/models/unit.model";
import {ProfileModel} from "../../../shared/models/profile.model";
import {HttpErrorResponse} from "@angular/common/http";
import {MessageService} from "primeng/api";
import {ApiService} from "../../../shared/services/api/api.service";

export enum AttributesName
{
  FootSize,
  HeadSize,
  GasMaskSize,
  Uniform,
  BloodType,
  Weight,
  Height
}
@Component({
  selector: 'app-update-profile',
  templateUrl: './update-profile.component.html',
  styleUrls: ['./update-profile.component.scss']
})
export class UpdateProfileComponent implements OnInit {

  pos: PositionModel[] = [];
  attributes: AttributeModel[] = [];
  ranks: RankModel[] = [];
  uniforms: string[] = [];
  blood_types: string[] = [];

  unitModel: UnitModel;
    readonly weightValueValidator = (control: FormControl) => {

      if(control.value < 40 || control.value > 150) {
        return {weightValueValidator: 'Невірно введені дані, спробуйте від 40 до 150 включно'}
      }
      return null
    }
    readonly heightValueValidator = (control: FormControl) => {
      if(control.value < 150 || control.value > 250) {
        return {heightValueValidator: 'Невірно введені дані, спробуйте від 150 до 250 включно'}
      }
      return null
    }
    readonly footSizeValueValidator = (control: FormControl) => {
      if(control.value < 38 || control.value > 47) {
        return {footSizeValueValidator: 'Невірно введені дані, спробуйте від 38 до 47 включно'}
      }
      return null
    }
    readonly headSizeValueValidator = (control: FormControl) => {
      if(control.value < 54 || control.value > 64) {
        return {headSizeValueValidator: 'Невірно введені дані, спробуйте від 54 до 64 включно'}
      }
      return null
    }
    readonly gasMaskSizeValueValidator = (control: FormControl) => {
      if(control.value < 0 || control.value > 4) {
        return {gasMaskSizeValidator: 'Невірно введені дані, спробуйте від 0 до 4 включно'}
      }
      return null
    }

  updateProfileForm: FormGroup = this._formBuilder.group({
    LastName: ['', Validators.required],
    FirstName: ['', Validators.required],
    SecondName: ['', Validators.required],
    Rank: ['', Validators.required],
    Position: ['', Validators.required],
    FootSize: ['', [Validators.required, this.footSizeValueValidator]],
    HeadSize: ['', [Validators.required, this.headSizeValueValidator]],
    GasMaskSize: ['', [Validators.required, this.gasMaskSizeValueValidator]],
    Uniform: ['', Validators.required],
    BloodType: ['', Validators.required],
    Weight: ['', [Validators.required, this.weightValueValidator]],
    Height: ['', [Validators.required, this.heightValueValidator]]
  })

  constructor(
              private _router: Router,
              private _formBuilder: FormBuilder,
              private _messageService: MessageService,
              private _apiService: ApiService) { }

  ngOnInit(): void {
    this._apiService.positions.collection.getAll().subscribe(pos => {this.pos = pos})
    this._apiService.ranks.collection.getAll().subscribe(ranks => {this.ranks = ranks})
    this._apiService.attributes.collection.getAll().subscribe(attributes => {
      this.attributes = attributes
      this._apiService.attributes.GetAttributeValues(this.attributes.filter(x=>x.name?.includes("Група крові"))[0].id).subscribe((blood_types) => {this.blood_types = blood_types});
      this._apiService.attributes.GetAttributeValues(this.attributes.filter(x=>x.name?.includes("Тип форми"))[0].id).subscribe((uniforms) => {this.uniforms = uniforms});
    })

    const userId = this._apiService.auth.getUserId();
    userId.then((value) => {
      this._apiService.unitUser.GetUnitUser(value)
        .subscribe(result => {
          this._apiService.units.single.getById(result["id"])
            .subscribe(result => {
              this.unitModel = result;
              this.updateProfileForm.get("LastName").setValue(this.unitModel.lastName)
              this.updateProfileForm.get("FirstName").setValue(this.unitModel.firstName)
              this.updateProfileForm.get("SecondName").setValue(this.unitModel.secondName)
              for(let i = 0; i < this.unitModel.profiles.length; i++) {
                this.updateProfileForm.get(AttributesName[i]).setValue(this.unitModel.profiles[i].value)
              }
            })
        })
    })
  }

  getRankId(rank: string): number {
    let rankId = 0;
    for(let i = 0; i < this.ranks.length; i++){
      //@ts-ignore
      if(rank == this.ranks[i].name){
        rankId = this.ranks[i].id
      }
    }
    return rankId;
  }
  getPositionId(position: string): number {
    let posId = 0;
    for(let i = 0; i < this.pos.length; i++){
      //@ts-ignore
      if(position == this.pos[i].name){
        posId = this.ranks[i].id
      }
    }
    return posId;
  }
  update() {
      if(this.updateProfileForm.invalid){
        alert("Невірно введені дані")
        return;
      }
    let updatedUnit: UnitModel = this.updateProfileForm.value;
    updatedUnit.rankId = this.getRankId(this.updateProfileForm.get("Rank").value)
    updatedUnit.positionId = this.getPositionId(this.updateProfileForm.get("Position").value)
    updatedUnit.id = this.unitModel.id
    updatedUnit.profiles = [];
    for(let i = 0; i < this.unitModel.profiles.length; i++) {
      updatedUnit.profiles.push(new ProfileModel(this.unitModel.profiles[i].id,
        this.attributes.find(x => x.name==this.unitModel.profiles[i].name)?.id, this.unitModel.id,
        this.updateProfileForm.get(AttributesName[i])?.value, null));
    }
    this._apiService.units.single.update(updatedUnit).subscribe(
      data => {
        this._messageService.add({ severity: 'success', summary: 'Дані оновлено!'});
        setTimeout(() => {this._router.navigate(['/profile'], { replaceUrl: true })}, 2000);
      },
      error => {
        this._messageService.add({ severity: 'error', summary: 'Помилка оновлення даних!',detail: String((error as HttpErrorResponse).error).split('\n')[0] });
      })
  }
}
