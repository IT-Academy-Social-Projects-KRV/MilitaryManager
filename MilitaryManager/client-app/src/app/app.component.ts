import { Component, OnInit } from '@angular/core';
import { ConfigModel } from './shared/models/config.model';
import { ApiService } from './shared/services/api/api.service';
import { ConfigService } from './shared/services/api/config.service';
import { AuthService } from './shared/services/auth.service';
import { ClientConfigurationService } from './shared/services/core/client-configuration.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
    public userAuthenticated = false;

    constructor(
        private configService: ConfigService,
        private clientConfigService: ClientConfigurationService,
        private apiService: ApiService,
        private _authService: AuthService) {
        this._authService.loginChanged
        .subscribe(userAuthenticated => {
        this.userAuthenticated = userAuthenticated;
        })
    }

    ngOnInit(): void {
        this.configService.single.get().subscribe((data: ConfigModel) => {
            this.clientConfigService.config = data;
        });
        this._authService.isAuthenticated()
        .then(userAuthenticated => {
        this.userAuthenticated = userAuthenticated;
        })
    }

    public login = () => {
        this._authService.login();
    }

    public logout = () => {
        this._authService.logout();
    }
}
