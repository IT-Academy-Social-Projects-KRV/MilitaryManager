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
                label: 'Бійці',
                items: [
                    { label: 'Бійці', icon: 'pi pi-fw pi-users', routerLink: ['/units/list'] },
                    { label: 'Додати бійця', icon: 'pi pi-fw pi-user-plus', routerLink: ['/units/add'] }
                ]
            },
            {
              label: 'Підрозділи',
              items: [
                { label: 'Підрозділи', icon: 'pi pi-fw pi-users', routerLink: ['/divisions/list'] },
                { label: 'Додати підрозділ', icon: 'pi pi-fw pi-user-plus', routerLink: ['/divisions/new'] }
              ]
            },
            {
                label: 'Накази',
                items: [
                    { label: 'Накази', icon: 'pi pi-fw pi-book', routerLink: ['/decree/list']},
                    { label: 'Створити наказ', icon: 'pi pi-fw pi-plus', routerLink: ['/decree/new']},
                ]
            },
            {
                label: 'Спорядження',
                items: [
                    { label: 'Спорядження', icon: 'pi pi-fw pi-shield', routerLink: ['/equipment/list'] },
                    { label: 'Додати спорядження', icon: 'pi pi-fw pi-plus', routerLink: ['/equipment/new'] },
                ]
            },
            {
                label: 'Адміністратор',
                items: [
                    { label: 'Додати командира', icon: 'pi pi-user-plus', routerLink: ['/addCommander'] },
                    { label: 'Історія змін', icon: 'pi pi-fw pi-users', routerLink: ['/logs'] }
                ]
            }
        ];
    }
}
