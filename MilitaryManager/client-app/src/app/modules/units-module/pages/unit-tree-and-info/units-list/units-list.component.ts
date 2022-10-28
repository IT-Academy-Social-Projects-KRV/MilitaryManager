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

  unit: UnitModel = new UnitModel(0);
  parentFullName: string = "";
  divisionName: string = "";


  nodeSelect(event: any) {

    if (event.node) {

      this.idChild2 = event.node.id;
      // console.log(this.idChild2);

      // this.idCHANGE2.emit(this.idChild2);

      // this.unitsService.single.getById(event.node.id)
      //   .subscribe((u) => {
      //     this.idChild2 = u;
      //
      //
      //     // if (this.unit.parent != null) {
      //     //   this.parentFullName = `${this.unit?.parent?.lastName} ${this.unit?.parent?.firstName} ${this.unit?.parent?.secondName}`;
      //     // } else {
      //     //   this.parentFullName = 'Немає';
      //     // }
      //     //
      //     // this.divisionName = this.unit?.division.name;
      //
      //
      //     // console.log(this.unit)
      //     // console.log(this.unit.profiles[0].name);
      //     // console.log(this.unit.profiles[0].value);
      //   });

      this.idCHANGE2.emit(this.idChild2);
    }
  }


  idChild2 : number;

  @Output() idCHANGE2: EventEmitter<number> = new EventEmitter();

  click() {
    // this.idChild2 = this.unit.id;

    console.log('this.idChild2');
    console.log(this.idChild2);
    // this.idCHANGE2.emit(this.idChild2);
  }



  sendId() {

  }
}
