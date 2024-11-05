import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {MyAuthInterceptor} from './services/auth-services/my-auth-interceptor.service';
import {MyAuthService} from './services/auth-services/my-auth.service';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule // Replace provideHttpClient() with HttpClientModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: MyAuthInterceptor,
      multi: true // Ensures multiple interceptors can be used if needed
    },
    MyAuthService // Ensure MyAuthService is available for the interceptor
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
