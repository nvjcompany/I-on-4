import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ListingFormViewModel} from '../../models/listings/listingFormViewModel';

@Injectable()
export class ListingsService
{
  constructor(private http: HttpClient){}
  store(model: ListingFormViewModel): Promise<boolean>
  {
    return this.http.post('listings', model)
      .toPromise()
      .then(response => {
          return true;
        }
      );
  }
}
