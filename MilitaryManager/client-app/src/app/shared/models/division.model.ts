import { BaseModel } from "./base.model";

export class DivisionModel extends BaseModel {

  public parent: DivisionModel | null = null;

  public subDivisions: DivisionModel[] | null = null;

  constructor(Id:number|null=null,
    public name: string | null = null,
    public divisionNumber: string | null = null,
    public address: string | null = null,
    public parentId: number | null = null) {
    super(Id);
    
  }
}
