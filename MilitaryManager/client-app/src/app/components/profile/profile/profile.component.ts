import { Component, OnInit } from '@angular/core';
import { ISize } from './interfaces';
import { IName } from './interfaces';
import { IStringSize } from './interfaces';



@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})

export class ProfileComponent implements OnInit {

  userName: string = '';
  weight: number = 0;
  height: number = 0;
  ranks: IName[];
  position: string = '';
  footSizes: ISize[];
  headSizes: ISize[];
  gasMaskSizes: IStringSize[];
  uniforms: IName[];
  bloodTypes: IName[];
  selectedRank: string = '';
  selectedFootSize: number = -1;
  selectedHeadSize: number = -1;
  selectedGasMaskSize: number = -1;
  selectedUniform: string = '';
  selectedBloodType: string = '';

  constructor() {
    this.footSizes = [
      {size: 38},
      {size: 39},
      {size: 40},
      {size: 41},
      {size: 42},
      {size: 43},
      {size: 44},
      {size: 45}
    ],
    this.headSizes = [
      {size: 54},
      {size: 55},
      {size: 56},
      {size: 57},
      {size: 58},
      {size: 59},
      {size: 60},
      {size: 61},
      {size: 62},
      {size: 63},
      {size: 64}
    ],
    this.gasMaskSizes = [
      {size: '0'},
      {size: '1'},
      {size: '2'},
      {size: '3'},
      {size: '4'}
    ],
    this.ranks = [
      {name: 'Молодший лейтенант'},
      {name: 'Лейтенант'},
      {name: 'Старший лейтенант'},
      {name: 'Капітан'},
      {name: 'Майор'},
      {name: 'Підполковник'},
      {name: 'Бригадний генерал'},
      {name: 'Генерал-майор'},
      {name: 'Генерал-лейтенант'},
      {name: 'Генерал'}
    ],
    this.uniforms = [
      {name: 'Стандарт НАТО'},
      {name: 'Український стандарт'}
    ]
    this.bloodTypes = [
      {name: ' I+'},
      {name: 'І-'},
      {name: 'ІІ+'},
      {name: 'ІІ-'},
      {name: 'ІІІ+'},
      {name: 'ІІІ-'},
      {name: 'ІV+'},
      {name: 'ІV-'}
    ]
  }

  ngOnInit(): void {

  }

}
