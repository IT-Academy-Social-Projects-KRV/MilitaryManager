import { Component, OnInit } from '@angular/core';
import {ChangeModel} from 'src/app/shared/models/change.model';
import {LogService} from "../../shared/services/api/log.service";
import {LogDetalesService} from "../../shared/services/api/logDetales.service";

@Component({
  selector: 'app-signin-redirect-callback',
  templateUrl: './log.component.html',
  styleUrls: ['./log.component.scss']
})
export class LogComponent implements OnInit {

  logs: ChangeModel[] = [];

  loading: boolean = false;

  constructor(private logService: LogService,
    private logDetalesService: LogDetalesService) { }

  ngOnInit() {
    this.loading = true;
    setTimeout(() => {
      this.logService.collection.getAll().subscribe(logs => this.logs = logs);
    });
  }

  onClick(event: any) {
    if (event.id) {
      this.logDetalesService.collection.getListById(event.id).subscribe((logValues: any) => {
        event.changeValues = logValues;
      });
    }
  }
}
