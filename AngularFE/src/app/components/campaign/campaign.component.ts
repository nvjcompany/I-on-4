import { Component } from '@angular/core';
import { CampaignViewModel } from '../../core/models/campaign/campaignViewModel';
import { CampaignsService } from '../../core/services/campaigns/capmaigns.service';
import { DatePickerConfigService } from 'src/app/core/services/datepicker/date-picker-config.service';

@Component({
  selector: 'app-campaign',
  templateUrl: './campaign.component.html',
  styleUrls: ['./campaign.component.scss']
})
export class CampaignComponent
{
  public campaign: CampaignViewModel = new CampaignViewModel();
  constructor(private service: CampaignsService,
              private datepickerConfigService: DatePickerConfigService) { }

  createCampaign(){
    //await result;
    
    this.service.createCampaign(this.campaign)
    .then(user=>{
      alert('Campaign created!');  
    });
  }
}
