import {Component, OnInit} from '@angular/core';
import {UnitModel} from "../../../../shared/models/unit.model";
import {UnitsService} from "../../../../shared/services/api/unit.service";
import {ClientConfigurationService} from "../../../../shared/services/core/client-configuration.service";
import {Observable} from "rxjs";

@Component({
  selector: 'app-unit-info',
  templateUrl: './unit-info.component.html',
  styleUrls: ['./unit-info.component.scss']
})
export class UnitInfoComponent implements OnInit {

  unit: UnitModel = new UnitModel(0);
  loading: boolean = false;

  a = new Observable<UnitModel>();

  constructor(private unitsService: UnitsService,
              private clientConfigService: ClientConfigurationService) {
  }

  ngOnInit(): void {
    // this.loading = true;

    // this.unit = this.unitsService.single.getById(5)
    //   .pipe()
    //   .map(function(u: any): UnitModel {
    //   return new UnitModel(u.firstName);
    //   });

      // .subscribe(u)



    // this.loading = false;
  }
}
