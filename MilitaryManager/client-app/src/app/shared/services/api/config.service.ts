import { Injectable } from "@angular/core";
import { ConfigModel } from "../../models/config.model";
import { HttpService } from "../core/http.service";
import { BaseService } from "../core/base.service";
import { ClientConfigurationService } from "../core/client-configuration.service";

@Injectable()
export class ConfigService extends BaseService<ConfigModel> {
  constructor(
    httpService: HttpService,
    configService: ClientConfigurationService) {
    super(httpService, 'config', configService, ConfigModel);
  }
}
