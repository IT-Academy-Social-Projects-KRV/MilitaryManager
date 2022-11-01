import {BaseModel} from "./base.model";
import {EntityModel} from "./entity.model";
import {UnitModel} from "./unit.model";

interface AttributeWithValueDTO{
  Id : number| null;
  Name : string| null;
  Value : string| null;

}

export class UnitToEquipmentModel extends BaseModel {
  public UnitId: number | null = null;
  public GivenById: number | null = null;
  public DivisionId: number | null = null;
  public GivenDate: Date | null = null;

  public Unit: UnitModel | null = null;
  public Equipment: EntityModel | null = null;

  public RegNum: string | null = null;
  public GivenByName: string | null = null;
  public DivisionName: string | null = null;

  public NameValue: AttributeWithValueDTO[] | null = null;
}
