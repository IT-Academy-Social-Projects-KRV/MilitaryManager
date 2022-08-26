import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { LayoutService } from './service/app.layout.service';

@Component({
    selector: 'app-menu',
    templateUrl: './app.menu.component.html'
})
export class AppMenuComponent implements OnInit {

    model: any[] = [];

    constructor(public layoutService: LayoutService) { }

    ngOnInit() {
        this.model = [
            {
                label: 'Home',
                items: [
                    { label: 'Home', icon: 'pi pi-fw pi-home', routerLink: ['/home'] }
                ]
            },
            {
                label: 'Units',
                items: [
                    { label: 'All units', icon: 'pi pi-fw pi-users', routerLink: ['/units/list'] },
                    { label: 'Create unit', icon: 'pi pi-fw pi-user-plus', routerLink: ['/'] }
                ]
            },
            {
                label: 'Documents',
                items: [
                    { label: 'All documents', icon: 'pi pi-fw pi-book', routerLink: ['/']},
                    { label: 'Add document', icon: 'pi pi-fw pi-plus', routerLink: ['/']},
                ]
            },
            {
                label: 'Amunition',
                items: [
                    { label: 'Amunition', icon: 'pi pi-fw pi-shield', routerLink: ['/'] },
                    { label: 'Add amunition', icon: 'pi pi-fw pi-plus', routerLink: ['/'] },
                ]
            }
        ];
    }
}
