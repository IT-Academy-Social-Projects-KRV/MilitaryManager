import { catchError, map, Observable } from 'rxjs';
import { BaseModel } from '../../models/base.model';
import { HttpService } from './http.service';
import { ClientConfigurationService } from './client-configuration.service';
import { ServiceType } from './serviceType';

export abstract class CoreHttpService {
    public static onHandleError: (error: any) => void;

    protected constructor(
        protected httpService: HttpService,
        protected controllerName: string,
        protected configService: ClientConfigurationService,
        protected serviceType: ServiceType = ServiceType.web
    ) {
    }

    public get baseUrl() {
        const baseHost = this.configService.getEnvSetting(this.serviceType);
        if (baseHost) {
            return `${baseHost}${this.configService.getEnvSetting('webserverApiPath')}`;
        } else {
            return this.configService.getEnvSetting('webserverApiPath');
        }
    }

    protected handleError(error: any): never {
        if (CoreHttpService.onHandleError) {
            CoreHttpService.onHandleError(error);
        }
        throw error;
    }
}

export abstract class BaseService<TModel extends BaseModel>  {
    public single: BaseSingleService<TModel>;
    public collection: BaseCollectionService<TModel>;

    protected constructor(
        HttpService: HttpService,
        controllerName: string,
        ConfigService: ClientConfigurationService,
        createModel: new (id: number | null) => TModel,
        serviceType: ServiceType = ServiceType.web,
    ) {
        this.single = new BaseSingleService<TModel>(HttpService, controllerName, ConfigService, createModel, serviceType);
        this.collection = new BaseCollectionService<TModel>(HttpService, `collection/${controllerName}`, ConfigService, createModel, serviceType);
    }
}

class BaseCollectionService<TModel extends BaseModel> extends CoreHttpService {
    public constructor(
        protected override httpService: HttpService,
        protected override controllerName: string,
        protected override configService: ClientConfigurationService,
        protected createModel: new (id: number | null) => TModel,
        protected override serviceType: ServiceType = ServiceType.web,
    ) {
        super(httpService, controllerName, configService, serviceType);
    }

    private mapModel(payload: any): TModel {
        const model = new this.createModel(payload.id ?? null);
        // TODO: Implement set payload function fo models or use parsing revivers
        // or use lodash to parse json objects
        // model.setPayload(payload);
        // Example JSON.parse({}, reviverExtensions.defaultReviver)

        Object.assign(model, payload);
        return model;
    }

    getAll(): Observable<TModel[]> {
        return this.httpService.get(`${this.baseUrl}${this.controllerName}`)
            .pipe(
                map((payloads: any) => payloads.map(this.mapModel)),
                catchError(this.handleError)
            );
    }
}

class BaseSingleService<TModel extends BaseModel> extends CoreHttpService {
    public constructor(
        protected override httpService: HttpService,
        protected override controllerName: string,
        protected override configService: ClientConfigurationService,
        protected createModel: new (id: number | null) => TModel,
        protected override serviceType: ServiceType = ServiceType.web,
    ) {
        super(httpService, controllerName, configService, serviceType);
    }

    private mapModel(payload: any): TModel {
        const model = new this.createModel(payload.id ?? null);
        return model;
    }

    get(): Observable<TModel> {
        return this.httpService.get(`${this.baseUrl}${this.controllerName}`)
            .pipe(
                map((payload: any) => this.mapModel(payload)),
                catchError(this.handleError)
            );
    }

    create(record: TModel): Observable<TModel> {
        return this.httpService.post(`${this.baseUrl}${this.controllerName}`, record)
            .pipe(
                map((payload: any) => this.mapModel(payload)),
                catchError(this.handleError),
            );
    }

    update(record: TModel): Observable<TModel> {
        return this.httpService.put(`${this.baseUrl}${this.controllerName}`, record)
            .pipe(
                map((payload: any) => this.mapModel(payload)),
                catchError(this.handleError),
            );
    }

    getById(id: number): Observable<TModel> {
        return this.httpService.get(`${this.baseUrl}${this.controllerName}/${id}`)
            .pipe(
                map((payload: any) => this.mapModel(payload)),
                catchError(this.handleError),
            );
    }

    deleteById(id: number): Observable<TModel> {
        return this.httpService.delete(`${this.baseUrl}${this.controllerName}/${id}`)
            .pipe(
                map((payload: any) => this.mapModel(payload)),
                catchError(this.handleError),
            );
    }
}
