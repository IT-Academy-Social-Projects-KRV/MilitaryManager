import { Injectable } from '@angular/core';
import { UnitModel } from '../../models/unit.model';
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
    super(httpService, 'UnitUser', configService, UnitModel, ServiceType.units);
  }

  GetUnitUser(id:string) {
    console.log(`${this.single.baseUrl}${id}`);
    return this.httpService.get(`${this.single.baseUrl}UnitUser/${id}`);
  }
}
