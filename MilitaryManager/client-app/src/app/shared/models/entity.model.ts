import { BaseModel } from "./base.model";
import { EntityToAttributeModel } from "./entityToAttribute.model";
import { UnitModel } from "./unit.model";

export class EntityModel extends BaseModel {
  public regNum: string | null = null;
  public divisionName: string | null = null;
  public givenDate: Date | null = null;

  public unit: UnitModel | null = null;
  public warehouseman: UnitModel | null = null;
  public entityToAttributes: EntityToAttributeModel[] | null = null;
}
