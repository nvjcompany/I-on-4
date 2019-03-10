import { NgModule } from '@angular/core';

import { RegisterComponent } from './register.component';
import { RegisterRoutingModule } from './register-routing.module';
import { TranslateModule } from '@ngx-translate/core';
import { FormsModule } from '@angular/forms';
import { RegisterService } from '../../core/services/auth/register/register.service';

@NgModule({
  declarations: [RegisterComponent],
  imports: [
    RegisterRoutingModule,
    TranslateModule,
    FormsModule
  ],
  providers: [
    RegisterService
  ]
})
export class RegisterModule { }
