import { Component, OnInit } from '@angular/core';
import { DivisionsService } from 'src/app/shared/services/api/division.service';
import {ClientConfigurationService} from "../../../../shared/services/core/client-configuration.service";
import {MessageService, TreeNode} from "primeng/api";
import {DivisionModel} from "../../../../shared/models/division.model";


@Component({
  selector: 'app-units-list',
  templateUrl: './division-list.component.html',
  styleUrls: ['./division-list.component.scss']
})
export class DivisionListComponent implements OnInit {

  divisions: TreeNode<DivisionModel>[] = [];

  isReadOnly = true
  loading: boolean = false;
  public division: DivisionModel = new DivisionModel();
  clonedDivision: { [s: string]: DivisionModel; } = {};

  constructor(private divisionsService: DivisionsService,
              private clientConfigService: ClientConfigurationService,
              private messageService: MessageService) { }

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
      this.divisionsService.single.getById(event.node.id)
        .subscribe((division) => {
          this.division = division;
        });
    }
  }

  edit(division: DivisionModel){
    this.isReadOnly = false;
    let editDivision = new DivisionModel(division.id, division.name, 
      division.divisionNumber, division.address);
    this.clonedDivision[division.id] = editDivision;
  }

  save(){
    this.isReadOnly = true;
    this.divisionsService.single.update(this.division).subscribe(
      () =>  this.messageService.add({ severity: 'success', summary: 'Частину відредаговано' }),
      () => this.messageService.add({ severity: 'error', summary: 'Виникла помилка!'})
    );
  }

  cancel(id: number){
    this.isReadOnly = true;
    this.division = this.clonedDivision[id];
  }
}
