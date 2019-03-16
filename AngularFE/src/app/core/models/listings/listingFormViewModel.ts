import {CampaignViewModel} from '../campaign/campaignViewModel';
import {CityViewModel} from '../static-data/cityViewModel';
import {CompanyViewModel} from '../company/companyViewModel';

export class ListingFormViewModel
{
    public id: number;
    public title: string;
    public description: string;
    public companyId: number;
    public company: CompanyViewModel;
    public campaignId: number;
    public campaign: CampaignViewModel;
    public totalPositions: number;
    public registerFrom: string;
    public registerTo: string;
    public cityId: number;
    public city: CityViewModel;

    constructor()
    {
      this.company = new CompanyViewModel();
      this.campaign = new CampaignViewModel();
      this.city = new CityViewModel();
    }
}
