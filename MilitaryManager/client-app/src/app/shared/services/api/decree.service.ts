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
    protected configService: ClientConfigurationService) {
    super(httpService, 'decrees', configService, DecreeModel, ServiceType.attachments);
  }

  uploadSign(id: number, formData: FormData): Observable<any> {
    const baseHost = this.configService.getEnvSetting(ServiceType.attachments);
    return this.httpClient.put(`${baseHost}/api/pdfs`, formData, {reportProgress: true, observe: 'events'}) 
  }

  public download(id: number): Observable<any> { 
    const baseHost = this.configService.getEnvSetting(ServiceType.attachments);
    return this.httpClient.get(`${baseHost}/api/pdfs/${id}`, {
      reportProgress: true,
      observe: 'events',
      responseType: 'blob'
    }); 
  }

  public downloadSigned(id: number): Observable<any> { 
    const baseHost = this.configService.getEnvSetting(ServiceType.attachments);
    return this.httpClient.get(`${baseHost}/api/pdfs/signed/${id}`, {
      reportProgress: true,
      observe: 'events',
      responseType: 'blob'
    }); 
  }
}
