import { Injectable } from "@angular/core";
import { AttachmentsService } from "./attachment.service";
import { DecreeService } from "./decree.service";
import { TemplateService } from "./template.service";
import { UnitsService } from "./unit.service";

@Injectable()
export class ApiService {
    constructor(
        public attachments: AttachmentsService,
        public units: UnitsService,
        public decree: DecreeService,
        public templates: TemplateService
    ) {
    }
}
