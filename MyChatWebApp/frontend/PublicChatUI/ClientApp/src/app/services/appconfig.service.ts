import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable()
export class AppConfigService {
  private appConfig;

  constructor(private http: HttpClient) { }

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
