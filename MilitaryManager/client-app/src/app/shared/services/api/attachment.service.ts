import { Injectable } from "@angular/core";
import { AttachmentModel } from "../../models/attachment.model";
import { HttpService } from "../core/http.service";
import { BaseService } from "../core/base.service";
import { ClientConfigurationService } from "../core/client-configuration.service";
import { ServiceType } from "../core/serviceType";

@Injectable()
export class AttachmentsService extends BaseService<any> {
  constructor(
    httpService: HttpService,
    configService: ClientConfigurationService) {
    super(httpService, 'weatherForecast', configService, AttachmentModel, ServiceType.attachments);
  }
}
