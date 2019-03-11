import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListingFormComponent } from './form/listing-form.component';

const routes: Routes = [
  { path: 'listing/create', component: ListingFormComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ListingsRoutingModule { }
