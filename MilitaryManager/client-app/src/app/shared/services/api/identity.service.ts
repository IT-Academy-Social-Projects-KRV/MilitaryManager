import { Injectable } from '@angular/core';
import { AttachmentModel } from '../../models/attachment.model';
import { UserModel } from '../../models/user.model';
import { BaseService } from '../core/base.service';
import { ClientConfigurationService } from '../core/client-configuration.service';
import { HttpService } from '../core/http.service';
import { ServiceType } from '../core/serviceType';

@Injectable({
  providedIn: 'root'
})
export class IdentityService extends BaseService<UserModel>{
  constructor(
    httpService: HttpService,
    configService: ClientConfigurationService) {
    super(httpService, 'commander', configService, UserModel, ServiceType.identity);
  }
}
