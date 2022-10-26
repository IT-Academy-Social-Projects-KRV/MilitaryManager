import { AttributeModel } from "./attribute.model";
import { BaseModel } from "./base.model";
import { EntityModel } from "./entity.model";

export class EntityToAttributeModel extends BaseModel {
  public enityId: number | null = null;
  public attributeId: number | null = null;
  public value: string | null = null;
  public attributeName: string | null = null;
}
