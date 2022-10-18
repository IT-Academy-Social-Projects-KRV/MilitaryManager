import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { DivisionModel } from 'src/app/shared/models/division.model';
import { DivisionsService } from 'src/app/shared/services/api/division.service';

@Component({
  selector: 'app-division-new',
  templateUrl: './division-new.component.html',
  styleUrls: ['./division-new.component.scss']
})
export class DivisionNewComponent implements OnInit {
  divisions: DivisionModel[] = [];

  name: string = '';
  divisionNumber: string = '';
  address: string = '';
  selected_division?: DivisionModel;

  useRedClass: boolean = false;

  constructor(private messageService: MessageService, private _divisionsService: DivisionsService) {
    this._divisionsService.collection.getAll().subscribe((divisions)=>{this.divisions = divisions});
  }

  ngOnInit(): void { 

  }

  addDivision() {
    if(!(this.name == '' || this.divisionNumber == '' || this.address == '')) {
      this.useRedClass = false;
      this._divisionsService.single.create(new DivisionModel(0, this.name, this.divisionNumber, this.address, this.selected_division?._id))
        .subscribe(
          data => this.messageService.add({ severity: 'success', summary: 'Підрозділ створено', detail: 'division created' }),
          error => {
            this.messageService.add({ severity: 'error', summary: 'Підрозділ не створено!', detail: String((error as HttpErrorResponse).error).split('\n')[0] });
            this.useRedClass = true;
          });
    }
    else {
      this.useRedClass = true;
    }
  }
}
