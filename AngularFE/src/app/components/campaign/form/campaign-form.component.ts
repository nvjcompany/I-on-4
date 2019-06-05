import { Component } from '@angular/core';
import { CampaignViewModel } from '../../../core/models/campaign/campaignViewModel';
import { CampaignsService } from '../../../core/services/campaigns/capmaigns.service';
import { DatePickerConfigService } from 'src/app/core/services/datepicker/date-picker-config.service';

@Component({
  selector: 'app-campaign-form',
  templateUrl: './campaign-form.component.html',
  styleUrls: ['./campaign-form.component.scss']
})
export class CampaignFormComponent
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
