import { BaseModel } from "./base.model";
import {ChangeValuesModel} from "./changeValues.model";

export class ChangeModel extends BaseModel {
  public tableName: string | null = null;
  public userId: number | null = null;
  public rowId: number | null = null;
  public date: Date  | null = null;
  public changeTypeCode: string | null = null;

  public changeValues: ChangeValuesModel[] | null = null;
}
