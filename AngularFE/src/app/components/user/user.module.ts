import { NgModule } from '@angular/core';

import { UserComponent } from './user.component';
import { UserRoutingModule } from './user-routing.module';
import { TranslateModule } from '@ngx-translate/core';
import { FormsModule } from '@angular/forms';
import { UserService } from "../../core/services/user/user.service";

@NgModule({
  declarations: [UserComponent],
  imports: [
    UserRoutingModule,
    TranslateModule,
    FormsModule
  ],
  providers: [
    UserService
  ]
})
export class UserModule { }
