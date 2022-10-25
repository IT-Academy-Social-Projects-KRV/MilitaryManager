import { Component, OnInit } from '@angular/core';
import {PositionModel} from "../../../shared/models/position.model";
import {AttributeModel} from "../../../shared/models/attribute.model";
import {RankModel} from "../../../shared/models/rank.model";
import {UnitUserService} from "../../../shared/services/api/unit-user.service";
import {PositionService} from "../../../shared/services/api/position.service";
import {RankService} from "../../../shared/services/api/rank.service";
import {AttributeService} from "../../../shared/services/api/attribute.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-update-profile',
  templateUrl: './update-profile.component.html',
  styleUrls: ['./update-profile.component.scss']
})
export class UpdateProfileComponent implements OnInit {

  /*myForm: FormGroup = new FormGroup({

    "Surname": new FormControl("", Validators.required),
    "Name": new FormControl("", Validators.required),
    "Patronymic": new FormControl("", Validators.required),
    "Rank": new FormControl("", Validators.required),
    "Position": new FormControl("", Validators.required),
    "FootSize": new FormControl(0, [Validators.required, this.footSizeValueValidator]),
    "HeadSize": new FormControl(0, [Validators.required, this.headSizeValueValidator]),
    "GasMaskSize": new FormControl(0, [Validators.required, this.gasMaskSizeValueValidator]),
    "Uniform": new FormControl("", Validators.required),
    "BloodType": new FormControl("", Validators.required),
    "Weight": new FormControl(0, [Validators.required, this.weightValueValidator]),
    "Height": new FormControl(0, [Validators.required, this.heightValueValidator])
  })*/

  pos: PositionModel[] = [];
  attributes: AttributeModel[] = [];
  ranks: RankModel[] = [];
  uniforms: string[] = [];
  blood_types: string[] = [];

  constructor(private _unitUserService : UnitUserService,
              private _rankService: RankService,
              private _attributeService: AttributeService,
              private _positionService: PositionService,
              private _router: Router) { }

  ngOnInit(): void {
    this._positionService.collection.getAll().subscribe(pos => {this.pos = pos});
    this._rankService.collection.getAll().subscribe(ranks => {this.ranks = ranks});
    this._attributeService.collection.getAll().subscribe((attributes)=>
    {
      this.attributes = attributes
      this._attributeService.GetAttributeValues(this.attributes.filter(x=>x.name?.includes("Група крові"))[0].id).subscribe((blood_types) => {this.blood_types = blood_types});
      this._attributeService.GetAttributeValues(this.attributes.filter(x=>x.name?.includes("Тип форми"))[0].id).subscribe((uniforms) => {this.uniforms = uniforms});
    });
  }
  /*weightValueValidator(control: FormControl): { [s: string]: boolean } | null {
    if(control.value < 40 || control.value > 150) {
      return {"Weight": true}
    }
    return null
  }
  heightValueValidator(control: FormControl): { [s: string]: boolean } | null{
    if(control.value < 150 || control.value > 250) {
      return {"Height": true}
    }
    return null
  }
  footSizeValueValidator(control: FormControl): { [s: string]: boolean } | null {
    if(control.value < 38 || control.value > 47) {
      return {"FootSize": true}
    }
    return null
  }
  headSizeValueValidator(control: FormControl) : {[s:string]:boolean}|null {
    if(control.value < 54 || control.value > 64) {
      return {"HeadSize": true}
    }
    return null
  }
  gasMaskSizeValueValidator(control: FormControl) : {[s:string]:boolean}|null {
    if(control.value < 0 || control.value > 4) {
      return {"GasMaskSize": true}
    }
    return null
  }*/
  update() {
    alert("a");
  }
}
