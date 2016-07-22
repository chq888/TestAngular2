import { Component, Injectable } from '@angular/core';
import { NgFor } from '@angular/common';
import {Http, Headers, Response} from '@angular/http';
import { Observable } from 'rxjs/Rx';

import { TestModel } from '../model/TestModel';
import { Service } from './Service';

@Component({
  selector: "app-shell",
  //directives: [NgFor],
  templateUrl: "script/home/Test.html",
})
export class TestComponent {

  list: Array<TestModel> = [];
  myName: string;
  errorMessage: string;
  heroes: TestModel[];

  constructor(private http: Http) {
    this.Get();


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


  //constructor(private service: Service) {
  //  this.getHeroes();
  //} 
  //getHeroes() {
  //  this.service.Get()
  //    .subscribe(
  //    heroes => this.heroes = heroes,
  //    error => this.errorMessage = <any>error);
  //}
  

  //getData() {
  //  this.http.get('api/TestApi')
  //    .map((res: Response) => res.json())
  //    .subscribe(
  //      data => { this.list = data },
  //      err => console.error(err),
  //      () => console.log('done')
  //    );
  //}


  //// to generate the JSON object as array
  //generateArray(obj) {
  //  return Object.keys(obj).map((key) => { return obj[key] });
  //}
}
