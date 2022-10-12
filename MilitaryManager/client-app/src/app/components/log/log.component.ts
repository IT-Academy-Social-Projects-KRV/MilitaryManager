import { Component, OnInit } from '@angular/core';
import {LogModel} from 'src/app/shared/models/log.model';
import {UnitsService} from "../../shared/services/api/unit.service";
import {ClientConfigurationService} from "../../shared/services/core/client-configuration.service";
import {LogService} from "../../shared/services/api/log.service";

@Component({
  selector: 'app-signin-redirect-callback',
  templateUrl: './log.component.html',
  styleUrls: ['./log.component.scss']
})
export class LogComponent implements OnInit {

  logs: LogModel[] = [];

  loading: boolean = false;

  constructor(private logService: LogService) { }

  ngOnInit() {
    this.loading = true;
    setTimeout(() => {
      this.logService.collection.getAll().subscribe(logs => this.logs = logs);
    });
  }

/*
  nodeExpand(event: any) {
    if (event.node) {
      this.logService.collection.getListById(event.node.id).subscribe((units) => {
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
  */
}
