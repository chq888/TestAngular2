import { TestComponent } from "./home/TestComponent";
import { PonyRacerAppComponent } from "./pony/PonyRacerAppComponent";
import { bootstrap }    from "@angular/platform-browser-dynamic";
//import { ROUTER_PROVIDERS } from "@angular/router";
import { HTTP_PROVIDERS, HTTP_BINDINGS } from "@angular/http";

bootstrap(TestComponent, [HTTP_BINDINGS, HTTP_PROVIDERS]);
