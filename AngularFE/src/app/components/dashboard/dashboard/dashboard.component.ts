import { Component, OnInit } from '@angular/core';
import { IdentityService } from '../../../core/services/auth/identity/identity.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  public role: string;
  constructor(private identityService: IdentityService) { }

  ngOnInit()
  {
    this.role = this.identityService.getRole();
    console.log(this.role);
  }

}
