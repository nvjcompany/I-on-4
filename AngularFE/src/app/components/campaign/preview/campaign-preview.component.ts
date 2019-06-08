import { Component, OnInit } from '@angular/core';
import { CampaignsService } from '../../../core/services/campaigns/capmaigns.service';
import { ActivatedRoute } from '@angular/router';
import { CampaignViewModel } from '../../../core/models/campaign/campaignViewModel';

@Component({
  selector: 'app-campaign-preview',
  templateUrl: './campaign-preview.component.html',  
})
export class CampaignPreviewComponent implements OnInit {
  public campaign: CampaignViewModel;
  constructor(private service: CampaignsService,
    private route: ActivatedRoute) { }


  ngOnInit(): void {
    this.campaign = new CampaignViewModel();
    let campaignId = this.route.snapshot.paramMap.get('id');
    this.service
      .find(parseInt(campaignId))
      .then((campaign: CampaignViewModel) => {
        this.campaign = campaign;
      });
  }
}
