import { BaseModel } from "./base.model";

export class PositionModel extends BaseModel {
    constructor(Id:number|null=null ,
        public Name:string | null=null){
        super(Id);
    }
}