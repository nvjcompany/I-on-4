import { Component, OnInit } from '@angular/core';
import { LoginViewModel } from '../../core/models/loginViewModel';
import { LoginService } from '../../core/services/auth/login/login.service';
import { Router } from '@angular/router';
import { IdentityService } from '../../core/services/auth/identity/identity.service';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';

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

  public isSubmitted: boolean;
  public loginForm: FormGroup;
  public loginDetails: LoginViewModel;
  public hasError: boolean;

  constructor(private service: LoginService,
              private router: Router,
              private identityService: IdentityService,
              private formBuilder: FormBuilder) {
    this.loginDetails = new LoginViewModel();
    this.hasError = false;
    this.isSubmitted = false;
  }

  ngOnInit()
  {
    this.navigateToDashboard();
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email, Validators.minLength(4)]],
      password: ['',[Validators.required, Validators.minLength(4)]]
    })

  }

  get form() { return this.loginForm.controls; }

  attemptLogin()
  {
    this.isSubmitted = true;

    if(!this.loginForm.valid)
    {
      return;
    }

    this.loginDetails.email = this.loginForm.get('email').value;
    this.loginDetails.password = this.loginForm.get('password').value;

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
