System.register(["@angular/core", "./RaceListComponent"], function(exports_1, context_1) {
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
    var core_1, RaceListComponent_1;
    var PonyRacerAppComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (RaceListComponent_1_1) {
                RaceListComponent_1 = RaceListComponent_1_1;
            }],
        execute: function() {
            let PonyRacerAppComponent = class PonyRacerAppComponent {
                constructor() {
                    this.numberOfUsers = 100;
                    this.user = { name: "3aaa" };
                }
            };
            PonyRacerAppComponent = __decorate([
                core_1.Component({
                    selector: "app-shell",
                    template: '<h1>Pony racer</h1><h2>{{ numberOfUsers }} users</h2><h2>Welcome {{ user.name }} - {{ person?.name }} </h2><br/> <ns-races></ns-races>',
                    directives: [RaceListComponent_1.RaceListComponent]
                }), 
                __metadata('design:paramtypes', [])
            ], PonyRacerAppComponent);
            exports_1("PonyRacerAppComponent", PonyRacerAppComponent);
        }
    }
});

//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInBvbnkvUG9ueVJhY2VyQXBwQ29tcG9uZW50LnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7O1lBT0E7Z0JBQUE7b0JBRUUsa0JBQWEsR0FBVyxHQUFHLENBQUM7b0JBQzVCLFNBQUksR0FBUSxFQUFFLElBQUksRUFBRSxNQUFNLEVBQUUsQ0FBQztnQkFHL0IsQ0FBQztZQUFELENBQUM7WUFYRDtnQkFBQyxnQkFBUyxDQUFDO29CQUNULFFBQVEsRUFBRSxXQUFXO29CQUNyQixRQUFRLEVBQUUsd0lBQXdJO29CQUNsSixVQUFVLEVBQUUsQ0FBQyxxQ0FBaUIsQ0FBQztpQkFDaEMsQ0FBQzs7cUNBQUE7WUFDRix5REFNQyxDQUFBIiwiZmlsZSI6InBvbnkvUG9ueVJhY2VyQXBwQ29tcG9uZW50LmpzIiwic291cmNlc0NvbnRlbnQiOlsiaW1wb3J0IHsgQ29tcG9uZW50IH0gZnJvbSBcIkBhbmd1bGFyL2NvcmVcIjtcclxuaW1wb3J0IHsgUmFjZUxpc3RDb21wb25lbnQgfSBmcm9tIFwiLi9SYWNlTGlzdENvbXBvbmVudFwiO1xyXG5AQ29tcG9uZW50KHtcclxuICBzZWxlY3RvcjogXCJhcHAtc2hlbGxcIixcclxuICB0ZW1wbGF0ZTogJzxoMT5Qb255IHJhY2VyPC9oMT48aDI+e3sgbnVtYmVyT2ZVc2VycyB9fSB1c2VyczwvaDI+PGgyPldlbGNvbWUge3sgdXNlci5uYW1lIH19IC0ge3sgcGVyc29uPy5uYW1lIH19IDwvaDI+PGJyLz4gPG5zLXJhY2VzPjwvbnMtcmFjZXM+JyxcclxuICBkaXJlY3RpdmVzOiBbUmFjZUxpc3RDb21wb25lbnRdXHJcbn0pXHJcbmV4cG9ydCBjbGFzcyBQb255UmFjZXJBcHBDb21wb25lbnQge1xyXG5cclxuICBudW1iZXJPZlVzZXJzOiBudW1iZXIgPSAxMDA7XHJcbiAgdXNlcjogYW55ID0geyBuYW1lOiBcIjNhYWFcIiB9O1xyXG4gIHBlcnNvbjogYW55O1xyXG5cclxufSJdLCJzb3VyY2VSb290IjoiL3NvdXJjZS8ifQ==
