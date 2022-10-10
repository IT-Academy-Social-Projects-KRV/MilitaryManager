import { Injectable } from '@angular/core';
import { UnitUserModel } from '../../models/unit-user.model';
import { BaseService } from '../core/base.service';
import { ClientConfigurationService } from '../core/client-configuration.service';
import { HttpService } from '../core/http.service';
import { ServiceType } from '../core/serviceType';

@Injectable({
  providedIn: 'root'
})
export class UnitUserService extends BaseService<any>{

  constructor(
    private httpService : HttpService,
    configService : ClientConfigurationService) {
    super(httpService, 'unitUser', configService, UnitUserModel, ServiceType.units);
  }

  GetUnitUser(id:string) {
    return this.httpService.get(`${this.single.baseUrl}/${id}`);
  }
}
