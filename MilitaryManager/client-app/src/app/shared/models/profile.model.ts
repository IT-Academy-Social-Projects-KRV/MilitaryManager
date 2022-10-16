import { BaseModel } from "./base.model";

export class ProfileModel extends BaseModel {
    constructor(Id:number|null=null ,
        public AttributeId: number|null=null,
        public UnitId: number|null=null,
        public Value: string|null=null){
        super(Id);
    }
}