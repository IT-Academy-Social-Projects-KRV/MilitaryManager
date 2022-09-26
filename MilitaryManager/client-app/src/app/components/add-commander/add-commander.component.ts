import { Component, OnInit } from '@angular/core';
import { IdentityService } from 'src/app/shared/services/api/identity.service';
import { UserModel } from 'src/app/shared/models/user.model';
import { MessageService } from 'primeng/api';
import { HttpErrorResponse } from '@angular/common/http';
import { Role } from './role';

@Component({
  selector: 'app-add-commander',
  templateUrl: './add-commander.component.html',
  styleUrls: ['./add-commander.component.scss']
})
export class AddCommanderComponent implements OnInit {
  roles: Role[];
  username: string = '';
  password: string = '';
  role: string = '';
  useRedClass: boolean = false;

  constructor(private identityService: IdentityService, private messageService: MessageService) {
    this.roles = [
      { name: 'Командир частини', value: 'UnitCommander' },
      { name: 'Командир підрозділу', value: 'SubUnitCommander' }]
  }

  ngOnInit(): void { }

  addCommander() {
    if (!(this.password == '' || this.username == '' || this.role == '')) {
      this.useRedClass = false;
      this.identityService.single.create(new UserModel(null, this.username, this.password, this.role))
        .subscribe(
          data => this.messageService.add({ severity: 'success', summary: 'Командира створено', detail: 'user created' }),
          error => {
            this.messageService.add({ severity: 'error', summary: 'Командира не створено!', detail: String((error as HttpErrorResponse).error).split('\n')[0] });
            this.useRedClass = true;
          });
    }
    else {
      this.useRedClass = true;
    }
  }
}
