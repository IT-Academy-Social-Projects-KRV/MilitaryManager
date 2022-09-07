import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DocumentComponent } from './components/document/document.component';
import { Test1Component } from './components/test1/test1.component';
import { Test2Component } from './components/test2/test2.component';

const routes: Routes = [
    { path: '', redirectTo: 'test1', pathMatch: 'full' },
    { path: 'test1', component: Test1Component },
    { path: 'test2', component: Test2Component },
    { path: 'documents', component: DocumentComponent },
    { path: 'units', loadChildren: () => import("./modules/units-module/units.module").then(m => m.UnitsModule) },
    { path: '**', redirectTo: 'test1' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
