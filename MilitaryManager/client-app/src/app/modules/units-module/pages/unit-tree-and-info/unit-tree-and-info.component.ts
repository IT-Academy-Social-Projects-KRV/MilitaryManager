import { Component, OnInit } from '@angular/core';
import {UnitModel} from "../../../../shared/models/unit.model";

@Component({
  selector: 'app-unit-tree-and-info',
  templateUrl: './unit-tree-and-info.component.html',
  styleUrls: ['./unit-tree-and-info.component.scss']
})
export class UnitTreeAndInfoComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  public id: number;

  public transferIdFromUnitListToMainComponent(someNumber: number): void {
    this.id = someNumber;
  }
}
