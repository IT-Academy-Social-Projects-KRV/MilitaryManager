import { AttachmentsService } from "./api/attachment.service";
import { ConfigService } from "./api/config.service";
import { UnitsService } from "./api/unit.service";
import { HttpService } from "./core/http.service";
import { ClientConfigurationService } from "./core/client-configuration.service";
import { ApiService } from "./api/api.service";
import { DecreeService } from "./api/decree.service";
import { TemplateService } from "./api/template.service";

export const services = [
    HttpService,
    ClientConfigurationService,
    ConfigService,
    AttachmentsService,
    UnitsService,
    DecreeService,
    TemplateService,
    ApiService
]
