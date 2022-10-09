import {Component, OnInit} from '@angular/core';
import {UnitModel} from "../../../../shared/models/unit.model";
import {UnitsService} from "../../../../shared/services/api/unit.service";
import {ClientConfigurationService} from "../../../../shared/services/core/client-configuration.service";
import {map, Observable, pipe} from "rxjs";

@Component({
  selector: 'app-unit-info',
  templateUrl: './unit-info.component.html',
  styleUrls: ['./unit-info.component.scss']
})
export class UnitInfoComponent implements OnInit {

  constructor(private unitsService: UnitsService,
              private clientConfigService: ClientConfigurationService) {
  }

  // private nameInput = document.querySelector('#inputFirstName');
  public unit: UnitModel = new UnitModel(0);
  loading: boolean = false;

  // nameInput = document.querySelector('#inputFirstName');

  ngOnInit(): void {
    this.loading = true;


    this.loading = false;
  }

  pushTheButton(): void {
    let nameInput = document.querySelector('#inputFirstName');

    // @ts-ignore
    nameInput.value = '';

    this.unitsService.GetUnitUser(9)
      .subscribe((u) => {
        this.unit = u;

        // @ts-ignore
        nameInput.value = this.unit.firstName;
      });

    // .map((u) => {
    //   let unit = new UnitModel(u.id);
    //   return unit});
  }

  getSelectedUnitData(): void {
    console.log(this.unit.id);

    let nameInput = document.querySelector('#inputFirstName');

    // @ts-ignore
    let aaa = document.activeElement.innerHTML;
    //
    console.log(aaa)

    // @ts-ignore
    nameInput.value = '2';
    // @ts-ignore
    // this.nameInput.value = aaa;
  }
}
