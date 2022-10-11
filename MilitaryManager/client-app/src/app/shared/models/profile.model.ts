import { BaseModel } from "./base.model";

export class ProfileModel extends BaseModel {
  public  UnitId: number | null = null;
  public  GivenById: number | null = null;
  public  DivisionId: number | null = null;
  public  GivenDate: Date  | null = null;
}
