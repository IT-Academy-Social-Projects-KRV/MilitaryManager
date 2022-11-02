import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SigninRedirectCallbackComponent } from './components/signin-redirect-callback/signin-redirect-callback.component';
import { SignoutRedirectCallbackComponent } from './components/signout-redirect-callback/signout-redirect-callback.component';
import { Test1Component } from './components/test1/test1.component';
import { Test2Component } from './components/test2/test2.component';
import { HomeComponent } from './components/home/home.component';
import { AppLayoutComponent } from './layout/app.layout.component';
import { AddCommanderComponent } from './components/add-commander/add-commander.component';
import  { AdminGuard } from './guards/AdminGuard'
import { UnitCommanderGuard } from './guards/UnitCommanderGuard'
import { SubUnitCommanderGuard } from './guards/SubUnitCommanderGuard'
import { ProfileComponent } from "./components/profile/profile/profile.component";
import { FinishRegistrationComponent } from './components/finish-registration/finish-registration.component';
import {UpdateProfileComponent} from "./components/profile/update-profile/update-profile.component";
import {LogComponent} from "./components/log/log.component";
import { CommandersGuard } from './guards/CommandersGuard';

const routes: Routes = [
    {path:'', component:AppLayoutComponent,
  children:[
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'test1', component: Test1Component },
    { path: 'test2', component: Test2Component },
    { path: 'addCommander', component: AddCommanderComponent, canActivate: [AdminGuard] },
    { path: 'decree', loadChildren: () => import("./modules/attachments-module/attachments.module").then(m => m.AttachmentsModule), canActivate: [CommandersGuard] },
    { path: 'finishRegistration', component: FinishRegistrationComponent},
    { path: 'logs', component: LogComponent },
    { path: 'units', loadChildren: () => import("./modules/units-module/units.module").then(m => m.UnitsModule), canActivate: [CommandersGuard] },
    { path: 'divisions', loadChildren: () => import("./modules/division-module/division.module").then(m => m.DivisionModule) },
    { path: 'equipment', loadChildren: () => import("./modules/equipment/equipment.module").then(m => m.EquipmentModule), canActivate: [CommandersGuard] },
    { path: 'SignInCallback', component: SigninRedirectCallbackComponent },
    { path: 'SignOutCallback', component: SignoutRedirectCallbackComponent },
    { path: 'profile', component: ProfileComponent, canActivate: [CommandersGuard] },
    { path: 'updateProfile', component: UpdateProfileComponent },
    { path: 'attachments', loadChildren: () => import("./modules/attachments-module/attachments.module").then(m => m.AttachmentsModule), canActivate: [CommandersGuard] },
    { path: '**', redirectTo: 'home' }
  ]}
  ];
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
    providers: [AdminGuard, UnitCommanderGuard, SubUnitCommanderGuard, CommandersGuard]
})
export class AppRoutingModule { }
