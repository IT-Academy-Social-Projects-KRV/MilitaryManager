import { Component, OnInit } from '@angular/core';
import {ChangeModel} from 'src/app/shared/models/change.model';
import {LogService} from "../../shared/services/api/log.service";
import {LogDetailsService} from "../../shared/services/api/logDetails.service";

@Component({
  selector: 'app-log-callback',
  templateUrl: './log.component.html',
  styleUrls: ['./log.component.scss']
})
export class LogComponent implements OnInit {

  logs: ChangeModel[] = [];

  loading: boolean = false;

  constructor(private logService: LogService,
    private logDetailsService: LogDetailsService) { }

  ngOnInit() {
    this.loading = true;
    setTimeout(() => {
      this.logService.collection.getAll().subscribe(logs => this.logs = logs);
    });
  }

  onClick(event: any) {
    if (event.id) {
      this.logDetailsService.collection.getListById(event.id).subscribe((logValues: any) => {
        event.changeValues = logValues;
      });
    }
  }
}
