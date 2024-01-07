import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { APP_CONFIG, AppConfig } from '../app.config';

//@Injectable()
@Injectable({
  providedIn: 'root'
})
export class AppConfigService {

  private appConfig;

  constructor(private http: HttpClient, @Inject(APP_CONFIG) public config: AppConfig) { }

  loadConfig() {
    
    return this.http.get(environment.baseURL + '/assets/appconfig.json')
      .toPromise()
      .then(data => {
        this.appConfig = data;
      });
  }

  getConfig() {
    return this.appConfig;
  }

}
