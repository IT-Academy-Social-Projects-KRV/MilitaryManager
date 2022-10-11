import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SigninRedirectCallbackComponent } from './components/signin-redirect-callback/signin-redirect-callback.component';
import { SignoutRedirectCallbackComponent } from './components/signout-redirect-callback/signout-redirect-callback.component';
import { DocumentComponent } from './components/document/document.component';
import { Test1Component } from './components/test1/test1.component';
import { Test2Component } from './components/test2/test2.component';
import { HomeComponent } from './components/home/home.component';
import { AppLayoutComponent } from './layout/app.layout.component';
import { AddCommanderComponent } from './components/add-commander/add-commander.component';

const routes: Routes = [
    {path:'', component:AppLayoutComponent,
  children:[
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'test1', component: Test1Component },
    { path: 'test2', component: Test2Component },
    { path: 'addCommander', component: AddCommanderComponent },
    { path: 'documents', component: DocumentComponent },
    { path: 'units', loadChildren: () => import("./modules/units-module/units.module").then(m => m.UnitsModule) },
    { path: 'divisions', loadChildren: () => import("./modules/division-module/division.module").then(m => m.DivisionModule) },
    { path: 'SignInCallback', component: SigninRedirectCallbackComponent },
    { path: 'SignOutCallback', component: SignoutRedirectCallbackComponent },
    { path: 'attachments', loadChildren: () => import("./modules/attachments-module/attachments.module").then(m => m.AttachmentsModule) },
    { path: '**', redirectTo: 'home' }
  ]}
  ];
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
