import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListingFormComponent } from './form/listing-form.component';
import {ListingListComponent} from './list/listing-list.component';

const routes: Routes = [
  { path: 'listing/create', component: ListingFormComponent, pathMatch: 'full' },
  { path: 'listings', component: ListingListComponent},
  { path: 'listing/:id', component: ListingFormComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ListingsRoutingModule { }
