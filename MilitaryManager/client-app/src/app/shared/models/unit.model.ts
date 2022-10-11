import { BaseModel } from "./base.model";
import {ProfileModel} from "./profile.model";
import {EquipmentModel} from "./equipment.model";
import {UnitToEquipment} from "./unitToEquipment";

export class UnitModel extends BaseModel {
  public lastName: string | null = null;
  public secondName: string | null = null;
  public label: string | null = null;
  public firstName: string | null = null;
  public divisionId: number | null = null;
  public rankId: number | null = null;
  public positionId: number | null = null;
  public parentId: number | null = null;

  public parent: UnitModel | null = null;

  public subUnits: UnitModel[] | null = null;

  public profiles: ProfileModel[] | null = null;
  public гnitToEquipments: UnitToEquipment[] | null = null;
}
