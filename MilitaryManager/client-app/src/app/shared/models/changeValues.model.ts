import { BaseModel } from "./base.model";

export class ChangeValuesModel extends BaseModel {
  public oldValue: string | null = null;
  public columnName: string | null = null;
  public changeId: number | null = null;
  public newValue: string | null = null;
}
