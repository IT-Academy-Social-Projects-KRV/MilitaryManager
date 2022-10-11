import { Component, OnInit } from '@angular/core';
import { UnitStateService } from 'src/app/shared/services/unit-state.service';

@Component({
  selector: 'app-unit-edit',
  templateUrl: './division-edit.component.html',
  styleUrls: ['./division-edit.component.scss']
})
export class DivisionEditComponent implements OnInit {

  constructor(private unitsService: UnitStateService) { }

  ngOnInit(): void {
  }

}
