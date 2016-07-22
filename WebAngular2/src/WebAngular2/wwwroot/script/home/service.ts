import { Injectable }     from '@angular/core';
import { Http, Response } from '@angular/http';
import { TestModel } from '../model/TestModel';
import { Observable } from 'rxjs/Rx';
//import 'rxjs/add/operator/map';

@Injectable()
export class Service {

  constructor(private http: Http) {
  }
  private heroesUrl = 'api/TestApi';  // URL to web API

  Get(): Observable<TestModel[]> {
    return this.http.get(this.heroesUrl)
      .map(this.extractData)
      .catch(this.handleError);
  }

  private extractData(res: Response) {
    let body = res.json();
    return body.data || {};
  }

  private handleError(error: any) {
    // In a real world app, we might use a remote logging infrastructure
    // We'd also dig deeper into the error to get a better message
    let errMsg = (error.message) ? error.message :
      error.status ? `${error.status} - ${error.statusText}` : 'Server error';
    console.error(errMsg); // log to console instead
    return Observable.throw(errMsg);
  }

}