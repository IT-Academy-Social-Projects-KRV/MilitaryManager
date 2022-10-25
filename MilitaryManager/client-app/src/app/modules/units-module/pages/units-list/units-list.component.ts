import {Component, OnInit} from '@angular/core';
import {UnitModel} from 'src/app/shared/models/unit.model';
import {UnitStateService} from 'src/app/shared/services/unit-state.service';
import {UnitsService} from 'src/app/shared/services/api/unit.service';
import {ConfigModel} from "../../../../shared/models/config.model";
import {ClientConfigurationService} from "../../../../shared/services/core/client-configuration.service";
import {TreeNode} from "primeng/api";
import {BaseService} from "../../../../shared/services/core/base.service";
import {PositionService} from "../../../../shared/services/api/position.service";
import {RankService} from "../../../../shared/services/api/rank.service";
import {DivisionsService} from "../../../../shared/services/api/division.service";


@Component({
  selector: 'app-units-list',
  templateUrl: './units-list.component.html',
  styleUrls: ['./units-list.component.scss']
})
export class UnitsListComponent implements OnInit {

  units: TreeNode<UnitModel>[] = [];

  loading: boolean = false;

  constructor(
    private unitsService: UnitsService) {
  }

  ngOnInit() {
    this.loading = true;
    setTimeout(() => {
      this.unitsService.collection.getAll()
        .subscribe((units) => {
          units.forEach((unit) => {
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
        units.forEach((unit) => {
          unit.label = `${unit.lastName} ${unit.firstName}`;
          unit.expandedIcon = "pi pi-user-minus";
          unit.collapsedIcon = "pi pi-user-plus";
          unit.leaf = false;
        })
        event.node.children = units;
      });
    }
  }

  someId: number;
  public unit: UnitModel = new UnitModel(0);
  parentFullName: string = "";
  divisionName: string = "";
  rankName: string = "";
  positionName: string = "";

  nodeSelect(event: any) {

    if (event.node) {
      this.someId = event.node.id;
      // let unitInfo = new UnitInfoComponent(this.unitsService);
      // unitInfo.getSelectedUnitDataById(event.node.id)

      this.unitsService.single.getById(this.someId)
        .subscribe((u) => {
          this.unit = u;

          if (this.unit.parent != null) {
            this.parentFullName = `${this.unit?.parent?.lastName} ${this.unit?.parent?.firstName} ${this.unit?.parent?.secondName}`;
          } else {
            this.parentFullName = 'Немає';
          }

          this.divisionName = this.unit?.division.name;
          this.rankName = this.unit.rank.Name;
          this.positionName = this.unit.position.Name;

          console.log(this.unit)
          console.log(this.parentFullName);
          console.log(this.unit.profiles[0].name);
          console.log(this.unit.profiles[0].value);
        });
    }
  }
}
