import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ListingFormViewModel} from '../../models/listings/listingFormViewModel';
import {ListingPageViewModel} from '../../models/listings/listingPageViewModel';

@Injectable()
export class ListingsService
{
  constructor(private http: HttpClient){}

  list(page: number) : Promise<ListingPageViewModel>
  {
    return this.http.get(`listings?page=${page}`)
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
}
