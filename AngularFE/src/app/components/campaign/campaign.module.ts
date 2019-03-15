import { NgModule } from '@angular/core';

import { CampaignComponent } from './campaign.component';
import { CampaignRoutingModule } from './campaign-routing.module';
import { TranslateModule } from '@ngx-translate/core';
import { FormsModule } from '@angular/forms';
import { NgDatepickerModule } from 'ng2-datepicker';
import { DatePickerConfigService } from 'src/app/core/services/datepicker/date-picker-config.service';
import { CampaignsService } from 'src/app/core/services/campaigns/capmaigns.service';

@NgModule({
  declarations: [CampaignComponent],
  imports: [
    CampaignRoutingModule,
    TranslateModule,
    FormsModule,
    NgDatepickerModule
  ],
  providers: [
    DatePickerConfigService,
    CampaignsService
  ]
})
export class CampaignModule { }
