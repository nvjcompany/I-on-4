import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import {InterceptService} from '../../core/interceptors/intercept.service';
import { AppRoutingModule } from '../../core/app-routing/app-routing.module'
import { LoginModule } from '../../components/login/login.module';
import { DashboardModule } from '../../components/dashboard/dashboard/dashboard.module';
import { RouterModule } from '@angular/router';
import { NavbarComponent } from '../../components/navbar/navbar.component';
import { FormsModule } from '@angular/forms';
import { IdentityService } from '../../core/services/auth/identity/identity.service';
import {TranslateLoader, TranslateModule} from '@ngx-translate/core';
import {TranslateHttpLoader} from '@ngx-translate/http-loader';
import { LogoutModule } from '../logout/logout.module';
import { HomePageModule } from '../home-page/home-page.module';
import { FooterComponent } from '../footer/footer.component';
import { RegisterModule } from '../register/register.module';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    LoginModule,
    LogoutModule,
    DashboardModule,
    HomePageModule,
    RegisterModule,
    RouterModule.forRoot([]),
    HttpClientModule,
    TranslateModule.forRoot({
      loader: {
          provide: TranslateLoader,
          useFactory: HttpLoaderFactory,
          deps: [HttpClient]
      }
  })
  ],
  providers: [InterceptService, {
    provide: HTTP_INTERCEPTORS,
    useClass: InterceptService,
    multi: true
  }, IdentityService],
  bootstrap: [AppComponent]
})
export class AppModule { }


export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}