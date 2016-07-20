import { Component } from "@angular/core";

@Component({
    selector: "app-shell",
    template: `
<div>
    Hello, {{title}}
</div>
    `
})

export class HomeComponent {
    title: string;
    constructor() {
        this.title = "World!!!";
    }
}