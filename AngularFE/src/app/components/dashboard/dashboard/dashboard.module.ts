import { NgModule } from '@angular/core';
import { StudentHomeComponent } from '../student/student-home.component';
import { CompanyHomeComponent } from '../company/company-home.component';
import { AdministratorHomeComponent } from '../administrator/administrator-home.component';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { FormsModule } from '@angular/forms';
import { DashboardComponent } from './dashboard.component';
import { CommonModule } from '@angular/common';  
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
  declarations: [
    StudentHomeComponent,
    CompanyHomeComponent,
    AdministratorHomeComponent,
    DashboardComponent
  ],
  imports: [
    DashboardRoutingModule,
    FormsModule,
    CommonModule
  ],
  providers:[]
})
export class DashboardModule { }
