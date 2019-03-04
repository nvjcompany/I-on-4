import { NgModule } from '@angular/core';

import { LoginComponent } from './login.component';
import { LoginRoutingModule } from './login-routing.module';
import { FormsModule } from '@angular/forms';
import { LoginService } from '../../core/services/auth/login/login.service'

@NgModule({
  declarations: [LoginComponent],
  imports: [
    LoginRoutingModule,
    FormsModule
  ],
  providers:[
    LoginService
  ]
})
export class LoginModule { }
