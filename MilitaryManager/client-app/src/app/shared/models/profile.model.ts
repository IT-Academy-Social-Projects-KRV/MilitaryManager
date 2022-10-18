import {BaseModel} from "./base.model";
import {AttributeModel} from "./attribute.model";
import {UnitModel} from "./unit.model";

export class ProfileModel extends BaseModel {
  // public AttributeId: number | null = null;
  // public UnitId: number | null = null;
  // public Value: string | null = null;
  //
  public attribute: AttributeModel;
  // public Unit: UnitModel;

  public name: string | null = null;
  public value: string | null = null;
}
