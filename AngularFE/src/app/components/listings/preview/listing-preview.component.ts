import {Component, OnInit} from '@angular/core';
import {ListingsService} from '../../../core/services/listings/listings.service';
import {ActivatedRoute} from '@angular/router';
import {ListingFormViewModel} from '../../../core/models/listings/listingFormViewModel';

@Component({
  selector: 'app-listing-preview',
  templateUrl: './listing-preview.component.html',
  styleUrls: ['./listing-preview.component.scss']
})
export class ListingPreviewComponent implements OnInit
{
  public listing: ListingFormViewModel;
  constructor(private listingService: ListingsService,
              private route: ActivatedRoute)
  {}


  ngOnInit(): void {
    this.listing = new ListingFormViewModel();
    let listingId = this.route.snapshot.paramMap.get('id');
    this.listingService
      .find(parseInt(listingId))
      .then((listing: ListingFormViewModel)=>{
        this.listing = listing;
      });
  }
}
