import { Component, OnInit } from '@angular/core';
import { ConfigModel } from './shared/models/config.model';
import { ApiService } from './shared/services/api/api.service';
import { ConfigService } from './shared/services/api/config.service';
import { ClientConfigurationService } from './shared/services/core/client-configuration.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
    constructor(
        private configService: ConfigService,
        private clientConfigService: ClientConfigurationService,
        private apiService: ApiService) {
    }

    ngOnInit(): void {
        this.configService.single.get().subscribe((data: ConfigModel) => {
            this.clientConfigService.config = data;
        });
    }
}
