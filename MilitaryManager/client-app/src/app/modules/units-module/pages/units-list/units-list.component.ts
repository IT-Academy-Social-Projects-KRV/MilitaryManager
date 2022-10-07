import { Component, OnInit } from '@angular/core';
import { UnitModel } from 'src/app/shared/models/unit.model';
import { UnitStateService } from 'src/app/shared/services/unit-state.service';
import { UnitsService } from 'src/app/shared/services/api/unit.service';
import {ConfigModel} from "../../../../shared/models/config.model";
import {ClientConfigurationService} from "../../../../shared/services/core/client-configuration.service";
import {TreeNode} from "primeng/api";
import {BaseService} from "../../../../shared/services/core/base.service";


@Component({
  selector: 'app-units-list',
  templateUrl: './units-list.component.html',
  styleUrls: ['./units-list.component.scss']
})
export class UnitsListComponent implements OnInit {

  units: TreeNode<UnitModel>[] = [];

  loading: boolean = false;

  constructor(private unitsService: UnitsService,
              private clientConfigService: ClientConfigurationService) { }

  ngOnInit() {
    this.loading = true;
    setTimeout(() => {
      this.unitsService.collection.getAll()
        .subscribe(  (units) => {
        units.forEach( (unit) => {
          unit.label = `${unit.lastName} ${unit.firstName}`;
          unit.expandedIcon = "pi pi-user-minus";
          unit.collapsedIcon = "pi pi-user-plus";
          unit.leaf = false;
        })
          this.units = units;
      });
      this.loading = false;
    });
  }

  nodeExpand(event: any) {
    if (event.node) {
      this.unitsService.collection.getListById(event.node.id).subscribe((units) => {
        units.forEach( (unit) => {
          unit.label = `${unit.lastName} ${unit.firstName}`;
          unit.expandedIcon = "pi pi-user-minus";
          unit.collapsedIcon = "pi pi-user-plus";
          unit.leaf = false;
        })
        event.node.children = units;
      });
    }
  }
}
