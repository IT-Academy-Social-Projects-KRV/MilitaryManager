import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-finish-registration',
  templateUrl: './finish-registration.component.html',
  styleUrls: ['./finish-registration.component.scss']
})
export class FinishRegistrationComponent implements OnInit {

  firstname?: string;
  lastname?: string;
  middlename?: string;
  position?: string;
  rank?: string;

  divisions: string[] = [
    'division1',
    'division2',
    'division3'
  ];

  selected_division?: string;

  constructor() { }

  ngOnInit(): void {
  }

}
