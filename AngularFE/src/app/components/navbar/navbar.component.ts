import { Component } from '@angular/core';
import { IdentityService } from '../../core/services/auth/identity/identity.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
})
export class NavbarComponent
{
  constructor(private identityService: IdentityService) { }
}
