import { Component } from '@angular/core';
import {ListingFormViewModel} from '../../../core/models/listings/listingFormViewModel';
import {EditorConfigService} from '../../../core/services/editor/config';
import {DatePickerConfigService} from '../../../core/services/datepicker/date-picker-config.service';
import {StaticDataService} from '../../../core/services/static-data/static-data.service';
import {CityViewModel} from '../../../core/models/static-data/cityViewModel';

@Component({
  selector: 'app-listing-form',
  templateUrl: './listing-form.component.html',
  styleUrls: ['./listing-form.component.scss']
})
export class ListingFormComponent {
  public listing: ListingFormViewModel = new ListingFormViewModel();
  public cities: CityViewModel[];

  constructor(private editorConfigService: EditorConfigService,
              private datepickerConfigService: DatePickerConfigService,
              private staticDataService: StaticDataService)
  {
    this.staticDataService
      .getCities()
      .then((cities: CityViewModel[]) => {
          this.cities = cities;
      })
  }

  saveListing()
  {

  }
}
