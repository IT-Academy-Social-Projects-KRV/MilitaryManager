import { Injectable } from "@angular/core";
import { AttachmentsService } from "./attachment.service";
import { DecreeService } from "./decree.service";
import { PdfService } from "./pdf.service";
import { TemplateService } from "./template.service";
import { UnitUserService } from "./unit-user.service";
import { UnitsService } from "./unit.service";
import { UnitsInfoService } from "./unitInfo.service";

@Injectable()
export class ApiService {
    constructor(
        public attachments: AttachmentsService,
        public units: UnitsService,
        public decree: DecreeService,
        public templates: TemplateService,
        public pdfs: PdfService,
        public unitUser: UnitUserService,
        public unitsInfoService: UnitsInfoService,
    ) {
    }
}
