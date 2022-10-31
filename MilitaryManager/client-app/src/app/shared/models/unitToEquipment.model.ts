import {BaseModel} from "./base.model";
import {EntityModel} from "./entity.model";
import {UnitModel} from "./unit.model";

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
  public Name: string | null = null;
  public Value: string | null = null;
}
