import { NgModule } from '@angular/core';

import { CampaignFormComponent } from './form/campaign-form.component';
import { CampaignRoutingModule } from './campaign-routing.module';
import { TranslateModule } from '@ngx-translate/core';
import { FormsModule } from '@angular/forms';
import { NgDatepickerModule } from 'ng2-datepicker';
import { DatePickerConfigService } from 'src/app/core/services/datepicker/date-picker-config.service';
import { CampaignsService } from 'src/app/core/services/campaigns/capmaigns.service';
import { CampaignListComponent } from './list/campaign-list.component';
import { CampaignPreviewComponent } from "./preview/campaign-preview.component";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    CampaignFormComponent,
    CampaignListComponent,
    CampaignPreviewComponent],
  imports: [
    CampaignRoutingModule,
    TranslateModule,
    FormsModule,
    NgDatepickerModule,
    NgbModule
  ],
  providers: [
    DatePickerConfigService,
    CampaignsService
  ]
})
export class CampaignModule { }
