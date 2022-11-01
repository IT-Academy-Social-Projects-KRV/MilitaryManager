import {Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges} from '@angular/core';
import {UnitModel} from "../../../../shared/models/unit.model";
import {UnitsService} from "../../../../shared/services/api/unit.service";

import {
  logExperimentalWarnings
} from "@angular-devkit/build-angular/src/builders/browser-esbuild/experimental-warnings";
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { AttributeModel } from 'src/app/shared/models/attribute.model';
import { ApiService } from 'src/app/shared/services/api/api.service';
import { ProfileModel } from 'src/app/shared/models/profile.model';


type testObject = {
  name: string | any,
  value: string
}

@Component({
  selector: 'app-unit-info',
  templateUrl: './unit-info.component.html',
  styleUrls: ['./unit-info.component.scss']
})

export class UnitInfoComponent implements OnInit, OnChanges {

  @Input() idChild1: number;

  unit: UnitModel = new UnitModel();
  unitInfo: UnitModel = new UnitModel();
  parentFullName: string = "";
  divisionName: string = "";

  
  testArr: testObject[] = [];

  isReadonly: boolean = true;
  attributes: AttributeModel[] = [];

  personalInfoForm: FormGroup = this._formBuilder.group({
    LastName: ['', Validators.required],
    FirstName: ['', Validators.required],
    SecondName: ['', Validators.required],
    Rank: ['', Validators.required],
    Position: ['', Validators.required],
    Division: ['', Validators.required],
    ParentName: ['', Validators.required]
  })

  constructor(private unitsService: UnitsService, private _formBuilder: FormBuilder, private messageService: MessageService, private _apiService: ApiService) {
  }

  ngOnInit(): void {
    this._apiService.attributes.collection.getAll().subscribe(attributes => {
      this.attributes = attributes
    })
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.showFullUnitInfo();
  }

  showFullUnitInfo() {
    this.unitsService.single.getById(this.idChild1)
      .subscribe((u) => {
        this.unit = u;

        this.testArr=[]

        this.unit.profiles.forEach((profile) =>{
          this.testArr.push({
            name:profile.name,
            value:profile.value
          })
        }) 

        if (this.unit.parent != null) {
          this.parentFullName = `${this.unit.parent.lastName} ${this.unit.parent.firstName} ${this.unit.parent.secondName}`;
        } else {
          this.parentFullName = 'Немає';
        }

        this.divisionName = this.unit.division.name;

        this.personalInfoForm.get("LastName").setValue(this.unit.lastName);
        this.personalInfoForm.get("FirstName").setValue(this.unit.firstName);
        this.personalInfoForm.get("SecondName").setValue(this.unit.secondName);
        this.personalInfoForm.get("Rank").setValue(this.unit.rank);
        this.personalInfoForm.get("Position").setValue(this.unit.position);
        this.personalInfoForm.get("Division").setValue(this.unit.division.name);
        if(this.unit.parent!){
          this.personalInfoForm.get("ParentName").setValue(this.unit.parent.lastName + " " + this.unit.parent.firstName + " " + this.unit.parent.secondName);
        }
        else{
          this.personalInfoForm.get("ParentName").setValue("Немає");
        }

        
      });
  }

  edit(){
    this.isReadonly = false;
  }

  save() {
    this.isReadonly = true;
    this.unit.firstName = this.personalInfoForm.get("FirstName").value;
    this.unit.lastName = this.personalInfoForm.get("LastName").value;
    this.unit.secondName = this.personalInfoForm.get("SecondName").value;
    for(let i = 0; i < this.unit.profiles.length; i++) {
      this.unit.profiles[i] = new ProfileModel(this.unit.profiles[i].id,
        this.attributes.find(x => x.name==this.unit.profiles[i].name)?.id, this.unit.id,
        this.testArr[i].value, null, this.testArr[i].name)
    }
    this.unitsService.single.update(this.unit).subscribe(
      () =>  this.messageService.add({ severity: 'success', summary: 'Солдата відредаговано' }),
      () => this.messageService.add({ severity: 'error', summary: 'Виникла помилка!'})
    );
  }
}
