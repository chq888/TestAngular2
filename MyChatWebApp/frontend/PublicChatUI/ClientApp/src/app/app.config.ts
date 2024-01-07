import { InjectionToken } from "@angular/core"

export class AppConfig {
  serviceUrl: string
  name: string
  version: string
}

export let APP_CONFIG = new InjectionToken<AppConfig>('APP_CONFIG')
