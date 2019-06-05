import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CampaignViewModel } from '../../models/campaign/campaignViewModel';
import { CampaignPageViewModel } from "../../models/campaign/campaignPageViewModel";

@Injectable()
export class CampaignsService {
    constructor(private http: HttpClient) { }

    createCampaign(model: CampaignViewModel): Promise<boolean> {
        return this.http.post('campaign/create', model)
            .toPromise()
            .then((ress: boolean) => {
                return true;
            },
                err => {
                    throw new DOMException("ERROR");
                }
            );
    }

    find(id: number): Promise<CampaignViewModel> {
        return this.http.get(`campaign/${id}`)
            .toPromise()
            .then((campaign: CampaignViewModel) => {                
                return campaign;
            });
    }

    list(page: number, title: string): Promise<CampaignPageViewModel> {
        return this.http.get(`campaigns?page=${page}&title=${title}`)
            .toPromise()
            .then((response: CampaignPageViewModel) => {
                return response;
            });
    }

    store(model: CampaignViewModel): Promise<boolean> {
        return this.http.post('campaigns', model)
            .toPromise()
            .then(response => {
                return true;
            },
                error => {
                    return false;
                }
            );
    }

    update(model: CampaignViewModel): Promise<boolean> {
        model.startDate = null;
        model.endDate = null;        
        model.name = null;
        model.isActive = null;
        return this.http.put(`campaign`, model)
            .toPromise()
            .then((response: boolean) => {
                return response;
            })
    }

    delete(id: number): Promise<boolean> {
        return this.http.delete(`campaign/${id}`)
            .toPromise()
            .then((isSucceed: boolean) => {
                return isSucceed;
            });
    }
}
