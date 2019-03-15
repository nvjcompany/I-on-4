import { NgModule } from '@angular/core';

import { LoginComponent } from './login.component';
import { LoginRoutingModule } from './login-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginService } from '../../core/services/auth/login/login.service'
import { TranslateModule } from '@ngx-translate/core';
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
  declarations: [LoginComponent],
  imports: [
    LoginRoutingModule,
    FormsModule,
    BrowserModule,
    ReactiveFormsModule,
    TranslateModule
  ],
  providers:[
    LoginService
  ]
})
export class LoginModule { }
