import { BaseModel } from "./base.model";
import { DivisionModel } from "./division.model";

export class UnitModel extends BaseModel {
  public lastName: string | null = null;
  public firstName: string | null = null;
  public secondName: string | null = null;
  public divisionId: number | null = null;
  public rankId: number | null = null;
  public positionId: number | null = null;
  public parentId: number | null = null;

  public division: DivisionModel | null = null;
  public parent: UnitModel | null = null;

  public subUnits: UnitModel[] | null = null;
}

