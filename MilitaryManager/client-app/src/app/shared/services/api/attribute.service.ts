import { Injectable } from '@angular/core';
import { AttributeModel } from '../../models/attribute.model';
import { BaseService } from '../core/base.service';
import { ClientConfigurationService } from '../core/client-configuration.service';
import { HttpService } from '../core/http.service';
import { ServiceType } from '../core/serviceType';

@Injectable({
  providedIn: 'root'
})
export class AttributeService extends BaseService<any>{

  constructor(
    private httpService: HttpService,
    configService: ClientConfigurationService) {
    super(httpService, 'attribute', configService, AttributeModel, ServiceType.units);
  }

  GetAttributeValues(id:number|null) {
    return this.httpService.get(`${this.collection.baseUrl}attribute/${id}`);
  }
}
