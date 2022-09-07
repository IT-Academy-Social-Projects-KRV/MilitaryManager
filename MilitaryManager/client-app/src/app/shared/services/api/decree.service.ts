import { Injectable } from "@angular/core";
import { HttpService } from "../core/http.service";
import { BaseService } from "../core/base.service";
import { ClientConfigurationService } from "../core/client-configuration.service";
import { ServiceType } from "../core/serviceType";
import { DecreeModel } from "../../models/decree.model";
import { Observable } from "rxjs";
import { HttpClient, HttpHeaders } from "@angular/common/http";

@Injectable()
export class DecreeService extends BaseService<any> {
  constructor(
    httpService: HttpService,
    protected httpClient: HttpClient,
    configService: ClientConfigurationService) {
    super(httpService, 'decree', configService, DecreeModel, ServiceType.attachments);
  }

  uploadSign(id: number, formData: FormData): Observable<any> {
    const headersConfig = {
      'Content-Type': 'application/json'
    };
    return this.httpClient.post(`https://localhost:5003/api/decree/pdf/upload/${id}`, formData, {headers : new HttpHeaders(headersConfig), reportProgress: true, observe: 'events'})    
    
    //return this.httpClient.post(`https://www.googleapis.com/upload/drive/v3/files?uploadType=media`, formData, {headers : new HttpHeaders(headersConfig), reportProgress: true, observe: 'events'})    
  }
}
