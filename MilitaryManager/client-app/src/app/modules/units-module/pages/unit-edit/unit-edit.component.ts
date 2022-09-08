import { Component, OnInit } from '@angular/core';
import { UnitStateService } from 'src/app/shared/services/unit-state.service';

@Component({
  selector: 'app-unit-edit',
  templateUrl: './unit-edit.component.html',
  styleUrls: ['./unit-edit.component.scss']
})
export class UnitEditComponent implements OnInit {

  constructor(private unitsService: UnitStateService) { }

  ngOnInit(): void {
  }

}
