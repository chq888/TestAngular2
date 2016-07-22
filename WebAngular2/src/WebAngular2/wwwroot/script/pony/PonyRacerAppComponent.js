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
