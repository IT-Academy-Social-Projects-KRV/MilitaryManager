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
      this.unitsService.collection.getAll().subscribe(units => this.units = units);
      this.loading = false;
    }, 1000);
  }

  nodeExpand(event: any) {
    if (event.node) {
      //in a real application, make a call to a remote url to load children of the current node and add the new nodes as children
      this.unitsService.single.getById(event.node.id).subscribe(nodes => {
        event.node.children = nodes});
    }
  }
/*
  nodes: TreeNode<UnitModel>[] = [];

  constructor(private unitsService: UnitStateService,
              private clientConfigService: ClientConfigurationService,
              private unitService: UnitsService) { }

  ngOnInit() {

    this.unitService.single.get().subscribe((data) => {
      this.nodes = data;
    });
 */
/*
    this.units = [
      {
        key: '0',
        label: 'Introduction',
        children: [
          {key: '0-0', label: 'What is Angular', data:'https://angular.io', type: 'url'},
          {key: '0-1', label: 'Getting Started', data: 'https://angular.io/guide/setup-local', type: 'url'},
          {key: '0-2', label: 'Learn and Explore', data:'https://angular.io/guide/architecture', type: 'url'},
          {key: '0-3', label: 'Take a Look', data: 'https://angular.io/start', type: 'url'}
        ]
      },
      {
        key: '1',
        label: 'Components In-Depth',
        children: [
          {key: '1-0', label: 'Component Registration', data: 'https://angular.io/guide/component-interaction', type: 'url'},
          {key: '1-1', label: 'User Input', data: 'https://angular.io/guide/user-input', type: 'url'},
          {key: '1-2', label: 'Hooks', data: 'https://angular.io/guide/lifecycle-hooks', type: 'url'},
          {key: '1-3', label: 'Attribute Directives', data: 'https://angular.io/guide/attribute-directives', type: 'url'}
        ]
      }
    ];
*/
}
