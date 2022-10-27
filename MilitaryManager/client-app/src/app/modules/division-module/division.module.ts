import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DivisionListComponent } from './pages/division-list/division-list.component';
import { DivisionEditComponent } from './pages/division-edit/division-edit.component';
import { RouterModule } from '@angular/router';
import { PrimeNgComponentsModule } from '../primeng-components-module/primeng-components.module';

@NgModule({
    declarations: [
        DivisionListComponent,
        DivisionEditComponent
    ],
    exports: [
        DivisionListComponent
    ],
    imports: [
        CommonModule,
        PrimeNgComponentsModule,
        RouterModule.forChild([
            {path: '', redirectTo: 'list', pathMatch: 'full'},
            {path: 'list', component: DivisionListComponent},
            {path: 'edit', component: DivisionEditComponent},
            {path: '**', redirectTo: 'list'}
        ])
    ]
})
export class DivisionModule { }
