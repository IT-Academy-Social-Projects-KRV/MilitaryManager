import { Component, ElementRef, ViewChild } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { AuthService } from '../shared/services/auth.service';
import { LayoutService } from "./service/app.layout.service";

@Component({
    selector: 'app-topbar',
    templateUrl: './app.topbar.component.html'
})
export class AppTopBarComponent {

    isUserAuthenticated = false;

    items!: MenuItem[];

    @ViewChild('menubutton') menuButton!: ElementRef;

    @ViewChild('topbarmenubutton') topbarMenuButton!: ElementRef;

    @ViewChild('topbarmenu') menu!: ElementRef;

    constructor(
        public layoutService: LayoutService,
        public authService: AuthService) {                    
        this.authService.loginChanged.subscribe(userAuthenticated => {
            this.isUserAuthenticated = userAuthenticated;
        })
    }    

    ngOnInit(): void {
        this.authService.isAuthenticated().then(userAuthenticated => {
            this.isUserAuthenticated = userAuthenticated;
        })
    }

    public login = () => {
        this.authService.login();
    }

    public logout = () => {
        this.authService.logout();
    }

    onConfigButtonClick() {
        this.layoutService.showConfigSidebar();
    }
}
