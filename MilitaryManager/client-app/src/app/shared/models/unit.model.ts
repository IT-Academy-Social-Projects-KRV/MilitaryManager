import { BaseModel } from "./base.model";

export class UnitModel extends BaseModel {
  public Name: string | null = null;
  public Address: string | null = null;
  public ParentId: bigint | null = null;

  public Parent: UnitModel | null = null;

  public SubUnits: UnitModel[] | null = null;
}
