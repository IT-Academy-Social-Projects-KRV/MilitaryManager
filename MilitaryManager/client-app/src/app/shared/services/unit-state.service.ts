import { Injectable} from '@angular/core';
import { StateService } from '../../shared/state.service';
import { UnitModel } from 'src/app/shared/models/unit.model';
import { UnitsService } from 'src/app/shared/services/api/unit.service';
import { Observable} from 'rxjs';
import {shareReplay } from 'rxjs/operators';

interface UnitState {
  units: UnitModel[];
}

const initialState: UnitState = {
  units: []
}

@Injectable({
  providedIn: 'root'
})
export class UnitStateService extends StateService<UnitState>{

  units$: Observable<UnitModel[]>= this.select(state => state.units).pipe(
    shareReplay({refCount: true, bufferSize: 1}))

  constructor(private apiService: UnitsService) {
    super(initialState);
  }

  load() {
    this.apiService.collection.getAll().subscribe((units) => this.setState({ units}));
  }

}
