import { Component } from '@angular/core';
import { ListingFormViewModel } from '../../../core/models/listings/listingFormViewModel';
import { EditorConfigService } from '../../../core/services/editor/config';
import { DatePickerConfigService } from '../../../core/services/datepicker/date-picker-config.service';
import { StaticDataService } from '../../../core/services/static-data/static-data.service';
import { ListingsService } from '../../../core/services/listings/listings.service';
import {ListingPageViewModel} from '../../../core/models/listings/listingPageViewModel';
import {Router} from '@angular/router';
import {CityViewModel} from '../../../core/models/static-data/cityViewModel';

@Component({
  selector: 'app-listing-list',
  templateUrl: './listing-list.component.html',
  styleUrls: ['./listing-list.component.scss']
})
export class ListingListComponent {
  public listings: ListingFormViewModel[] = [];
  public cities: CityViewModel[] = [];
  public page: number = 1;
  public perPage: number = 10;
  public total: number = 0;

  private load(page: number): void
  {
    this.listingService.list(page)
      .then( (model: ListingPageViewModel) => {
        this.listings = model.listings;
        this.page = model.page;
        this.total = model.total;
      });

    this.staticDataService.getCities().then((cities: CityViewModel[]) => {
      this.cities = cities;
    })
  }

  constructor(private listingService: ListingsService, private staticDataService: StaticDataService)
  {
    this.load(1);
  }

  delete(index)
  {
    let listingToDelete = this.listings[index].id;

    this.listingService.delete(listingToDelete)
      .then((isSucceed: boolean) => {
        this.listings.splice(index,1);
      });
  }

  changePage(page)
  {
    this.load(page);
  }
}
