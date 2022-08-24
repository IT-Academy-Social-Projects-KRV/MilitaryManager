import { Injectable } from '@angular/core';
import { UserManager, User, UserManagerSettings } from 'oidc-client';
import { Constants } from '../constants';
import { Subject } from 'rxjs';

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
      authority: Constants.idpAuthority,
      client_id: Constants.clientId,
      redirect_uri: `${Constants.clientRoot}/SignInCallback`,
      scope: "openid profile api1",
      response_type: "code",
      post_logout_redirect_uri: `${Constants.clientRoot}/SignOutCallback`
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

  public isAuthenticated = (): Promise<boolean> => {
    return this._userManager.getUser()
    .then(user => {
      if(this._user !== user){
        // @ts-ignore
        this._loginChangedSubject.next(this.checkUser(user));
      }
      // @ts-ignore
      this._user = user;
      // @ts-ignore
      return this.checkUser(user);
    })
  }
  
  private checkUser = (user : User): boolean => {
    return !!user && !user.expired;
  }
}
