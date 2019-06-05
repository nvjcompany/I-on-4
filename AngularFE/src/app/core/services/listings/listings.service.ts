import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ListingFormViewModel } from '../../models/listings/listingFormViewModel';
import { ListingPageViewModel } from '../../models/listings/listingPageViewModel';

@Injectable()
export class ListingsService
{
  constructor(private http: HttpClient){}

  find(id: number) : Promise<ListingFormViewModel>
  {
    return this.http.get(`listing/${id}`)
      .toPromise()
      .then((listing: ListingFormViewModel)=>{
          listing.registerTo = listing.registerTo.substring(0, 10);
          listing.registerFrom = listing.registerFrom.substring(0, 10);
          return listing;
      });
  }

  list(page: number, city: string, title: string) : Promise<ListingPageViewModel>
  {
    return this.http.get(`listings?page=${page}&cityId=${city}&title=${title}`)
      .toPromise()
      .then((response: ListingPageViewModel)=>{
        return response;
      });
  }

  store(model: ListingFormViewModel): Promise<boolean>
  {
    return this.http.post('listings', model)
      .toPromise()
      .then(response => {
          return true;
        },
        error => {
          return false;
        }
      );
  }

  update(model: ListingFormViewModel): Promise<boolean>
  {
    model.city = null;
    model.company = null;
    model.campaign = null;
    return this.http.put(`listing`, model)
      .toPromise()
      .then( (response: boolean) => {
        return response;
      })
  }

  delete(id: number): Promise<boolean>
  {
    return this.http.delete(`listing/${id}`)
      .toPromise()
      .then((isSucceed: boolean)=>{
          return isSucceed;
      });
  }
}
