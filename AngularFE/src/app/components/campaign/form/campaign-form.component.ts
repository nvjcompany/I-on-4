import { Component } from '@angular/core';
import { CampaignViewModel } from '../../../core/models/campaign/campaignViewModel';
import { CampaignsService } from '../../../core/services/campaigns/capmaigns.service';
import { DatePickerConfigService } from 'src/app/core/services/datepicker/date-picker-config.service';
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: 'app-campaign-form',
  templateUrl: './campaign-form.component.html',
  styleUrls: ['./campaign-form.component.scss']
})
export class CampaignFormComponent {
  public campaign: CampaignViewModel = new CampaignViewModel();
  
  constructor(private service: CampaignsService, 
    private datepickerConfigService: DatePickerConfigService,
    private activeRoute: ActivatedRoute) { 
    let id = this.activeRoute.snapshot.paramMap.get('id');
    if (id !== null) {
      this.service.find(parseInt(id))
        .then((campaign: CampaignViewModel) => {
          this.campaign = campaign;          
        });
    }
  }

  createCampaign() {
    if (this.campaign.id > 0) {
      this.service.update(this.campaign)
        .then(user => {
          alert("Campaign updated!");
        })
    }
    else {
      this.service.createCampaign(this.campaign)
        .then(user => {
          alert('Campaign created!');
        });
    }
  }
}