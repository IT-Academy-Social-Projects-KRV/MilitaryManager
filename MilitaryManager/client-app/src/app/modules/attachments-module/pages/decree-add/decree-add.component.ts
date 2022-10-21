import { Component, OnInit } from '@angular/core';
import { AttachmentModel } from '../../../../shared/models/attachment.model'
import { UnitModel } from 'src/app/shared/models/unit.model';
import { MessageService } from 'primeng/api';
import { DecreeService } from 'src/app/shared/services/api/decree.service';
import { UnitsService } from 'src/app/shared/services/api/unit.service';
import { AuthService } from 'src/app/shared/services/auth.service';
import { UnitUserService } from 'src/app/shared/services/api/unit-user.service';
import { UnitUserModel } from 'src/app/shared/models/unit-user.model';

@Component({
  selector: 'app-decree-add',
  templateUrl: './decree-add.component.html',
  providers: [MessageService],
  styleUrls: ['./decree-add.component.scss'],
})
export class DecreeAddComponent implements OnInit {

  decrees: AttachmentModel[]=[];
  units: UnitModel[]= [];
  user: UnitUserModel = new UnitUserModel(null);
  commander: UnitModel = new UnitModel(null);
  selectedUnit: UnitModel = new UnitModel(null);
  templateId: number | null = null;
  templateType: string | null = null;

  clonedDecrees: { [s: string]: AttachmentModel; } = {};

    constructor(private decreeService: DecreeService, private unitsService: UnitsService, 
      private messageService: MessageService, private authService: AuthService, private unitUser: UnitUserService) {
    }

    addDecree(attachment: AttachmentModel[]) {
      let decreeInformation;
      let dateFormatter = new Intl.DateTimeFormat('uk-UA');

      let id = this.authService.getCurrentUser().profile.sub;
      this.unitUser.GetUnitUser(id).subscribe(user => { this.user = user 

      if(this.user.id!= null)
      {
        this.unitsService.single.getById(this.user.id).subscribe(commander => { this.commander = commander 
      
        for(const element of attachment)
        {
          decreeInformation = 
          { 
            templateId: this.templateId, 
            decreeName: `${this.templateType} від ${dateFormatter.format(new Date(element.currentDate!))}`,
            lastName: element.soldier?.lastName,
            firstName: element.soldier?.firstName,
            secondName: element.soldier?.secondName,
            currentDate: dateFormatter.format(new Date(element.currentDate!)),
            commanderLastName: this.commander.lastName,
            commanderFirstName: this.commander.firstName,
            commanderSecondName: this.commander.secondName,
            divisionNumber: element.soldier?.division?.divisionNumber,
            commanderDivisison: this.commander.division?.divisionNumber,
            decreeNumber: element.decreeNumber
          }
          
            this.decreeService.single.create(decreeInformation).subscribe(
            () =>  this.messageService.add({ severity: 'success', summary: 'Наказ успішно створено' }),
            () => this.messageService.add({ severity: 'error', summary: 'Наказ не створено!'})
          );
        }
        });
      }
      });
    }

    addSoldier(soldier: UnitModel) {
      if (soldier.id!=null)
      {
        let newDecree = new AttachmentModel(soldier.id);
        newDecree.soldier = soldier;
        newDecree.payOff = false;
        newDecree.action = this.templateType;
        newDecree.decreeNumber = null;
        newDecree.currentDate = new Date();
        this.decrees.push(newDecree);
      }
  }

    onRowEditInit(attachment: AttachmentModel) {
      let editAttachment = new AttachmentModel(attachment.id)
      editAttachment.soldier = attachment.soldier
      editAttachment.action = attachment.action
      editAttachment.decreeNumber = attachment.decreeNumber
      editAttachment.currentDate = attachment.currentDate
      editAttachment.payOff = attachment.payOff;

      if(editAttachment.id!=null)
      {
        this.clonedDecrees[editAttachment.id]=editAttachment;
      }
    }

    onRowEditSave(attachment: AttachmentModel, index: number) {
        if (attachment.id!=null) {
          if(attachment.decreeNumber == "" || attachment.decreeNumber == null)
            {
              this.onRowEditCancel(attachment, index);
              this.messageService.add({severity:'error', summary: 'Виникла помилка', detail:'Введіть номер наказу'});
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
      setTimeout(() => {
        this.unitsService.getAll()
          .subscribe((units) => {
            this.units = units.map((unit: any) => {
              return {
                ...unit,
                displayLabel: unit.lastName + ' ' + unit.firstName + ' ' + unit.secondName,
              };
            });
      });
      });
  }
}
