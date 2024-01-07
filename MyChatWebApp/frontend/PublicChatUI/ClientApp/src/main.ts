import { enableProdMode, importProvidersFrom, ApplicationConfig } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';
import { APP_CONFIG, AppConfig } from './app/app.config';
import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { provideRouter, withComponentInputBinding } from '@angular/router';

//export function getBaseUrl() {
//  return 'https://localhost:44379/';
//  //  return document.getElementsByTagName('base')[0].href;
//}

//// providers: [{ provide: APP_BASE_HREF, useValue: '/my-app/' },  // used for routing

//const providers = [
//  { provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] }
//];
////if (environment.production) {
////  enableProdMode();
////}

//platformBrowserDynamic(providers).bootstrapModule(AppModule)
//  .catch(err => console.log(err));


//export const appConfig: ApplicationConfig = {
//  providers: [
//    //provideRouter(appRoutes, withComponentInputBinding()),
//    importProvidersFrom(BrowserAnimationsModule),
//  ],
//};
//fetch('/assets/appconfig.json')
//  .then((resp) => resp.json())
//  .then((config) => {
//    const { providers, ...rest } = appConfig;

//    if (environment.production) {
//      enableProdMode()
//    }

//    bootstrapApplication(AppComponent, {
//      ...rest,
//      providers: [...providers, { provide: APP_CONFIG, useValue: config }],
//    }).catch((err) => console.error(err));
//  });



//if (environment.production) {
//  enableProdMode();
//}
//platformBrowserDynamic().bootstrapModule(AppModule).then(ref => {
//  // Ensure Angular destroys itself on hot reloads.
//  try {
//    if (window['ngRef']) {
//      window['ngRef'].destroy();
//    }
//    window['ngRef'] = ref;
//  }
//  catch (err2) {
//  }

//  // Otherwise, log the boot error
//}).catch(err => console.error(err));


fetch('https://localhost:44560/assets/appconfig.json')
  .then((resp) => resp.json())
  .then((config) => {
    if (environment.production) {
      enableProdMode();
    }

    platformBrowserDynamic([{ provide: APP_CONFIG, useValue: config }])
      .bootstrapModule(AppModule).then(ref => {
        // Ensure Angular destroys itself on hot reloads.
        try {
          if (window['ngRef']) {
            window['ngRef'].destroy();
          }
          window['ngRef'] = ref;
        }
        catch (err2) {
        }

        // Otherwise, log the boot error
      }).catch(err => console.error(err));
  });
