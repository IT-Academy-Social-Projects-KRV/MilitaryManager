import { Injectable } from "@angular/core";
import { UnitModel } from "../../models/unit.model";
import { HttpService } from "../core/http.service";
import { BaseService } from "../core/base.service";
import { ClientConfigurationService } from "../core/client-configuration.service";
import { ServiceType } from "../core/serviceType";
import {Observable } from "rxjs";

@Injectable({
  providedIn: 'root',
})
export class UnitsService extends BaseService<any> {
  
  constructor(
    httpService: HttpService,
    configService: ClientConfigurationService) {
    super(httpService, 'weatherForecast', configService, UnitModel, ServiceType.units);
  }

}
