import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/shared/services/api/api.service';
import { IdentityService } from 'src/app/shared/services/api/identity.service';
import { UnitUserService } from 'src/app/shared/services/api/unit-user.service';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-signin-redirect-callback',
  templateUrl: './signin-redirect-callback.component.html',
  styleUrls: ['./signin-redirect-callback.component.scss']
})
export class SigninRedirectCallbackComponent implements OnInit {

  constructor(private _authService: AuthService, private _router: Router, private unitUser: UnitUserService,
    private _identityService: IdentityService) { }

  ngOnInit(): void {
    this._authService.finishLogin()
      .then(user => {
        this._identityService.single.get().subscribe((data: any) => {
          if (data["0"] == "Admin") {
            this._router.navigate(['/'], { replaceUrl: true });
          }
          else {
            this.unitUser.GetUnitUser(user.profile.sub)
              .subscribe(res => {
                if (res) {
                  this._router.navigate(['/'], { replaceUrl: true });
                }
                else {
                  this._router.navigateByUrl('finishRegistration');
                }
              }
              )
          }
        })
      })
  }
}
