import { Component, OnInit } from '@angular/core';
import { UnitStateService } from 'src/app/shared/services/unit-state.service';
import { UnitModel } from 'src/app/shared/models/unit.model';

@Component({
  selector: 'app-units-list',
  templateUrl: './units-list.component.html',
  styleUrls: ['./units-list.component.scss']
})
export class UnitsListComponent implements OnInit {

  constructor(private unitsService: UnitStateService) { }

  ngOnInit(): void {
  }

}
