import { Component } from '@angular/core';
import { RegisterViewModel } from '../../core/models/registerViewModel';
import { RegisterService } from '../../core/services/auth/register/register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent
{
  public user: RegisterViewModel = new RegisterViewModel();

  constructor(private service: RegisterService,) {}

  registerUser(){
    //await result;
    
    this.service.registerUser(this.user)
    .then(user=>{
      alert('Successful registration!');  
    });
  }

}
