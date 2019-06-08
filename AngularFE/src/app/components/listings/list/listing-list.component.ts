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
  public citySearch;
  public titleSearch;
  public isCompany: boolean;

  private getListings(page: number): void
  {
    this.listingService.list(page, this.citySearch, this.titleSearch)
      .then( (model: ListingPageViewModel) => {
        this.listings = model.listings;
        this.page = model.page;
        this.total = model.total;
      });
  }

  private getCities()
  {
    this.staticDataService.getCities()
      .then((cities: CityViewModel[]) => {
      this.cities = cities;
    })
  }

  private load(page: number): void
  {
    this.getListings(page);
    this.getCities();
  }

  search()
  {
    this.getListings(this.page);
  }

  constructor(private listingService: ListingsService, private staticDataService: StaticDataService)
  {
    this.isCompany = localStorage.getItem('ROLE') == 'Company' ? true : false;
    this.citySearch = '';
    this.titleSearch = '';
    this.load(1);
  }

  resetFilter()
  {
    this.citySearch = '';
    this.titleSearch = '';
    this.getListings(1);
  }

  delete(index)
  {
    let listingToDelete = this.listings[index].id;

    this.listingService.delete(listingToDelete)
      .then((isSucceed: boolean) => {
        this.load(this.page);
      });
  }

  changePage(page)
  {
    this.getListings(page);
  }
}
