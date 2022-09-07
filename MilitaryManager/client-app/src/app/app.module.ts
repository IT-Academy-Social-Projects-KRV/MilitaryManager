import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PrimeNgComponentsModule } from './modules/primeng-components-module/primeng-components.module';
import { services } from './shared/services';
import { Test1Component } from './components/test1/test1.component';
import { Test2Component } from './components/test2/test2.component';
import { DocumentComponent } from './components/document/document.component';

@NgModule({
  declarations: [
    AppComponent,
    Test1Component,
    Test2Component,
    DocumentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    PrimeNgComponentsModule,
  ],
  providers: [
    services
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
