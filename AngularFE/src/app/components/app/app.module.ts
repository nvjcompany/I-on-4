import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import {InterceptService} from '../../core/interceptors/intercept.service';
import { AppRoutingModule } from '../../core/app-routing/app-routing.module'
import { LoginModule } from '../../components/login/login.module';
import { DashboardModule } from '../../components/dashboard/dashboard/dashboard.module';
import { RouterModule } from '@angular/router';
import { NavbarComponent } from '../../components/navbar/navbar.component';
import { FormsModule } from '@angular/forms';
import { IdentityService } from '../../core/services/auth/identity/identity.service';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    LoginModule,
    DashboardModule,
    RouterModule.forRoot([]),
    HttpClientModule
  ],
  providers: [InterceptService, {
    provide: HTTP_INTERCEPTORS,
    useClass: InterceptService,
    multi: true
  }, IdentityService],
  bootstrap: [AppComponent]
})
export class AppModule { }
