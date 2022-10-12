import { Injectable } from "@angular/core";
import { UnitModel } from "../../models/unit.model";
import { HttpService } from "../core/http.service";
import { BaseService } from "../core/base.service";
import { ClientConfigurationService } from "../core/client-configuration.service";
import { ServiceType } from "../core/serviceType";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root',
})
export class UnitsService extends BaseService<any> {

  constructor(
    httpService: HttpService,
    private httpClient: HttpClient,
    configService: ClientConfigurationService) {
    super(httpService, 'unit', configService, UnitModel, ServiceType.units);
  }

  getAll(): Observable<any> {
    console.log(this.collection.baseUrl)
    return this.httpClient.get(`${this.collection.baseUrl}unit/collection/info`);
}
}

