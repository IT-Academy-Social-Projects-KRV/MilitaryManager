import { Component, OnInit } from '@angular/core';
import { services } from 'src/app/shared/services';
import { ApiService } from 'src/app/shared/services/api/api.service';

@Component({
  selector: 'app-test1',
  templateUrl: './test1.component.html',
  styleUrls: ['./test1.component.scss']
})
export class Test1Component implements OnInit {

  constructor(public apiService: ApiService) { }

  ngOnInit(): void {
  }

  getWeatherUnits() {
    this.apiService.units.single.get().subscribe(res => {
      console.log(res);
    })
  }

}
