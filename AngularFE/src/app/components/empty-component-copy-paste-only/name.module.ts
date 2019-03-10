import { NgModule } from '@angular/core';

import { NameComponent } from './name.component';
import { NameRoutingModule } from './name-routing.module';
import { TranslateModule } from '@ngx-translate/core';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [NameComponent],
  imports: [
    NameRoutingModule,
    TranslateModule,
    FormsModule
  ],
  providers: [
  ]
})
export class NameModule { }
