import { MainComponent } from "./MainComponent";
import { PonyRacerAppComponent } from "./pony/PonyRacerAppComponent";
import { bootstrap }    from "@angular/platform-browser-dynamic";
import { HTTP_PROVIDERS } from "@angular/http";

bootstrap(PonyRacerAppComponent, [HTTP_PROVIDERS]);
