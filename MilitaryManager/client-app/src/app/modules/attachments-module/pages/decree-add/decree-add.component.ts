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

  decrees: AttachmentModel[]=[];
  units: UnitModel[]= Units;
  selectedUnit: UnitModel = new UnitModel(null);

    clonedDecrees: { [s: string]: AttachmentModel; } = {};

    constructor(private attachmentsService: AttachmentsService, private messageService: MessageService) {
    }

    addSoldier(soldier: UnitModel) {
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
      var tmp = new AttachmentModel(attachment.id, attachment.soldier, attachment.action, attachment.date, attachment.payOff);
      if(tmp.id!=null)
      {
        this.clonedDecrees[tmp.id]=tmp;
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
      }
    }

    ngOnInit() {
      this.units = this.units.map((unit: any) => {
        return {
          ...unit,
          displayLabel: unit.surname + ' ' + unit.name + ' ' + unit.middlename,
        };
      });
    }

}

export const Units: UnitModel[]=[
  {id:1, _id: 1, name: "Петро", surname: "Петренко", middlename: "Петрович"},
  /*{id:2, name: "Іван", surname: "Іваненко", middlename: "Іванович"},
  {id:3, name: "Андрій", surname: "Островський", middlename: "Михайлович"},
  {id:4, name: "Степан", surname: "Панас", middlename: "Іванович"},
  {id:5, name: "Мирослав", surname: "Загакайло", middlename: "Павлович"},*/
];
