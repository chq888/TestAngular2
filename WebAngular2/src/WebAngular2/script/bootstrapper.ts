import {MainComponent} from "./main";
import { bootstrap }    from "@angular/platform-browser-dynamic";
import {HTTP_PROVIDERS} from "@angular/http";

bootstrap(MainComponent, [HTTP_PROVIDERS]);
