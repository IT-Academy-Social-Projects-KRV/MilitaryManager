import { Injectable } from "@angular/core";
import { UnitModel } from "../../models/unit.model";
import { HttpService } from "../core/http.service";
import {BaseService, CoreHttpService} from "../core/base.service";
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

