import { BaseModel } from "./base.model";

export class LogModel extends BaseModel {
  public tableName: string | null = null;
  public columnName: string | null = null;
  public userId: number | null = null;
  public rowId: number | null = null;
  public date: Date  | null = null;
}
