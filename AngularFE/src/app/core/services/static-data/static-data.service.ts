import {Injectable} from '@angular/core';
import {CityViewModel} from '../../models/static-data/cityViewModel';
import {HttpClient} from '@angular/common/http';

@Injectable()
export class StaticDataService
{
  constructor(private http: HttpClient){}

  getCities(): Promise<CityViewModel[]>
  {
    return this.http.get('get-cities')
      .toPromise()
      .then((cities: CityViewModel[])=>{
        return cities;
      })
  }
}
