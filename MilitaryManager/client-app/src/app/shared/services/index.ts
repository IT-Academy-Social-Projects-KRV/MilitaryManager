import { AttachmentsService } from "./api/attachment.service";
import { ConfigService } from "./api/config.service";
import { UnitsService } from "./api/unit.service";
import { HttpService } from "./core/http.service";
import { ClientConfigurationService } from "./core/client-configuration.service";
import { ApiService } from "./api/api.service";
import { UnitUserService } from "./api/unit-user.service";
import { DecreeService } from "./api/decree.service";
import { TemplateService } from "./api/template.service";
import { PdfService } from "./api/pdf.service";
import { UnitsInfoService } from "./api/unitInfo.service";
import { DivisionsService } from "./api/division.service";

export const services = [
    HttpService,
    ClientConfigurationService,
    ConfigService,
    AttachmentsService,
    UnitsService,
    DecreeService,
    TemplateService,
    PdfService,
    ApiService,
    UnitUserService,
    UnitsInfoService,
    DivisionsService,
]
