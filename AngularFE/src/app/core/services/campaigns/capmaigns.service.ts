import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {CampaignViewModel} from '../../models/campaign/campaignViewModel';

@Injectable()
export class CampaignsService
{
  constructor(private http: HttpClient){}

  createCampaign(model: CampaignViewModel): Promise<boolean>
    {
        return this.http.post('campaigns', model)
            .toPromise()
            .then( ( ress: boolean ) => {
                return true;
            },
            err => {
                throw new DOMException("ERROR");
            }
        );
    }
}
