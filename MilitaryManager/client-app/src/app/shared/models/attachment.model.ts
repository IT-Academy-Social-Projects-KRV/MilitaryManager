import { BaseModel } from "./base.model";
import { UnitModel } from "./unit.model";

export class AttachmentModel extends BaseModel {
  constructor(public override id: number | null,
              public soldier: UnitModel | null = null,
              public action: string | null = null,
              public date: Date | null = null,
              public payOff: boolean | null = null) {
    super(id);
  }
  public override get _id(): number | null{
    return this.id;
  }

  public override set _id(value: number| null){
    this.id = value;
  }
  /*
  soldier: UnitModel | null = null;
  action: string | null = null;
  date: Date | null = null;
  payOff: boolean | null = null;
  */
}
