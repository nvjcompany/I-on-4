import { Component } from '@angular/core';
import {ListingFormViewModel} from '../../../core/models/listings/listingFormViewModel';
import {EditorConfigService} from '../../../core/services/editor/config';
import {DatePickerConfigService} from '../../../core/services/datepicker/date-picker-config.service';
import {StaticDataService} from '../../../core/services/static-data/static-data.service';
import {CityViewModel} from '../../../core/models/static-data/cityViewModel';
import { ListingsService } from '../../../core/services/listings/listings.service';
import {Route, Router} from '@angular/router';

@Component({
  selector: 'app-listing-form',
  templateUrl: './listing-form.component.html',
  styleUrls: ['./listing-form.component.scss']
})
export class ListingFormComponent {
  public listing: ListingFormViewModel = new ListingFormViewModel();
  public cities: CityViewModel[];
  public hasError: boolean;

  constructor(private editorConfigService: EditorConfigService,
              private datepickerConfigService: DatePickerConfigService,
              private staticDataService: StaticDataService,
              private listingService: ListingsService,
              private router: Router
            )
  {
    this.staticDataService
      .getCities()
      .then((cities: CityViewModel[]) => {
          this.cities = cities;
      })
  }

  saveListing()
  {
    this.listingService.store(this.listing)
    .then((isOk: boolean)=>{
      if(isOk){
        this.router.navigateByUrl('listings');
      }
      else
      {
        window.scroll(0,0);
        this.hasError = true;
      }
    });
  }
}
