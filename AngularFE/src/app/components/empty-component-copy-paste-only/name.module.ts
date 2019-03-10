import { NgModule } from '@angular/core';

import { NameComponent } from './name.component';
import { NameRoutingModule } from './name-routing.module';
import { TranslateModule } from '@ngx-translate/core';

@NgModule({
  declarations: [NameComponent],
  imports: [
    NameRoutingModule,
    TranslateModule
  ],
  providers: [
  ]
})
export class NameModule { }
