import { Component } from "@angular/core";
import { RaceListComponent } from "./RaceListComponent";
@Component({
  selector: "app-shell",
  template: '<h1>Pony racer</h1><h2>{{ numberOfUsers }} users</h2><h2>Welcome {{ user.name }} - {{ person?.name }} </h2><br/> <ns-races></ns-races>',
  directives: [RaceListComponent]
})
export class PonyRacerAppComponent {

  numberOfUsers: number = 100;
  user: any = { name: "3aaa" };
  person: any;

}