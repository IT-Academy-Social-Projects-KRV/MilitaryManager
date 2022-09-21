import { BaseModel } from "./base.model";
import { UnitModel } from "./unit.model";

export class AttachmentModel extends BaseModel {
  soldier?: UnitModel;
  action?: string;
  date?: Date;
  payOff?: boolean;
}
