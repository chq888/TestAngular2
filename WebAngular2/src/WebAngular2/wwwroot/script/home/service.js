System.register(['@angular/core', '@angular/http', 'rxjs/Rx'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1, http_1, Rx_1;
    var Service;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (http_1_1) {
                http_1 = http_1_1;
            },
            function (Rx_1_1) {
                Rx_1 = Rx_1_1;
            }],
        execute: function() {
            //import 'rxjs/add/operator/map';
            let Service = class Service {
                constructor(http) {
                    this.http = http;
                    this.heroesUrl = 'api/TestApi'; // URL to web API
                }
                Get() {
                    return this.http.get(this.heroesUrl)
                        .map(this.extractData)
                        .catch(this.handleError);
                }
                extractData(res) {
                    let body = res.json();
                    return body.data || {};
                }
                handleError(error) {
                    // In a real world app, we might use a remote logging infrastructure
                    // We'd also dig deeper into the error to get a better message
                    let errMsg = (error.message) ? error.message :
                        error.status ? `${error.status} - ${error.statusText}` : 'Server error';
                    console.error(errMsg); // log to console instead
                    return Rx_1.Observable.throw(errMsg);
                }
            };
            Service = __decorate([
                core_1.Injectable(), 
                __metadata('design:paramtypes', [http_1.Http])
            ], Service);
            exports_1("Service", Service);
        }
    }
});

//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImhvbWUvc2VydmljZS50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7OztZQUlBLGlDQUFpQztZQUdqQztnQkFFRSxZQUFvQixJQUFVO29CQUFWLFNBQUksR0FBSixJQUFJLENBQU07b0JBRXRCLGNBQVMsR0FBRyxhQUFhLENBQUMsQ0FBRSxpQkFBaUI7Z0JBRHJELENBQUM7Z0JBR0QsR0FBRztvQkFDRCxNQUFNLENBQUMsSUFBSSxDQUFDLElBQUksQ0FBQyxHQUFHLENBQUMsSUFBSSxDQUFDLFNBQVMsQ0FBQzt5QkFDakMsR0FBRyxDQUFDLElBQUksQ0FBQyxXQUFXLENBQUM7eUJBQ3JCLEtBQUssQ0FBQyxJQUFJLENBQUMsV0FBVyxDQUFDLENBQUM7Z0JBQzdCLENBQUM7Z0JBRU8sV0FBVyxDQUFDLEdBQWE7b0JBQy9CLElBQUksSUFBSSxHQUFHLEdBQUcsQ0FBQyxJQUFJLEVBQUUsQ0FBQztvQkFDdEIsTUFBTSxDQUFDLElBQUksQ0FBQyxJQUFJLElBQUksRUFBRSxDQUFDO2dCQUN6QixDQUFDO2dCQUVPLFdBQVcsQ0FBQyxLQUFVO29CQUM1QixvRUFBb0U7b0JBQ3BFLDhEQUE4RDtvQkFDOUQsSUFBSSxNQUFNLEdBQUcsQ0FBQyxLQUFLLENBQUMsT0FBTyxDQUFDLEdBQUcsS0FBSyxDQUFDLE9BQU87d0JBQzFDLEtBQUssQ0FBQyxNQUFNLEdBQUcsR0FBRyxLQUFLLENBQUMsTUFBTSxNQUFNLEtBQUssQ0FBQyxVQUFVLEVBQUUsR0FBRyxjQUFjLENBQUM7b0JBQzFFLE9BQU8sQ0FBQyxLQUFLLENBQUMsTUFBTSxDQUFDLENBQUMsQ0FBQyx5QkFBeUI7b0JBQ2hELE1BQU0sQ0FBQyxlQUFVLENBQUMsS0FBSyxDQUFDLE1BQU0sQ0FBQyxDQUFDO2dCQUNsQyxDQUFDO1lBRUgsQ0FBQztZQTNCRDtnQkFBQyxpQkFBVSxFQUFFOzt1QkFBQTtZQUNiLDZCQTBCQyxDQUFBIiwiZmlsZSI6ImhvbWUvc2VydmljZS5qcyIsInNvdXJjZXNDb250ZW50IjpbImltcG9ydCB7IEluamVjdGFibGUgfSAgICAgZnJvbSAnQGFuZ3VsYXIvY29yZSc7XHJcbmltcG9ydCB7IEh0dHAsIFJlc3BvbnNlIH0gZnJvbSAnQGFuZ3VsYXIvaHR0cCc7XHJcbmltcG9ydCB7IFRlc3RNb2RlbCB9IGZyb20gJy4uL21vZGVsL1Rlc3RNb2RlbCc7XHJcbmltcG9ydCB7IE9ic2VydmFibGUgfSBmcm9tICdyeGpzL1J4JztcclxuLy9pbXBvcnQgJ3J4anMvYWRkL29wZXJhdG9yL21hcCc7XHJcblxyXG5ASW5qZWN0YWJsZSgpXHJcbmV4cG9ydCBjbGFzcyBTZXJ2aWNlIHtcclxuXHJcbiAgY29uc3RydWN0b3IocHJpdmF0ZSBodHRwOiBIdHRwKSB7XHJcbiAgfVxyXG4gIHByaXZhdGUgaGVyb2VzVXJsID0gJ2FwaS9UZXN0QXBpJzsgIC8vIFVSTCB0byB3ZWIgQVBJXHJcblxyXG4gIEdldCgpOiBPYnNlcnZhYmxlPFRlc3RNb2RlbFtdPiB7XHJcbiAgICByZXR1cm4gdGhpcy5odHRwLmdldCh0aGlzLmhlcm9lc1VybClcclxuICAgICAgLm1hcCh0aGlzLmV4dHJhY3REYXRhKVxyXG4gICAgICAuY2F0Y2godGhpcy5oYW5kbGVFcnJvcik7XHJcbiAgfVxyXG5cclxuICBwcml2YXRlIGV4dHJhY3REYXRhKHJlczogUmVzcG9uc2UpIHtcclxuICAgIGxldCBib2R5ID0gcmVzLmpzb24oKTtcclxuICAgIHJldHVybiBib2R5LmRhdGEgfHwge307XHJcbiAgfVxyXG5cclxuICBwcml2YXRlIGhhbmRsZUVycm9yKGVycm9yOiBhbnkpIHtcclxuICAgIC8vIEluIGEgcmVhbCB3b3JsZCBhcHAsIHdlIG1pZ2h0IHVzZSBhIHJlbW90ZSBsb2dnaW5nIGluZnJhc3RydWN0dXJlXHJcbiAgICAvLyBXZSdkIGFsc28gZGlnIGRlZXBlciBpbnRvIHRoZSBlcnJvciB0byBnZXQgYSBiZXR0ZXIgbWVzc2FnZVxyXG4gICAgbGV0IGVyck1zZyA9IChlcnJvci5tZXNzYWdlKSA/IGVycm9yLm1lc3NhZ2UgOlxyXG4gICAgICBlcnJvci5zdGF0dXMgPyBgJHtlcnJvci5zdGF0dXN9IC0gJHtlcnJvci5zdGF0dXNUZXh0fWAgOiAnU2VydmVyIGVycm9yJztcclxuICAgIGNvbnNvbGUuZXJyb3IoZXJyTXNnKTsgLy8gbG9nIHRvIGNvbnNvbGUgaW5zdGVhZFxyXG4gICAgcmV0dXJuIE9ic2VydmFibGUudGhyb3coZXJyTXNnKTtcclxuICB9XHJcblxyXG59Il0sInNvdXJjZVJvb3QiOiIvc291cmNlLyJ9
