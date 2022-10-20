import { Injectable } from '@angular/core';
import { ProfileModel } from '../../models/profile.model';
import { BaseService } from '../core/base.service';
import { ClientConfigurationService } from '../core/client-configuration.service';
import { HttpService } from '../core/http.service';
import { ServiceType } from '../core/serviceType';

@Injectable({
  providedIn: 'root'
})
export class ProfileService extends BaseService<any>{

  constructor(
    private httpService: HttpService,
    configService: ClientConfigurationService) {
    super(httpService, 'profile', configService, ProfileModel, ServiceType.units);
  }
}
