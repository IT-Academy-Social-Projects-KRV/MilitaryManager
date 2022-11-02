import {BaseModel} from "./base.model";
import {ProfileModel} from "./profile.model";
import {UnitToEquipmentModel} from "./unitToEquipment.model";
import {DivisionModel} from "./division.model";
import {RankModel} from "./rank.model";
import {PositionModel} from "./position.model";
import {EntityModel} from "./entity.model";

export class UnitModel extends BaseModel {


  constructor(
    Id: number | null = null,
    public lastName: string | null = null,
    public firstName: string | null = null,
    public secondName: string | null = null,
    public rankId: number | null = null,
    public rank: string | null = null,
    public positionId: number | null = null,
    public position: string | null = null,
    public parentId: number | null = null,
    public profiles: ProfileModel[] | null = null,
    public label: string | null = null,
    public division: DivisionModel | null = null,
    public parent: UnitModel | null = null,
    public subUnits: UnitModel[] | null = null,
    public unitToEquipments: UnitToEquipmentModel[] | null = null,
    public entities: EntityModel[] | null = null


  ) {
    super(Id);
  }

}
