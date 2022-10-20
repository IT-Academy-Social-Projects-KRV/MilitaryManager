import { BaseModel } from "./base.model";

export class AttributeModel extends BaseModel {
    constructor(Id:number|null=null ,
        public name:string | null=null){
        super(Id);
    }
}