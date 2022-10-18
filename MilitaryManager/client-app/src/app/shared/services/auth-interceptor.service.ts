import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpHeaders } from '@angular/common/http';
import { from, Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthInterceptorService implements HttpInterceptor {

  constructor(private _authService: AuthService) { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    //@ts-ignore
    return from(
      this._authService.getAccessToken()
      .then(token => {
        // overrides any custom headers
        const headersConfig = {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${token}`,
          Accept: 'application/json',
        };
        const headers = new HttpHeaders(headersConfig);
        const authRequest = req.clone({ headers });
        return next.handle(authRequest).toPromise();
      })
    )
  }
}