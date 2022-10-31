import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {UnitModel} from 'src/app/shared/models/unit.model';
import {UnitsService} from 'src/app/shared/services/api/unit.service';
import {TreeNode} from "primeng/api";


@Component({
  selector: 'app-units-list',
  templateUrl: './units-list.component.html',
  styleUrls: ['./units-list.component.scss']
})
export class UnitsListComponent implements OnInit {

  units: TreeNode<UnitModel>[] = [];

  loading: boolean = false;
  parentFullName: string = "";
  divisionName: string = "";
  idInUnitList: number;
  @Output() outputIdChangedInUnitListComponent: EventEmitter<number> = new EventEmitter();

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

  nodeSelect(event: any) {
    if (event.node) {
      this.idInUnitList = event.node.id;
      this.outputIdChangedInUnitListComponent.emit(this.idInUnitList);
    }
  }
}
