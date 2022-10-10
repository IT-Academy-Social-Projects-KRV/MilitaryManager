import {CanActivate} from "@angular/router";
import {IdentityService} from "../shared/services/api/identity.service";
import {Injectable} from "@angular/core";
import { map } from 'rxjs/operators';
import {Observable} from 'rxjs';
import { UserModel } from "../shared/models/user.model";

@Injectable()
export class AdminGuard implements CanActivate {
  constructor(private _identityService : IdentityService) {
  }
  role : string = "";
  //userModel: UserModel = new UserModel();
  canActivate() {
   return this.getRole();
  }
 /* getRole() : boolean {
    this._identityService.single.get().subscribe( (data:any) => {
      console.log(data);
      //this.userModel.Role = data["0"];
       this.role = data["0"] ;
       if(this.role == "Admin") {
         console.log("sss");
        return true;
      } else {
        console.log("Not an admin");
        return  false;
      }
    });
    return  false;
  }*/
  getRole() : Promise<boolean> {
    return new Promise((resolve, reject) =>
    {
      this._identityService.single.get().subscribe( (data:any) => {
        if (data["0"] == "Admin") {
          resolve(true);
        } else {
          alert("Немає прав");
        }
      });
    });
  }
}
