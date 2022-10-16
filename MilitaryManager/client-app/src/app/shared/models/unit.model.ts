import { BaseModel } from "./base.model";
import { ProfileModel } from "./profile.model";

export class UnitModel extends BaseModel {
  public parent: UnitModel | null = null;

  public subUnits: UnitModel[] | null = null;

  constructor(Id:number|null=null ,
    public lastName:string | null=null,
    public firstName: string| null=null,
    public secondName: string| null=null,
    public divisionId:number|null=null,
    public rankId: number | null = null,
    public positionId: number | null = null,
    public parentId: number | null = null,
    public profiles: ProfileModel[]|null = null,
    ){
    super(Id);
}

}
