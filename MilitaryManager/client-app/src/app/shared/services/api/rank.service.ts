import { Injectable } from '@angular/core';
import { RankModel } from '../../models/rank.model';
import { BaseService } from "../core/base.service";
import { ClientConfigurationService } from '../core/client-configuration.service';
import { HttpService } from '../core/http.service';
import { ServiceType } from '../core/serviceType';

@Injectable({
  providedIn: 'root'
})
export class RankService extends BaseService<any>{

  constructor(
    private httpService: HttpService,
    configService: ClientConfigurationService) {
    super(httpService, 'rank', configService, RankModel, ServiceType.units);
  }
}
