import { BaseModel } from "./base.model";

export class DecreeModel extends BaseModel {    
    public name: string | null = null;
    public path: string | null = null;
    public pathSigned: string | null = null;
    public createdBy: string | null = null;
    public timeStamp: Date | null = null;
    public templateId: number | null = null;
    public template: string | null = null;
    public statusId: number | null = null;
    public status: string | null = null;
}