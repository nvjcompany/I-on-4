import {Component, OnInit} from '@angular/core';
import {ListingFormViewModel} from '../../../core/models/listings/listingFormViewModel';
import {EditorConfigService} from '../../../core/services/editor/config';
import {DatePickerConfigService} from '../../../core/services/datepicker/date-picker-config.service';
import {StaticDataService} from '../../../core/services/static-data/static-data.service';
import {CityViewModel} from '../../../core/models/static-data/cityViewModel';
import { ListingsService } from '../../../core/services/listings/listings.service';
import {ActivatedRoute, Route, Router} from '@angular/router';

@Component({
  selector: 'app-listing-form',
  templateUrl: './listing-form.component.html',
  styleUrls: ['./listing-form.component.scss']
})
export class ListingFormComponent{
  private handleResponse(isOk: boolean)
  {
    if(isOk){
      this.router.navigateByUrl('listings');
    }
    else
    {
      window.scroll(0,0);
      this.hasError = true;
    }
  }

  public listing: ListingFormViewModel = new ListingFormViewModel();
  public cities: CityViewModel[];
  public hasError: boolean;


  constructor(private editorConfigService: EditorConfigService,
              private datepickerConfigService: DatePickerConfigService,
              private staticDataService: StaticDataService,
              private listingService: ListingsService,
              private router: Router,
              private activeRoute: ActivatedRoute
              )
  {
    this.staticDataService
      .getCities()
      .then((cities: CityViewModel[]) => {
          this.cities = cities;
      });
    let id = this.activeRoute.snapshot.paramMap.get('id');
    if(id !== null)
    {
      this.listingService.find(parseInt(id))
        .then((listing: ListingFormViewModel)=>{
            this.listing = listing;
        });
    }
  }

  saveListing()
  {
    if(this.listing.id > 0)
    {
      this.listingService.update(this.listing)
        .then((isOk: boolean)=>{
          this.handleResponse(isOk);
        });
    }
    else
    {
       this.listingService.store(this.listing)
        .then((isOk: boolean)=>{
            this.handleResponse(isOk);
        });
    }
  }


}
