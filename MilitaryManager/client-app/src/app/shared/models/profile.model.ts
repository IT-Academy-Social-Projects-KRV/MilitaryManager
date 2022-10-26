import { BaseModel } from "./base.model";
import {AttributeModel} from "./attribute.model";
import {UnitModel} from "./unit.model";

export class ProfileModel extends BaseModel {
    constructor(
        Id:number|null=null,
        public attributeId: number|null=null,
        public unitId: number|null=null,
        public value: string|null=null,
        public attribute: AttributeModel,
        public name: string | null = null,){
        super(Id);
    }
}
