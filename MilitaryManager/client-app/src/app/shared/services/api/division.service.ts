import { Injectable } from "@angular/core";
import { UnitModel } from "../../models/unit.model";
import { HttpService } from "../core/http.service";
import { BaseService } from "../core/base.service";
import { ClientConfigurationService } from "../core/client-configuration.service";
import { ServiceType } from "../core/serviceType";
import {catchError, map, Observable} from "rxjs";
import {BaseModel} from "../../models/base.model";

@Injectable({
  providedIn: 'root',
})
export class UnitsService extends BaseService<any> {

  constructor(
    httpService: HttpService,
    configService: ClientConfigurationService) {
    super(httpService, 'division', configService, UnitModel, ServiceType.units);
  }
}

