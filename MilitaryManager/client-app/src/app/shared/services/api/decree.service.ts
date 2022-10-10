import { Injectable } from "@angular/core";
import { HttpService } from "../core/http.service";
import { BaseService } from "../core/base.service";
import { ClientConfigurationService } from "../core/client-configuration.service";
import { ServiceType } from "../core/serviceType";
import { DecreeModel } from "../../models/decree.model";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class DecreeService extends BaseService<any> {
  constructor(
    httpService: HttpService,
    private httpClient: HttpClient,
    configService: ClientConfigurationService) {
    super(httpService, 'decrees', configService, DecreeModel, ServiceType.attachments);
  }

  public completeDecree(id: number): Observable<any> { 
    return this.httpClient.put(`${this.single.baseUrl}decrees/complete/${id}`, {}); 
  }
}
