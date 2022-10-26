import { Injectable } from '@angular/core';
import { UserManager, User, UserManagerSettings, WebStorageStateStore } from 'oidc-client';
import { Subject } from 'rxjs';
import { CookieStorage } from 'cookie-storage';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private _userManager: UserManager;
  // @ts-ignore
  private _user: User;
  private _loginChangedSubject = new Subject<boolean>();
  public loginChanged = this._loginChangedSubject.asObservable();

  private get idpSettings() : UserManagerSettings {
    return {
      authority: "https://localhost:5007",
      client_id: "angular",
      redirect_uri: `${location.origin}/SignInCallback`,
      scope: "openid profile unitsAPI IdentityServerApi attachmentsAPI",
      response_type: "code",
      post_logout_redirect_uri: `${location.origin}/SignOutCallback`,
      stateStore: new WebStorageStateStore({ store: new CookieStorage() }),
      userStore: new WebStorageStateStore({ store: new CookieStorage() })
    }
  }
  constructor() {
    this._userManager = new UserManager(this.idpSettings);
  }

  public login = () => {
    return this._userManager.signinRedirect();
  }

  public finishLogin = (): Promise<User> => {
    return this._userManager.signinRedirectCallback()
    .then(user => {
      this._user = user;
      this._loginChangedSubject.next(this.checkUser(user));
      return user;
    })
  }

  public logout = () => {
    return this._userManager.signoutRedirect({ 'id_token_hint': this._user.id_token });
  }

  public finishLogout = () => {
    // @ts-ignore
    this._user = null;
    return this._userManager.signoutRedirectCallback();
  }

  public getAccessToken = (): Promise<string> => {
    // @ts-ignore
    return this._userManager.getUser()
      .then(user => {
         return !!user && !user.expired ? user.access_token : null;
    })
  }
  public getUserId = (): Promise<string> => {
    // @ts-ignore
    return this._userManager.getUser()
      .then(user => {
        return user?.profile.sub;
      })
  }

  public isAuthenticated = (): Promise<boolean> => {
    return this._userManager.getUser()
    .then(user => {
      if(user)
      {
        if(this._user !== user){
          this._loginChangedSubject.next(this.checkUser(user));
        }
        this._user = user;
        return this.checkUser(user);
      }
      return false;
    })
  }

  public getCurrentUser() {
    return this._user;
  }

  private checkUser = (user : User): boolean => {
    return !!user && !user.expired;
  }
}
