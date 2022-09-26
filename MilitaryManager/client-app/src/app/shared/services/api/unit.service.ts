import { Injectable } from "@angular/core";
import { UnitModel } from "../../models/unit.model";
import { HttpService } from "../core/http.service";
import {BaseService, BaseSingleService, CoreHttpService} from "../core/base.service";
import { ClientConfigurationService } from "../core/client-configuration.service";
import { ServiceType } from "../core/serviceType";
import {catchError, map, Observable} from "rxjs";
import {BaseModel} from "../../models/base.model";

@Injectable({
  providedIn: 'root',
})
export class UnitsService extends BaseService<any> {

  constructor(
    httpService: HttpService,
    configService: ClientConfigurationService) {
    super(httpService, 'unit', configService, UnitModel, ServiceType.units);
  }

  /*
  getLazyUnits(id: number | null) {
    return this.single.getById(id);
    // .get<any>('assets/showcase/data/files-lazy.json')
    // .toPromise()
    // .then(res => <TreeNode[]>res.data);
  }
  */
}

export class UnitSingleService extends BaseSingleService<any> {
  public constructor(
    protected override httpService: HttpService,
    protected override controllerName: string,
    protected override configService: ClientConfigurationService,
    protected override createModel: new (id: number | null, Name: string | null, Address: string | null, ParentId: number | null, Parent: UnitModel | null) => UnitModel,
    protected override serviceType: ServiceType = ServiceType.web,
  ) {
    super(httpService, controllerName, configService, createModel, ServiceType.units);
  }
  private override mapModel(payload: any) {
    const model = new this.createModel(payload.id ?? null, payload.Name ?? null, payload.Address ?? null, payload.ParentId ?? null, payload.Parent ?? null);
    return model;
  }

  //???????????????????????????????????????????????????????????????????
/*
  override getById(id: number | null): Observable<UnitModel> {
    return this.httpService.get(`${this.baseUrl}${this.controllerName}/` + (id ?? ``))
      .pipe(
        map((payload: any) => this.mapModel(payload)),
        catchError(this.handleError),
      );
  }
*/
}
