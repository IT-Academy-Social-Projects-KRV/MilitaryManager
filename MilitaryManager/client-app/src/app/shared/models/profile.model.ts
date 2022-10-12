import {BaseModel} from "./base.model";
import {AttributeModel} from "./attribute.model";
import {UnitModel} from "./unit.model";

export class ProfileModel extends BaseModel {
  public AttributeId: number | null = null;
  public UnitId: number | null = null;
  public Value: string | null = null;

  public Attribute: AttributeModel;
  public Unit: UnitModel;
}
