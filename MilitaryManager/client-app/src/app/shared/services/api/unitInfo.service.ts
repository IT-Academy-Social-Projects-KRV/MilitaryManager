import { Injectable } from "@angular/core";
import { UnitModel } from "../../models/unit.model";
import { HttpService } from "../core/http.service";
import { BaseService } from "../core/base.service";
import { ClientConfigurationService } from "../core/client-configuration.service";
import { ServiceType } from "../core/serviceType";

@Injectable({
  providedIn: 'root',
})
export class UnitsInfoService extends BaseService<any> {

  constructor(
    httpService: HttpService,
    configService: ClientConfigurationService) {
    super(httpService, 'unitInfo', configService, UnitModel, ServiceType.units);
  }
}