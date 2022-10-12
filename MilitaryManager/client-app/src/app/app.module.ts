import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PrimeNgComponentsModule } from './modules/primeng-components-module/primeng-components.module';
import { services } from './shared/services';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptorService } from './shared/services/auth-interceptor.service';
import { Test1Component } from './components/test1/test1.component';
import { Test2Component } from './components/test2/test2.component';
import { SigninRedirectCallbackComponent } from './components/signin-redirect-callback/signin-redirect-callback.component';
import { SignoutRedirectCallbackComponent } from './components/signout-redirect-callback/signout-redirect-callback.component';
import { HomeComponent } from './components/home/home.component';
import { AppLayoutModule } from './layout/app.layout.module';
import { AddCommanderComponent } from './components/add-commander/add-commander.component';

@NgModule({
  declarations: [
    AppComponent,
    Test1Component,
    Test2Component,
    SigninRedirectCallbackComponent,
    SignoutRedirectCallbackComponent,
    HomeComponent,
    AddCommanderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    PrimeNgComponentsModule,
    AppLayoutModule
  ],
  providers: [
    services,
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptorService, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
