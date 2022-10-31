import {Injectable} from "@angular/core";
import {CanActivate} from "@angular/router";
import {IdentityService} from "../shared/services/api/identity.service";

@Injectable()
export class CommandersGuard implements CanActivate {
  constructor(private _identityService : IdentityService) {
  }
  canActivate() {
    return this.isOneOfCommanders();
  }
  isOneOfCommanders() : Promise<boolean> {
    return new Promise((resolve, reject) =>
    {
      this._identityService.single.get().subscribe( (data:any) => {
        if (data["0"] == "SubUnitCommander" || data["0"] == "UnitCommander") {
          resolve(true);
        } else {
          alert("Немає прав");
          resolve(false);
        }
      });
    });
  }
}
