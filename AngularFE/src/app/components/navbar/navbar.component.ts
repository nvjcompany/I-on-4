import { Component, OnInit } from '@angular/core';
import { IdentityService } from '../../core/services/auth/identity/identity.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  public isLogged: boolean;
  constructor(private identityService: IdentityService) { }

  ngOnInit() {
    this.isLogged = this.identityService.isLoggedIn();
  }

}
