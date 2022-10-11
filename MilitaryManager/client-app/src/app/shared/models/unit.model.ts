import { BaseModel } from "./base.model";

export class UnitModel extends BaseModel {
  public lastName: string | null = null;
  public firstName: string | null = null;
  public divisionId: number | null = null;
  public rankId: number | null = null;
  public positionId: number | null = null;
  public parentId: number | null = null;

  public parent: UnitModel | null = null;

  public subUnits: UnitModel[] | null = null;

  constructor(Id:number|null=null ,
     lastName:string | null=null,
     firstName: string| null=null,
     divisionId:number|null=null,
     rankId: number | null = null,
     positionId: number | null = null,
     parentId: number | null = null
    ){
    super(Id);
}

}
