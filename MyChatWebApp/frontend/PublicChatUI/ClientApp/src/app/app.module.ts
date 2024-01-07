import { BrowserModule } from '@angular/platform-browser';
import { APP_INITIALIZER, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { FooterComponent } from './components/footer/footer.component';
import { AppConfigService } from './services/appconfig.service';

const appInitializerFn = (appConfig: AppConfigService) => {
  return () => appConfig.loadConfig();
};

//const appInitializerFn = () => {
//  return () => {
//    console.log('entering app initializer')
//    return new Promise((resolve, reject) => {
//      setTimeout(() => {
//        console.log('resolving app initializer');
//        resolve();
//      }, 5000);
//    });
//  };
//};


@NgModule({
  declarations: [
    AppComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: AppComponent, pathMatch: 'full' }
    ])
  ],
  providers:
    [AppConfigService,
    {
      provide: APP_INITIALIZER,
      useFactory: appInitializerFn,
      multi: true,
      deps: [AppConfigService]
    }
],
  bootstrap: [AppComponent]
})
export class AppModule { }
