import { BaseModel } from "./base.model";

export class RankModel extends BaseModel {
    constructor(Id:number|null=null ,
        public Name:string | null=null){
        super(Id);
    }
}