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
    var TestComponent;
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
            let TestComponent = class TestComponent {
                constructor(http) {
                    this.http = http;
                    this.list = [];
                    this.heroesUrl = 'api/TestApi'; // URL to web API
                    this.Get();
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
            TestComponent = __decorate([
                core_1.Component({
                    selector: "app-shell",
                    //directives: [NgFor],
                    templateUrl: "script/home/Test.html",
                }), 
                __metadata('design:paramtypes', [http_1.Http])
            ], TestComponent);
            exports_1("TestComponent", TestComponent);
        }
    }
});

//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImhvbWUvVGVzdENvbXBvbmVudC50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7OztZQWFBO2dCQU9FLFlBQW9CLElBQVU7b0JBQVYsU0FBSSxHQUFKLElBQUksQ0FBTTtvQkFMOUIsU0FBSSxHQUFxQixFQUFFLENBQUM7b0JBVXBCLGNBQVMsR0FBRyxhQUFhLENBQUMsQ0FBRSxpQkFBaUI7b0JBSm5ELElBQUksQ0FBQyxHQUFHLEVBQUUsQ0FBQztnQkFHYixDQUFDO2dCQUdELEdBQUc7b0JBQ0QsTUFBTSxDQUFDLElBQUksQ0FBQyxJQUFJLENBQUMsR0FBRyxDQUFDLElBQUksQ0FBQyxTQUFTLENBQUM7eUJBQ2pDLEdBQUcsQ0FBQyxJQUFJLENBQUMsV0FBVyxDQUFDO3lCQUNyQixLQUFLLENBQUMsSUFBSSxDQUFDLFdBQVcsQ0FBQyxDQUFDO2dCQUM3QixDQUFDO2dCQUVPLFdBQVcsQ0FBQyxHQUFhO29CQUMvQixJQUFJLElBQUksR0FBRyxHQUFHLENBQUMsSUFBSSxFQUFFLENBQUM7b0JBQ3RCLE1BQU0sQ0FBQyxJQUFJLENBQUMsSUFBSSxJQUFJLEVBQUUsQ0FBQztnQkFDekIsQ0FBQztnQkFFTyxXQUFXLENBQUMsS0FBVTtvQkFDNUIsb0VBQW9FO29CQUNwRSw4REFBOEQ7b0JBQzlELElBQUksTUFBTSxHQUFHLENBQUMsS0FBSyxDQUFDLE9BQU8sQ0FBQyxHQUFHLEtBQUssQ0FBQyxPQUFPO3dCQUMxQyxLQUFLLENBQUMsTUFBTSxHQUFHLEdBQUcsS0FBSyxDQUFDLE1BQU0sTUFBTSxLQUFLLENBQUMsVUFBVSxFQUFFLEdBQUcsY0FBYyxDQUFDO29CQUMxRSxPQUFPLENBQUMsS0FBSyxDQUFDLE1BQU0sQ0FBQyxDQUFDLENBQUMseUJBQXlCO29CQUNoRCxNQUFNLENBQUMsZUFBVSxDQUFDLEtBQUssQ0FBQyxNQUFNLENBQUMsQ0FBQztnQkFDbEMsQ0FBQztZQTZCSCxDQUFDO1lBbEVEO2dCQUFDLGdCQUFTLENBQUM7b0JBQ1QsUUFBUSxFQUFFLFdBQVc7b0JBQ3JCLHNCQUFzQjtvQkFDdEIsV0FBVyxFQUFFLHVCQUF1QjtpQkFDckMsQ0FBQzs7NkJBQUE7WUFDRix5Q0E2REMsQ0FBQSIsImZpbGUiOiJob21lL1Rlc3RDb21wb25lbnQuanMiLCJzb3VyY2VzQ29udGVudCI6WyJpbXBvcnQgeyBDb21wb25lbnQsIEluamVjdGFibGUgfSBmcm9tICdAYW5ndWxhci9jb3JlJztcclxuaW1wb3J0IHsgTmdGb3IgfSBmcm9tICdAYW5ndWxhci9jb21tb24nO1xyXG5pbXBvcnQge0h0dHAsIEhlYWRlcnMsIFJlc3BvbnNlfSBmcm9tICdAYW5ndWxhci9odHRwJztcclxuaW1wb3J0IHsgT2JzZXJ2YWJsZSB9IGZyb20gJ3J4anMvUngnO1xyXG5cclxuaW1wb3J0IHsgVGVzdE1vZGVsIH0gZnJvbSAnLi4vbW9kZWwvVGVzdE1vZGVsJztcclxuaW1wb3J0IHsgU2VydmljZSB9IGZyb20gJy4vU2VydmljZSc7XHJcblxyXG5AQ29tcG9uZW50KHtcclxuICBzZWxlY3RvcjogXCJhcHAtc2hlbGxcIixcclxuICAvL2RpcmVjdGl2ZXM6IFtOZ0Zvcl0sXHJcbiAgdGVtcGxhdGVVcmw6IFwic2NyaXB0L2hvbWUvVGVzdC5odG1sXCIsXHJcbn0pXHJcbmV4cG9ydCBjbGFzcyBUZXN0Q29tcG9uZW50IHtcclxuXHJcbiAgbGlzdDogQXJyYXk8VGVzdE1vZGVsPiA9IFtdO1xyXG4gIG15TmFtZTogc3RyaW5nO1xyXG4gIGVycm9yTWVzc2FnZTogc3RyaW5nO1xyXG4gIGhlcm9lczogVGVzdE1vZGVsW107XHJcblxyXG4gIGNvbnN0cnVjdG9yKHByaXZhdGUgaHR0cDogSHR0cCkge1xyXG4gICAgdGhpcy5HZXQoKTtcclxuXHJcblxyXG4gIH1cclxuICBwcml2YXRlIGhlcm9lc1VybCA9ICdhcGkvVGVzdEFwaSc7ICAvLyBVUkwgdG8gd2ViIEFQSVxyXG5cclxuICBHZXQoKTogT2JzZXJ2YWJsZTxUZXN0TW9kZWxbXT4ge1xyXG4gICAgcmV0dXJuIHRoaXMuaHR0cC5nZXQodGhpcy5oZXJvZXNVcmwpXHJcbiAgICAgIC5tYXAodGhpcy5leHRyYWN0RGF0YSlcclxuICAgICAgLmNhdGNoKHRoaXMuaGFuZGxlRXJyb3IpO1xyXG4gIH1cclxuXHJcbiAgcHJpdmF0ZSBleHRyYWN0RGF0YShyZXM6IFJlc3BvbnNlKSB7XHJcbiAgICBsZXQgYm9keSA9IHJlcy5qc29uKCk7XHJcbiAgICByZXR1cm4gYm9keS5kYXRhIHx8IHt9O1xyXG4gIH1cclxuXHJcbiAgcHJpdmF0ZSBoYW5kbGVFcnJvcihlcnJvcjogYW55KSB7XHJcbiAgICAvLyBJbiBhIHJlYWwgd29ybGQgYXBwLCB3ZSBtaWdodCB1c2UgYSByZW1vdGUgbG9nZ2luZyBpbmZyYXN0cnVjdHVyZVxyXG4gICAgLy8gV2UnZCBhbHNvIGRpZyBkZWVwZXIgaW50byB0aGUgZXJyb3IgdG8gZ2V0IGEgYmV0dGVyIG1lc3NhZ2VcclxuICAgIGxldCBlcnJNc2cgPSAoZXJyb3IubWVzc2FnZSkgPyBlcnJvci5tZXNzYWdlIDpcclxuICAgICAgZXJyb3Iuc3RhdHVzID8gYCR7ZXJyb3Iuc3RhdHVzfSAtICR7ZXJyb3Iuc3RhdHVzVGV4dH1gIDogJ1NlcnZlciBlcnJvcic7XHJcbiAgICBjb25zb2xlLmVycm9yKGVyck1zZyk7IC8vIGxvZyB0byBjb25zb2xlIGluc3RlYWRcclxuICAgIHJldHVybiBPYnNlcnZhYmxlLnRocm93KGVyck1zZyk7XHJcbiAgfVxyXG5cclxuXHJcbiAgLy9jb25zdHJ1Y3Rvcihwcml2YXRlIHNlcnZpY2U6IFNlcnZpY2UpIHtcclxuICAvLyAgdGhpcy5nZXRIZXJvZXMoKTtcclxuICAvL30gXHJcbiAgLy9nZXRIZXJvZXMoKSB7XHJcbiAgLy8gIHRoaXMuc2VydmljZS5HZXQoKVxyXG4gIC8vICAgIC5zdWJzY3JpYmUoXHJcbiAgLy8gICAgaGVyb2VzID0+IHRoaXMuaGVyb2VzID0gaGVyb2VzLFxyXG4gIC8vICAgIGVycm9yID0+IHRoaXMuZXJyb3JNZXNzYWdlID0gPGFueT5lcnJvcik7XHJcbiAgLy99XHJcbiAgXHJcblxyXG4gIC8vZ2V0RGF0YSgpIHtcclxuICAvLyAgdGhpcy5odHRwLmdldCgnYXBpL1Rlc3RBcGknKVxyXG4gIC8vICAgIC5tYXAoKHJlczogUmVzcG9uc2UpID0+IHJlcy5qc29uKCkpXHJcbiAgLy8gICAgLnN1YnNjcmliZShcclxuICAvLyAgICAgIGRhdGEgPT4geyB0aGlzLmxpc3QgPSBkYXRhIH0sXHJcbiAgLy8gICAgICBlcnIgPT4gY29uc29sZS5lcnJvcihlcnIpLFxyXG4gIC8vICAgICAgKCkgPT4gY29uc29sZS5sb2coJ2RvbmUnKVxyXG4gIC8vICAgICk7XHJcbiAgLy99XHJcblxyXG5cclxuICAvLy8vIHRvIGdlbmVyYXRlIHRoZSBKU09OIG9iamVjdCBhcyBhcnJheVxyXG4gIC8vZ2VuZXJhdGVBcnJheShvYmopIHtcclxuICAvLyAgcmV0dXJuIE9iamVjdC5rZXlzKG9iaikubWFwKChrZXkpID0+IHsgcmV0dXJuIG9ialtrZXldIH0pO1xyXG4gIC8vfVxyXG59XHJcbiJdLCJzb3VyY2VSb290IjoiL3NvdXJjZS8ifQ==
