import { NgModule } from '@angular/core';

import { HomePageComponent } from './home-page.component';
import { HomePageRoutingModule } from './home-page-routing.module';
import { HeaderComponent } from './header/header.component';
import { TranslateModule } from '@ngx-translate/core';
import { FeaturedCompaniesComponent } from './featured-companies/featured-companies.component';

@NgModule({
  declarations: [HomePageComponent, HeaderComponent, FeaturedCompaniesComponent],
  imports: [
    HomePageRoutingModule,
    TranslateModule
  ],
  providers: [
  ]
})
export class HomePageModule { }
