import { AttachmentsService } from "./api/attachment.service";
import { ConfigService } from "./api/config.service";
import { UnitsService } from "./api/unit.service";
import { HttpService } from "./core/http.service";
import { ClientConfigurationService } from "./core/client-configuration.service";
import { ApiService } from "./api/api.service";
import { UnitUserService } from "./api/unit-user.service";

export const services = [
    HttpService,
    ClientConfigurationService,
    ConfigService,
    AttachmentsService,
    UnitsService,
    ApiService,
    UnitUserService
]
