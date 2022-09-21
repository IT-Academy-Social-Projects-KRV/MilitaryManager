import { Component, OnInit } from '@angular/core';
import { AttachmentModel } from '../../../../shared/models/attachment.model'
import { UnitModel } from 'src/app/shared/models/unit.model';
import { AttachmentsService} from '../../../../shared/services/api/attachment.service'
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-decree-add',
  templateUrl: './decree-add.component.html',
  providers: [MessageService],
  styleUrls: ['./decree-add.component.scss'],
})
export class DecreeAddComponent implements OnInit {

  decrees: AttachmentModel[]=Decrees;
  units: UnitModel[]= Units;
  selectedUnit: UnitModel = new UnitModel(null);

    clonedDecrees: { [s: string]: AttachmentModel; } = {};

    constructor(private attachmentsService: AttachmentsService, private messageService: MessageService) { 
    }

    handleClick(soldier: UnitModel) {
      if (soldier.id!=null)
      {
        let newDecree = new AttachmentModel(soldier.id);
        newDecree.soldier = soldier;
        newDecree.payOff = false;
        newDecree.action = "";
        newDecree.date = new Date();
        this.decrees.push(newDecree);
      }
  }

    onRowEditInit(attachment: AttachmentModel) {
      if(attachment.id!=null)
      {
        this.clonedDecrees[attachment.id] = {...attachment};
      }
    }

    onRowEditSave(attachment: AttachmentModel, index: number) {
        if (attachment.id!=null) {
          if(attachment.action=="")
            {
              this.onRowEditCancel(attachment, index);
              this.messageService.add({severity:'error', summary: 'Виникла помилка', detail:'Зміни не внесено'});
            }
            else
            {
            delete this.clonedDecrees[attachment.id];
            this.messageService.add({severity:'success', summary: 'Успішна спроба', detail:'Дані змінено'});
            }
        }
        
    }

    onRowEditCancel(attachment: AttachmentModel, index: number) {
      if(attachment.id!=null)
      {
        this.decrees[index] = this.clonedDecrees[attachment.id];
        delete this.clonedDecrees[attachment.id];
      }
    }

    ngOnInit() {

    }

}

export const Decrees: AttachmentModel[] = [
  { id: 1, soldier: new UnitModel(1), action: "Внутрішнє переміщення", date: new Date(), payOff: true},
 ];
 
 export const Units: UnitModel[]=[
     {id:1},
     {id:2},
     {id:3},
     {id:4},
     {id:5},
 ];
