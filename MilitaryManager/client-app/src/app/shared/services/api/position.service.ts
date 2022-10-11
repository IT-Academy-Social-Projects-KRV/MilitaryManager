import { Injectable } from '@angular/core';
import { ClientConfigurationService } from '../core/client-configuration.service';
import { HttpService } from '../core/http.service';
import { ServiceType } from '../core/serviceType';
import { BaseService } from "../core/base.service";
import { PositionModel } from '../../models/position.model';

@Injectable({
  providedIn: 'root'
})
export class PositionService extends BaseService<any>{

  constructor(
    private httpService: HttpService,
    configService: ClientConfigurationService) {
    super(httpService, 'position', configService, PositionModel, ServiceType.units);
    console.log(this.collection.baseUrl);
  }
}
