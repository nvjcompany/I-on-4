import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CampaignFormComponent } from './form/campaign-form.component';
import { CampaignListComponent } from './list/campaign-list.component';
import { CampaignPreviewComponent } from "./preview/campaign-preview.component";

const routes: Routes = [
  { path: 'campaign/create', component: CampaignFormComponent },
  { path: 'campaigns', component: CampaignListComponent },
  { path: 'campaign/:id', component: CampaignFormComponent},
  { path: 'campaign-preview/:id', component: CampaignPreviewComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CampaignRoutingModule { }
