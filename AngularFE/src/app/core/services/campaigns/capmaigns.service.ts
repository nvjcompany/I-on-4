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

    list(page: number, title: string, active: boolean): Promise<CampaignPageViewModel> {
        return this.http.get(`campaigns?page=${page}&title=${title}&active=${active}`)
            .toPromise()
            .then((response: CampaignPageViewModel) => {
                return response;
            });
    }

    update(model: CampaignViewModel): Promise<boolean> {
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
