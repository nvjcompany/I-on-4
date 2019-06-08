import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RegisterViewModel } from '../../../models/registerViewModel';
import { TestViewModel } from '../../../models/testViewModel';

@Injectable()
export class RegisterService{
    constructor(private http: HttpClient){}

    registerUser(model: RegisterViewModel): Promise<boolean>
    {
        return this.http.post('register', model)
            .toPromise()
            .then( ( ress: boolean ) => {
                return true;
            },
            err => {
                throw new DOMException("ERROR");
            }
        );
    }
}