import { Component, OnInit } from '@angular/core';
import { LoginViewModel } from '../../core/models/loginViewModel';
import {LoginService} from '../../core/services/auth/login/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public loginDetails: LoginViewModel;
  public hasError: boolean;

  constructor(private service: LoginService) {
    this.loginDetails = new LoginViewModel();
    this.hasError = false;
  }

  ngOnInit() {
  }
  attemptLogin()
  {
    this.service.attempt(this.loginDetails)
    .then(r=> {
      if(!r){
        this.hasError = true;
      }
      else
      {
        //redirect to home
      }
    });
  }
}
