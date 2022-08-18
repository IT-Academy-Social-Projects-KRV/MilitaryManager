import { Injectable } from "@angular/core";
import { AttachmentsService } from "./attachment.service";
import { UnitsService } from "./unit.service";

@Injectable()
export class ApiService {
    constructor(
        public attachments: AttachmentsService,
        public units: UnitsService
    ) {
    }
}
