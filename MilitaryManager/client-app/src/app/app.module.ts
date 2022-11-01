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
import {ProfileComponent} from "./components/profile/profile/profile.component";
import { FinishRegistrationComponent } from './components/finish-registration/finish-registration.component';
import { ReactiveFormsModule } from '@angular/forms';
import { UpdateProfileComponent } from './components/profile/update-profile/update-profile.component';
import { LogComponent } from "./components/log/log.component";
import { TableModule } from 'primeng/table';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TabViewModule } from 'primeng/tabview';


@NgModule({
  declarations: [
    AppComponent,
    Test1Component,
    Test2Component,
    SigninRedirectCallbackComponent,
    SignoutRedirectCallbackComponent,
    LogComponent,
    HomeComponent,
    AddCommanderComponent,
    ProfileComponent,
    FinishRegistrationComponent,
    UpdateProfileComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    PrimeNgComponentsModule,
    AppLayoutModule,
    ReactiveFormsModule,
    AppLayoutModule,
    TableModule,
    TabViewModule,
    BrowserAnimationsModule,
  ],
  providers: [
    services,
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptorService, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
