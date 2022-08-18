
import { Injectable } from '@angular/core';
import {
    HttpClient,
    HttpHeaders,
    HttpParams,
    HttpErrorResponse,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class HttpService {
    constructor(
        private httpClient: HttpClient
    ) {
    }

    private setHeaders(): HttpHeaders {
        const headersConfig = {
            'Content-Type': 'application/json',
            Authorization: `Token ${this.token}`,
            Accept: 'application/json',
        };
        return new HttpHeaders(headersConfig);
    }

    public get token(): string | null {
        return window.localStorage.getItem('token');
    }

    public set token(value: string | null) {
        window.localStorage.setItem(`token`, value ?? '');
    }

    private formatErrors(error: HttpErrorResponse): Observable<never> {
        // TODO: handle api service level errors
        return throwError(() => error);
    }

    request(func: (httpClient: HttpClient) => Observable<any>): Observable<any> {
        return func(this.httpClient);
    }

    get(path: string, params: HttpParams = new HttpParams()): Observable<any> {
        return this.httpClient
            .get(`${path}`, { headers: this.setHeaders(), params })
            .pipe(catchError((error: HttpErrorResponse) => this.formatErrors(error)));
    }

    put(path: string, body: any = {}): Observable<any> {
        return this.httpClient
            .put(`${path}`, JSON.stringify(body), { headers: this.setHeaders() })
            .pipe(catchError((error: HttpErrorResponse) => this.formatErrors(error)));
    }

    post(path: string, body: any = {}): Observable<any> {
        return this.httpClient
            .post(`${path}`, JSON.stringify(body), { headers: this.setHeaders() })
            .pipe(catchError((error: HttpErrorResponse) => this.formatErrors(error)));
    }

    delete(path: string): Observable<any> {
        return this.httpClient
            .delete(`${path}`, { headers: this.setHeaders() })
            .pipe(catchError((error: HttpErrorResponse) => this.formatErrors(error)));
    }
}
