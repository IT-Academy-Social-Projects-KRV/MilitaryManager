import { BaseModel } from "./base.model";

export class TemplateModel extends BaseModel {    
    public name: string | null = null;
    public path: string | null = null;
    public typeId: number | null = null;
}