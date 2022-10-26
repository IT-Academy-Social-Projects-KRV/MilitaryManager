import { Component, OnInit } from '@angular/core';
import {PositionModel} from "../../../shared/models/position.model";
import {AttributeModel} from "../../../shared/models/attribute.model";
import {RankModel} from "../../../shared/models/rank.model";
import {UnitUserService} from "../../../shared/services/api/unit-user.service";
import {PositionService} from "../../../shared/services/api/position.service";
import {RankService} from "../../../shared/services/api/rank.service";
import {AttributeService} from "../../../shared/services/api/attribute.service";
import {Router} from "@angular/router";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {AuthService} from "../../../shared/services/auth.service";
import {UnitsService} from "../../../shared/services/api/unit.service";
import {UnitModel} from "../../../shared/models/unit.model";
import {ProfileModel} from "../../../shared/models/profile.model";
import {HttpErrorResponse} from "@angular/common/http";
import {MessageService} from "primeng/api";

export enum AttributesName
{
  FootSize,
  HeadSize,
  GasMaskSize,
  Uniform,
  BloodType,
  Weight,
  Height,
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
  /*  readonly weightValueValidator = (control: FormControl) => {

      if(control.value < 40 || control.value > 150) {
        return Observable<{weightValueValidator: 'Невірно введені дані, спробуйте від 40 до 150 включно'}>
      }
      return Observable<null>
    }
    readonly heightValueValidator = (control: FormControl) => {
      if(control.value < 150 || control.value > 250) {
       // return {heightValueValidator: 'Невірно введені дані, спробуйте від 150 до 250 включно'}
        return Observable<{weightValueValidator: 'Невірно введені дані, спробуйте від 40 до 150 включно'}>
      }
      return Observable<null>
    }
    readonly footSizeValueValidator = (control: FormControl) => {
      if(control.value < 38 || control.value > 47) {
        return Observable<{weightValueValidator: 'Невірно введені дані, спробуйте від 40 до 150 включно'}>
        // return {footSizeValueValidator: 'Невірно введені дані, спробуйте від 38 до 47 включно'}
      }
      return Observable<null>
    }
    readonly headSizeValueValidator = (control: FormControl) => {
      if(control.value < 54 || control.value > 64) {
        return Observable<{weightValueValidator: 'Невірно введені дані, спробуйте від 40 до 150 включно'}>
        //return {headSizeValueValidator: 'Невірно введені дані, спробуйте від 54 до 64 включно'}
      }
      return Observable<null>
    }
    readonly gasMaskSizeValueValidator = (control: FormControl) => {
      if(control.value < 0 || control.value > 4) {
        return Observable<{weightValueValidator: 'Невірно введені дані, спробуйте від 40 до 150 включно'}>
        //return {gasMaskSizeValidator: 'Невірно введені дані, спробуйте від 0 до 4 включно'}
      }
      return Observable<null>
    }*/


  updateProfileForm: FormGroup = this._formBuilder.group({
    LastName: ['', Validators.required],
    FirstName: ['', Validators.required],
    SecondName: ['', Validators.required],
    Rank: ['', Validators.required],
    Position: ['', Validators.required],
    FootSize: ['', Validators.required], //[this.footSizeValueValidator]],
    HeadSize: ['', Validators.required], //[this.headSizeValueValidator]],
    GasMaskSize: ['', Validators.required],// [this.gasMaskSizeValueValidator]],
    Uniform: ['', Validators.required],
    BloodType: ['', Validators.required],
    Weight: ['', Validators.required],// [this.weightValueValidator]],
    Height: ['', Validators.required], //[this.heightValueValidator]]
  })



  constructor(private _unitUserService : UnitUserService,
              private _rankService: RankService,
              private _attributeService: AttributeService,
              private _positionService: PositionService,
              private _router: Router,
              private _formBuilder: FormBuilder,
              private _authService: AuthService,
              private _unitService: UnitsService,
              private _messageService: MessageService) { }

  ngOnInit(): void {
    this._positionService.collection.getAll().subscribe(pos => {this.pos = pos});
    this._rankService.collection.getAll().subscribe(ranks => {this.ranks = ranks});
    this._attributeService.collection.getAll().subscribe((attributes)=>
    {
      this.attributes = attributes
      this._attributeService.GetAttributeValues(this.attributes.filter(x=>x.name?.includes("Група крові"))[0].id).subscribe((blood_types) => {this.blood_types = blood_types});
      this._attributeService.GetAttributeValues(this.attributes.filter(x=>x.name?.includes("Тип форми"))[0].id).subscribe((uniforms) => {this.uniforms = uniforms});
    });

    const userId = this._authService.getUserId();
    userId.then((value) => {
      this._unitUserService.GetUnitUser(value)
        .subscribe(result => {
          this._unitService.single.getById(result["id"])
            .subscribe(result => {
              this.unitModel = result;
              console.log(result)
              this.updateProfileForm.get("LastName").setValue(this.unitModel.lastName)
              this.updateProfileForm.get("FirstName").setValue(this.unitModel.firstName)
              this.updateProfileForm.get("SecondName").setValue(this.unitModel.secondName)
              for(let i = 0; i < this.unitModel.profiles.length; i++) {
                this.updateProfileForm.get(AttributesName[i]).setValue(this.unitModel.profiles[i].value)
              }
             // let updatedUnit: UnitModel = this.updateProfileForm.value;
/*              updatedUnit.updatedProfiles = [];
              for(let i = 0; i < this.unitModel.profiles.length; i++) {
                updatedUnit.updatedProfiles.push(new updatedProfileModel(this.unitModel.profiles[i].id,
                  this.attributes.find(x => x.name==this.unitModel.profiles[i].name)?.id, this.unitModel.id,
                  this.updateProfileForm.get(AttributesName[i])?.value));
              }*/
             // console.log(updatedUnit)
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
    this._unitService.single.update(updatedUnit).subscribe(
      data => {
        this._messageService.add({ severity: 'success', summary: 'Дані оновлено!'});
        setTimeout(() => {this._router.navigate(['/profile'], { replaceUrl: true })}, 2000);
      },
      error => {
        this._messageService.add({ severity: 'error', summary: 'Помилка оновлення даних!',detail: String((error as HttpErrorResponse).error).split('\n')[0] });
      })
  }
}
