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
                label: 'Головна',
                items: [
                    { label: 'Головна', icon: 'pi pi-fw pi-home', routerLink: ['/home'] }
                ]
            },
            {
               label: 'Профіль',
               items: [
                 { label: 'Профіль', icon: 'pi pi-fw pi-user', routerLink: ['/profile'] }
               ]
            },
            {
                label: 'Бійці',
                items: [
                    { label: 'Бійці', icon: 'pi pi-fw pi-users', routerLink: ['/units/list'] },
                    { label: 'Додати бійця', icon: 'pi pi-fw pi-user-plus', routerLink: ['/'] }
                ]
            },
            {
                label: 'Накази',
                items: [
                    { label: 'Накази', icon: 'pi pi-fw pi-book', routerLink: ['/']},
                    { label: 'Створити наказ', icon: 'pi pi-fw pi-plus', routerLink: ['/']},
                ]
            },
            {
                label: 'Зброя',
                items: [
                    { label: 'Зброя', icon: 'pi pi-fw pi-shield', routerLink: ['/'] },
                    { label: 'Додати зброю', icon: 'pi pi-fw pi-plus', routerLink: ['/'] },
                ]
            },
            {
                label: 'Адміністратор',
                items: [
                    { label: 'Додати командира', icon: 'pi pi-user-plus', routerLink: ['/addCommander'] }
                ]
            }
        ];
    }
}
