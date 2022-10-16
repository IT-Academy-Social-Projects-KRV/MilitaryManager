import { BaseModel } from "./base.model";

export class ProfileModel extends BaseModel {
    constructor(Id:number|null=null ,
        public attributeId: number|null=null,
        public unitId: number|null=null,
        public value: string|null=null){
        super(Id);
    }
}