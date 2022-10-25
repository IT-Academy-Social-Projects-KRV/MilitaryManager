import { BaseModel } from "./base.model";
import { UnitModel } from "./unit.model";

export class AttachmentModel extends BaseModel {
  soldier: UnitModel | null = null;
  decreeNumber: string | null = null;
  action: string | null = null;
  currentDate: Date | null = null;
  payOff: boolean | null = null;
}
