import { BaseModel } from "./base.model";

export class UserModel extends BaseModel {
    constructor(Id:number|null=null ,
        public Username:string | null=null,
        public Password: string| null=null,
        public Role:string|null=null){
        super(Id);
    }
}