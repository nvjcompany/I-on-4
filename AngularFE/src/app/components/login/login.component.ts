import { Component, OnInit } from '@angular/core';
import { LoginViewModel } from '../../core/models/loginViewModel';
import {LoginService} from '../../core/services/auth/login/login.service';
import {Router} from '@angular/router';
import { IdentityService } from '../../core/services/auth/identity/identity.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  private navigateToDashboard(): void
  {
    let currentRole = this.identityService.getRole();

    if(currentRole == null){return;}
    this.router.navigateByUrl('dashboard');
  }

  public loginDetails: LoginViewModel;
  public hasError: boolean;

  constructor(private service: LoginService,
              private router: Router,
              private identityService: IdentityService) {
    this.loginDetails = new LoginViewModel();
    this.hasError = false;
  }

  ngOnInit()
  {
    this.navigateToDashboard();
  }

  attemptLogin()
  {
    this.service.attempt(this.loginDetails)
    .then(r=> {
      if(!r)
      {
        this.hasError = true;
      }
      else
      {
        this.navigateToDashboard();
      }
    });
  }
}
