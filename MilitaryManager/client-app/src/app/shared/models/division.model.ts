import { BaseModel } from "./base.model";

export class DivisionModel extends BaseModel {
  public name: string | null = null;
  public address: string | null = null;
  public parentId: number | null = null;

  public parent: DivisionModel | null = null;

  public subDivisions: DivisionModel[] | null = null;
}
