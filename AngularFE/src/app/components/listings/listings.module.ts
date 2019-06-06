import { NgModule } from '@angular/core';
import { ListingFormComponent } from './form/listing-form.component';
import { ListingsRoutingModule } from './listings-routing.module';
import { TranslateModule } from '@ngx-translate/core';
import { FormsModule } from '@angular/forms';
import { AngularEditorModule } from '@kolkov/angular-editor';
import { EditorConfigService } from '../../core/services/editor/config';
import { NgDatepickerModule } from 'ng2-datepicker';
import { DatePickerConfigService } from '../../core/services/datepicker/date-picker-config.service';
import { StaticDataService } from '../../core/services/static-data/static-data.service';
import { ListingsService } from '../../core/services/listings/listings.service';
import { ListingListComponent } from './list/listing-list.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ListingPreviewComponent } from './preview/listing-preview.component';

@NgModule({
  declarations: [
    ListingFormComponent,
    ListingListComponent,
    ListingPreviewComponent
  ],
  imports: [
    ListingsRoutingModule,
    TranslateModule,
    AngularEditorModule,
    NgDatepickerModule,
    FormsModule,
    NgbModule
  ],
  providers: [
    EditorConfigService,
    DatePickerConfigService,
    StaticDataService,
    ListingsService
  ]
})
export class ListingsModule { }