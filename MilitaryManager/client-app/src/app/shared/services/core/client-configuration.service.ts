import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable()
export class ClientConfigurationService {
    public config: any = null;

    public getEnvSetting(settingName: string) {
        if(this.config && this.config[settingName]) {
            return this.config[settingName];
        } else {
            return (environment as any)[settingName];
        }
    }
}
