import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { DivisionModel } from 'src/app/shared/models/division.model';
import { DivisionsService } from 'src/app/shared/services/api/division.service';

@Component({
  selector: 'app-division-new',
  templateUrl: './division-new.component.html',
  styleUrls: ['./division-new.component.scss']
})
export class DivisionNewComponent implements OnInit {

  addDivisionForm: FormGroup = this._fb.group({
    name: ["", Validators.required],
    divisionNumber: ["", Validators.required],
    address: ["", Validators.required],
    parentId: [0]
  })

  divisions: DivisionModel[] = [];

  constructor(private messageService: MessageService,
    private _divisionsService: DivisionsService,
    private _fb: FormBuilder) { }

  ngOnInit(): void { 
    this._divisionsService.GetAllDivisions().subscribe((divisions)=>{this.divisions = divisions});
  }

  addDivision() {
    if(this.addDivisionForm.valid) {
      
      let newDivision: DivisionModel = this.addDivisionForm.value;

      this._divisionsService.single.create(newDivision)
        .subscribe(
          data => this.messageService.add({ severity: 'success', summary: 'Підрозділ створено', detail: 'division created' }),
          error => {
            this.messageService.add({ severity: 'error', summary: 'Підрозділ не створено!', detail: String((error as HttpErrorResponse).error).split('\n')[0] });
          });
    }
  }
}
