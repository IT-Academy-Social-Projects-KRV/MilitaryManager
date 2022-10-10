import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/shared/services/api/api.service';
import { AuthService } from 'src/app/shared/services/auth.service';

@Component({
  selector: 'app-signin-redirect-callback',
  templateUrl: './signin-redirect-callback.component.html',
  styleUrls: ['./signin-redirect-callback.component.scss']
})
export class SigninRedirectCallbackComponent implements OnInit {

  constructor(private _authService: AuthService, private _router: Router, private _apiService: ApiService) { }

  ngOnInit(): void {
    this._authService.finishLogin()
      .then(user => {
        this._apiService.unitUser.GetUnitUser(user.profile.sub)
          .subscribe(res => {
            if(res){
              this._router.navigate(['/'], { replaceUrl: true });
            }
            this._router.navigate(['/finishRegistration', {replaceUrl: true}])
          })
      })
  }
}
