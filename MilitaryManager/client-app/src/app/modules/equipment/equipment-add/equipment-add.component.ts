import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { AttributeModel } from 'src/app/shared/models/attribute.model';
import { DivisionModel } from 'src/app/shared/models/division.model';
import { EntityModel } from 'src/app/shared/models/entity.model';
import { EntityToAttributeModel } from 'src/app/shared/models/entityToAttribute.model';
import { AttributeService } from 'src/app/shared/services/api/attribute.service';
import { DivisionsService } from 'src/app/shared/services/api/division.service';
import { EquipmentService } from 'src/app/shared/services/api/equipment.service';

@Component({
  selector: 'app-equipment-add',
  templateUrl: './equipment-add.component.html',
  styleUrls: ['./equipment-add.component.scss']
})
export class EquipmentAddComponent implements OnInit {

  equipmentForm: FormGroup = this._fb.group({
    regNum: ["", Validators.required],
    division: [null, Validators.required],
    class: ["", Validators.required],
    name: ["", Validators.required],
    manufacturer: ["", Validators.required],
    caliber: [""],
    small_arms_type: [""],
    caliber_type: [""],
    mode_of_action: ["", Validators.required],
    mode_of_influence: ["", Validators.required],
    sight_type: [""],
    pnb_type: [""]
  })

  attributes: AttributeModel[] = [];
  divisions: DivisionModel[] = [];

  redclass = false;

  constructor(private _fb: FormBuilder,
    private _attributeService: AttributeService,
    private _divisionsService: DivisionsService,
    private _equipmentService: EquipmentService,
    private messageService: MessageService,
    private _router: Router) { }

  ngOnInit(): void {
    this._divisionsService.GetAllDivisions().subscribe((divisions)=>{this.divisions = divisions});
    this._attributeService.collection.getAll().subscribe((attributes)=>{this.attributes = attributes});
  }


  EndRegistrationBtn(){
    if(this.equipmentForm.valid){
      this.redclass = false;
      let newEntity: EntityModel = this.equipmentForm.value;

      newEntity.division =  this.equipmentForm.get("division")?.value;

      newEntity.entityToAttributes = [];
      newEntity.entityToAttributes.push(new EntityToAttributeModel(0, 0, this.attributes.find(x => x.name=="Клас захисту")?.id, this.equipmentForm.get("class")?.value));
      newEntity.entityToAttributes.push(new EntityToAttributeModel(0, 0, this.attributes.find(x => x.name=="Назва")?.id, this.equipmentForm.get("name")?.value));
      newEntity.entityToAttributes.push(new EntityToAttributeModel(0, 0, this.attributes.find(x => x.name=="Виробник")?.id, this.equipmentForm.get("manufacturer")?.value));
      newEntity.entityToAttributes.push(new EntityToAttributeModel(0, 0, this.attributes.find(x => x.name=="Калібр")?.id, this.equipmentForm.get("caliber")?.value));
      newEntity.entityToAttributes.push(new EntityToAttributeModel(0, 0, this.attributes.find(x => x.name=="Вид стрілецької зброї")?.id, this.equipmentForm.get("small_arms_type")?.value));
      newEntity.entityToAttributes.push(new EntityToAttributeModel(0, 0, this.attributes.find(x => x.name=="Тип калібру")?.id, this.equipmentForm.get("caliber_type")?.value));
      newEntity.entityToAttributes.push(new EntityToAttributeModel(0, 0, this.attributes.find(x => x.name=="Спосіб дії")?.id, this.equipmentForm.get("mode_of_action")?.value));
      newEntity.entityToAttributes.push(new EntityToAttributeModel(0, 0, this.attributes.find(x => x.name=="Спосіб впливу")?.id, this.equipmentForm.get("mode_of_influence")?.value));
      newEntity.entityToAttributes.push(new EntityToAttributeModel(0, 0, this.attributes.find(x => x.name=="Тип прицілу")?.id, this.equipmentForm.get("sight_type")?.value));
      newEntity.entityToAttributes.push(new EntityToAttributeModel(0, 0, this.attributes.find(x => x.name=="Тип ПНБ")?.id, this.equipmentForm.get("pnb_type")?.value));

      this._equipmentService.single.create(newEntity)
        .subscribe(
        data => {
          this.messageService.add({ severity: 'success', summary: 'Дані додано!'});
          setTimeout(() => {this._router.navigate(['/equipment/list'], { replaceUrl: true })}, 2000);
        },
        error => {
          this.messageService.add({ severity: 'error', summary: 'Помилка додання даних!',detail: String((error as HttpErrorResponse).error).split('\n')[0] });
        });
    }
    else {
      this.redclass = true;
      this.messageService.add({ severity: 'error', summary: 'Заповність необхідні поля!' });
    }
  }

}
