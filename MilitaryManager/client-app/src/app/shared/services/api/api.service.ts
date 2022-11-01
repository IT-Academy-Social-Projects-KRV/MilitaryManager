import { Injectable } from "@angular/core";
import { AttachmentsService } from "./attachment.service";
import { DecreeService } from "./decree.service";
import { DivisionsService } from "./division.service";
import { PdfService } from "./pdf.service";
import { TemplateService } from "./template.service";
import { UnitUserService } from "./unit-user.service";
import { UnitsService } from "./unit.service";
import {RankService} from "./rank.service";
import {PositionService} from "./position.service";
import {AuthService} from "../auth.service";
import {AttributeService} from "./attribute.service";
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
        public ranks: RankService,
        public positions: PositionService,
        public auth: AuthService,
        public attributes: AttributeService,
        public unitsInfoService: UnitsInfoService,
        public divisionService: DivisionsService,
    ) {
    }
}
