import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup  } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { UnitModel } from 'src/app/shared/models/unit.model';
import { ApiService } from 'src/app/shared/services/api/api.service';

@Component({
  selector: 'app-transfer',
  templateUrl: './transfer.component.html',
  styleUrls: ['./transfer.component.scss']
})
export class TransferComponent implements OnInit {
  
  units: UnitModel[] = [];
  selectedUnits: UnitModel[] = [];
  selectedUnit: UnitModel;
  form: FormGroup;
  templateId: number;

  constructor(private apiService: ApiService, private fb: FormBuilder, private messageService: MessageService) { 
    this.form = this.fb.group({
      templateId: '',
      commanderLastName: '',
      commanderFirstName: '',
      commanderSecondName: '',
      commanderRank: '',
      commanderDivisionNumber: '',
      currentDate: '',
      city: '',
      decreeName: '',
      decreeNumber: '',
      lastName: '',
      firstName: '',
      secondName: '',
      soldireDivisionNumber: '',
      assignmentDate: '',
      assignmentNumber: '',
      assignmentDivisionNumber: '',
      newDivisionNumber: '',
      dismissDate: '',
      percent: '',
      increasePercent: '',
      serviceDateFrom: '',
      serviceDateTo: '',
    });
  }

  ngOnInit(): void {
    setTimeout(() => {
      this.apiService.unitsInfoService.collection.getAll().subscribe((units) => {
          this.units = units.map((unit: any) => {
            return {
              ...unit,
              displayLabel: unit.lastName + ' ' + unit.firstName + ' ' + unit.secondName,
            };
          });
        });
    });
  }

  addSoldier(soldier: UnitModel) {
    if (soldier.id!=null)
    {
      this.selectedUnits.push(soldier);
    }
  }

  submitForm() {
    this.form.patchValue({
      templateId: this.templateId,
      lastName: this.selectedUnits[0].lastName,
      firstName: this.selectedUnits[0].firstName,
      secondName: this.selectedUnits[0].secondName,
      soldireDivisionNumber: this.selectedUnits[0].division.divisionNumber,
    });
    this.apiService.decree.single.create(this.form.value)
      .subscribe({
        next: (response) => this.messageService.add({ severity: 'success', summary: 'Наказ успішно створено!' }),
        error: (error) => this.messageService.add({ severity: 'error', summary: 'Наказ не створено!'}),
      });
  }

}
