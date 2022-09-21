export abstract class BaseModel {
    constructor(
        public id: number | null) {
    }

    /*public get _id(): number | null{
        return this.id;
    }

    public set _id(value: number| null) {
        this.id = value;
    }*/
}
