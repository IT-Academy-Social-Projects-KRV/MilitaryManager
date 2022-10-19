import { Injectable } from "@angular/core";
import { HttpService } from "../core/http.service";
import { BaseService } from "../core/base.service";
import { ClientConfigurationService } from "../core/client-configuration.service";
import { ServiceType } from "../core/serviceType";
import {ChangeValuesModel} from "../../models/changeValues.model";

@Injectable({
  providedIn: 'root',
})
export class LogDetalesService extends BaseService<any> {

  constructor(
    httpService: HttpService,
    configService: ClientConfigurationService) {
    super(httpService, 'auditvaluedetales', configService, ChangeValuesModel, ServiceType.units);
  }
}

