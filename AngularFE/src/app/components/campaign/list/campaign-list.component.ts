import { Component } from '@angular/core';
import { CampaignViewModel } from '../../../core/models/campaign/campaignViewModel';
import { CampaignsService } from '../../../core/services/campaigns/capmaigns.service';
import { DatePickerConfigService } from 'src/app/core/services/datepicker/date-picker-config.service';
import { CampaignPageViewModel } from 'src/app/core/models/campaign/campaignPageViewModel';

@Component({
  selector: 'app-campaign-list',
  templateUrl: './campaign-list.component.html',
  styleUrls: ['./campaign-list.component.scss']
})
export class CampaignListComponent {
  public campaigns: CampaignViewModel[] = [];  
  public page: number = 1;
  public perPage: number = 10;
  public total: number = 0;
  public titleSearch;
  public active: boolean = false;

  private getCampaigns(page: number): void {
    this.service.list(page, this.titleSearch)
      .then((model: CampaignPageViewModel) => {
        this.campaigns = model.campaigns;
        this.page = model.page;
        this.total = model.total;
      });
  }

  private load(page: number): void {
    this.getCampaigns(page);
  }  

  constructor(private service: CampaignsService, 
    private datepickerConfigService: DatePickerConfigService) {
    this.load(1);
  }  

  getActive(){
    this.active = true;
  }

  search() {
    this.getCampaigns(this.page);
  }
  
  resetFilter()
  {   
    this.titleSearch = '';
    this.getCampaigns(1);
  }

  delete(index)
  {
    let campaignToDelete = this.campaigns[index].id;

    this.service.delete(campaignToDelete)
      .then((isSucceed: boolean) => {
        this.load(this.page);
      });
  }

  changePage(page)
  {
    this.getCampaigns(page);
  }
}
