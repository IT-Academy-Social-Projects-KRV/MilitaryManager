import { Injectable } from "@angular/core";
import { HttpService } from "../core/http.service";
import { BaseService } from "../core/base.service";
import { ClientConfigurationService } from "../core/client-configuration.service";
import { ServiceType } from "../core/serviceType";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { PdfModel } from "../../models/pdf.model";

@Injectable()
export class PdfService extends BaseService<any> {
  constructor(
    httpService: HttpService,
    private httpClient: HttpClient,
    configService: ClientConfigurationService) {
    super(httpService, 'pdfs', configService, PdfModel, ServiceType.attachments);
  }

  public uploadSign(formData: FormData): Observable<any> {
    return this.httpClient.put(`${this.single.baseUrl}pdfs`, formData, { reportProgress: true, observe: 'events' }) 
  }

  public download(id: number): Observable<any> { 
    return this.httpClient.get(`${this.single.baseUrl}pdfs/${id}`, {
      reportProgress: true,
      observe: 'events',
      responseType: 'blob'
    }); 
  }

  public downloadSigned(id: number): Observable<any> { 
    return this.httpClient.get(`${this.single.baseUrl}pdfs/signed/${id}`, {
      reportProgress: true,
      observe: 'events',
      responseType: 'blob'
    }); 
  }

  public completeDecree(id: number): Observable<any> { 
    return this.httpClient.put(`${this.single.baseUrl}decrees/complete/${id}`, {}); 
  }
}
