import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {LoginViewModel} from '../../../models/loginViewModel';
import { Observable } from 'rxjs';
import { LoginResponseViewModel } from '../../../models/loginResponseViewModel';
import { IdentityService } from '../identity/identity.service';

@Injectable()
export class LoginService
{
    constructor(private httpClient: HttpClient, private identityService: IdentityService) {}

    public attempt(model: LoginViewModel) : Promise<boolean> {
        return this.httpClient.post('login', model)
        .toPromise()
        .then((response: LoginResponseViewModel)=> {

            this.identityService.setToken(response.token);
            this.identityService.setRole(response.message);

            return true;
        })
        .catch(err =>{
            console.log(err);
            return false;
        });
    }
}