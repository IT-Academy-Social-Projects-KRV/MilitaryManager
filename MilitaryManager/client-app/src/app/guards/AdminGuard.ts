import {CanActivate} from "@angular/router";
import {IdentityService} from "../shared/services/api/identity.service";
import {Injectable} from "@angular/core";

@Injectable()
export class AdminGuard implements CanActivate {
  constructor(private _identityService : IdentityService) {
  }
  canActivate() {
   return this.isAdmin();
  }
  isAdmin() : Promise<boolean> {
    return new Promise((resolve, reject) =>
    {
      this._identityService.single.get().subscribe( (data:any) => {
        if (data["0"] == "Admin") {
          resolve(true);
        } else {
          alert("Немає прав");
          resolve(false);
        }
      });
    });
  }
}
