import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './components/components/header/header.component';
import { FooterComponent } from './components/components/footer/footer.component';
import { PrimeNgComponentsModule } from 'src/app/modules/primeng-components-module/primeng-components.module';

@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    CommonModule,
    PrimeNgComponentsModule
  ],
  exports:[
    HeaderComponent,
    FooterComponent
  ]
})
export class SharedModule { }
