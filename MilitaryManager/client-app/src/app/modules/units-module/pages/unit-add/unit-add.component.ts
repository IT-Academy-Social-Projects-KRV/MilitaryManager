import { Component, OnInit } from '@angular/core';
import { DivisionModel } from 'src/app/shared/models/division.model';
import { PositionModel } from 'src/app/shared/models/position.model';
import { RankModel } from 'src/app/shared/models/rank.model';
import { DivisionsService } from 'src/app/shared/services/api/division.service';
import { PositionService } from 'src/app/shared/services/api/position.service';
import { RankService } from 'src/app/shared/services/api/rank.service';
import { MessageService } from 'primeng/api';
import { AttributeModel } from 'src/app/shared/models/attribute.model';
import { AttributeService } from 'src/app/shared/services/api/attribute.service';
import { ProfileModel } from 'src/app/shared/models/profile.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UnitModel } from 'src/app/shared/models/unit.model';
import { UnitsService } from 'src/app/shared/services/api/unit.service';
import { AuthService } from 'src/app/shared/services/auth.service';
import { UnitUserService } from 'src/app/shared/services/api/unit-user.service';
import { UnitUserModel } from 'src/app/shared/models/unit-user.model';

@Component({
  selector: 'app-unit-add',
  templateUrl: './unit-add.component.html',
  styleUrls: ['./unit-add.component.scss']
})
export class UnitAddComponent implements OnInit {

  unitForm: FormGroup = this._fb.group({
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
  commander: UnitUserModel = new UnitUserModel(null);

  constructor(private _unitService: UnitsService,
    private _divisionsService: DivisionsService,
    private _positionService: PositionService,
    private _rankService: RankService,
    private _attributeService: AttributeService,
    private _authService: AuthService,
    private messageService: MessageService,
    private _unitUserService: UnitUserService,
    private _fb: FormBuilder) { }

  ngOnInit(): void {
    this._divisionsService.GetAllDivisions().subscribe((divisions) => { this.divisions = divisions });
    this._positionService.collection.getAll().subscribe((positions) => { this.positions = positions });
    this._rankService.collection.getAll().subscribe((ranks) => { this.ranks = ranks });
    this._attributeService.collection.getAll().subscribe((attributes) => {
      this.attributes = attributes
      this._attributeService.GetAttributeValues(this.attributes.filter(x => x.name?.includes("Група крові"))[0].id).subscribe((blood_types) => { this.blood_types = blood_types });
      this._attributeService.GetAttributeValues(this.attributes.filter(x => x.name?.includes("Тип форми"))[0].id).subscribe((uniforms) => { this.uniforms = uniforms });
    });
  }

  AddUnit() {
    if (this.unitForm.valid) {
      let newUnit: UnitModel = this.unitForm.value;
      newUnit.profiles = [];

      newUnit.profiles.push(new ProfileModel(0, this.attributes.find(x => x.name == "Розмір ноги")?.id, 0, this.unitForm.get("footSize")?.value, null));
      newUnit.profiles.push(new ProfileModel(0, this.attributes.find(x => x.name == "Розмір голови")?.id, 0, this.unitForm.get("headSize")?.value, null));
      newUnit.profiles.push(new ProfileModel(0, this.attributes.find(x => x.name == "Розмір протигазу")?.id, 0, this.unitForm.get("gasMaskSize")?.value, null));
      newUnit.profiles.push(new ProfileModel(0, this.attributes.find(x => x.name == "Тип форми")?.id, 0, this.unitForm.get("uniform")?.value, null));
      newUnit.profiles.push(new ProfileModel(0, this.attributes.find(x => x.name == "Група крові")?.id, 0, this.unitForm.get("bloodType")?.value, null));
      newUnit.profiles.push(new ProfileModel(0, this.attributes.find(x => x.name == "Вага")?.id, 0, this.unitForm.get("weight")?.value, null));
      newUnit.profiles.push(new ProfileModel(0, this.attributes.find(x => x.name == "Зріст")?.id, 0, this.unitForm.get("height")?.value, null));

      let userId = this._authService.getUserId();

      userId.then(value => {
        this._unitUserService.GetUnitUser(value)
        .subscribe(result => {
          this._unitService.single.getById(result["id"])
          .subscribe(result => {
            this.commander = result
            newUnit.parentId = this.commander.id

            this._unitService.single.create(newUnit)
              .subscribe(
                () => this.messageService.add({ severity: 'success', summary: 'Бійця створено' }),
                () => this.messageService.add({ severity: 'error', summary: 'Виникла помилка!' })
              );
          })
        })
      });
    }
  }
}
