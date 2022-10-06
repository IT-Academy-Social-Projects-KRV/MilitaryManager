import { Component, OnInit } from '@angular/core';
import { UnitModel } from 'src/app/shared/models/unit.model';
import { UnitsService } from 'src/app/shared/services/api/unit.service';
import {ClientConfigurationService} from "../../../../shared/services/core/client-configuration.service";
import {TreeNode} from "primeng/api";


@Component({
  selector: 'app-units-list',
  templateUrl: './division-list.component.html',
  styleUrls: ['./division-list.component.scss']
})
export class DivisionListComponent implements OnInit {

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


  recursiveTree(division: any){
    division.label = division.name;
    division.expandedIcon = "pi pi-user-minus";
    division.collapsedIcon = "pi pi-user-plus";
    division.leaf = false;
    division.children = division.subDivisions.forEach((subDivision: any) => {
      this.recursiveTree(subDivision);
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
