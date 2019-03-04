import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {LoginViewModel} from '../../../models/loginViewModel';
import { Observable } from 'rxjs';

@Injectable()
export class LoginService
{
    constructor(private httpClient: HttpClient) {}

    public attempt(model: LoginViewModel) : Promise<boolean> {
        return this.httpClient.post('login', model)
        .toPromise()
        .then((token: string)=> {
            localStorage.setItem('AUTH_TOKEN', token);
            return true;
        })
        .catch(err => {
            console.log(err);
            return false;
        });
    }
}