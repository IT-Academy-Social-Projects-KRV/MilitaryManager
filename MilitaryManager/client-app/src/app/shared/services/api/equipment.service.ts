import { Injectable } from '@angular/core';
import { EntityModel } from '../../models/entity.model';
import { BaseService } from '../core/base.service';
import { ClientConfigurationService } from '../core/client-configuration.service';
import { HttpService } from '../core/http.service';
import { ServiceType } from '../core/serviceType';

@Injectable({
  providedIn: 'root'
})
export class EquipmentService extends BaseService<any> {

  constructor(
    private httpService: HttpService,
    configService: ClientConfigurationService) {
    super(httpService, 'equipment', configService, EntityModel, ServiceType.units);
  }
}
