import { Injectable } from "@angular/core";
import { HttpService } from "../core/http.service";
import { BaseService } from "../core/base.service";
import { ClientConfigurationService } from "../core/client-configuration.service";
import { ServiceType } from "../core/serviceType";
import {catchError, map, Observable} from "rxjs";
import {BaseModel} from "../../models/base.model";
import { DivisionModel } from "../../models/division.model";

@Injectable({
  providedIn: 'root',
})
export class DivisionsService extends BaseService<any> {

  constructor(
    private httpService: HttpService,
    configService: ClientConfigurationService) {
    super(httpService, 'division', configService, DivisionModel, ServiceType.units);
  }

  GetAllDivisions() {
    return this.httpService.get(`${this.collection.baseUrl}Division/list`);
  }

}

