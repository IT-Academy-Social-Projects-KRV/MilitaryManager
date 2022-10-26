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
        req = req.clone({
          setHeaders: {
            Authorization: `Bearer ${token}`,
          }
        });
        return next.handle(req).toPromise();
      })
    )
  }
}
