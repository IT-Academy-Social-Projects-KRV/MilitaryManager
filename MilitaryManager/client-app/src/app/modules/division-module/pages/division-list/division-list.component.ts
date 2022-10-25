import { Component, OnInit } from '@angular/core';
import { DivisionsService } from 'src/app/shared/services/api/division.service';
import {ClientConfigurationService} from "../../../../shared/services/core/client-configuration.service";
import {TreeNode} from "primeng/api";
import {DivisionModel} from "../../../../shared/models/division.model";


@Component({
  selector: 'app-units-list',
  templateUrl: './division-list.component.html',
  styleUrls: ['./division-list.component.scss']
})
export class DivisionListComponent implements OnInit {

  divisions: TreeNode<DivisionModel>[] = [];

  loading: boolean = false;
  selectedId: number = 0;
  public division: DivisionModel = new DivisionModel();

  constructor(private divisionsService: DivisionsService,
              private clientConfigService: ClientConfigurationService) { }

  ngOnInit() {
    this.loading = true;
    setTimeout(() => {
      this.divisionsService.collection.getAll()
        .subscribe(  (divisions) => {
          divisions.forEach( (division) => {
          this.recursiveTree(division)
        })
          this.divisions = divisions;
      });
      this.loading = false;
    });
  }

  recursiveTree(division: any){
    division.label = division.name;
    division.expandedIcon = "pi pi-user-minus";
    division.collapsedIcon = "pi pi-user-plus";
    division.subDivisions.forEach((subDivision: any) => {
      this.recursiveTree(subDivision);
    });
    division.children = division.subDivisions;
  }

  nodeSelect(event: any) {

    if (event.node) {
      this.selectedId = event.node.id;

      this.divisionsService.single.getById(this.selectedId)
        .subscribe((division) => {
          this.division = division;
        });
    }
  }
}
