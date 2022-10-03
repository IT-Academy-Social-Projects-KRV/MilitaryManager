import { BaseModel } from "./base.model";

export class UnitModel extends BaseModel {
  /*
  constructor(
    public Id: number | null = null,
    public Name: string | null = null,
    public Address: string | null = null,
    public ParentId: number | null = null,
    public Parent: UnitModel | null = null,
    public SubUnits: UnitModel[] | null = null) {
    super(Id);
  }*/
  public lastName: string | null = null;
  public label: string | null = null;
  public firstName: string | null = null;
  public divisionId: number | null = null;
  public rankId: number | null = null;
  public positionId: number | null = null;
  public parentId: number | null = null;

  public parent: UnitModel | null = null;

  public subUnits: UnitModel[] | null = null;
}
