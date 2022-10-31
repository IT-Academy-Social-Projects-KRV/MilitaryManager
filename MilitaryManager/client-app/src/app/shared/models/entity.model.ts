import { BaseModel } from "./base.model";
import { DivisionModel } from "./division.model";
import { EntityToAttributeModel } from "./entityToAttribute.model";
import { UnitModel } from "./unit.model";

export class EntityModel extends BaseModel {
  public regNum: string | null = null;
  public division: DivisionModel | null = null;
  public givenDate: Date | null = null;

  public unit: UnitModel | null = null;
  public warehouseman: UnitModel | null = null;
  public entityToAttributes: EntityToAttributeModel[] | null = null;
}
