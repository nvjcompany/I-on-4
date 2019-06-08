import { NgModule } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ApplicationsRoutingModule } from './applications-routing.module';
import { ListComponent } from './list/list.component';
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
  declarations: [
      ListComponent
  ],
  imports: [
    TranslateModule,
    FormsModule,
    NgbModule,
    ApplicationsRoutingModule,
    BrowserModule
  ],
  providers: [
  ]
})export class ApplicationsModule { }
