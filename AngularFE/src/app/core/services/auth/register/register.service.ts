import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RegisterViewModel } from '../../../models/registerViewModel';
import { TestViewModel } from '../../../models/testViewModel';

@Injectable()
export class RegisterService{
    constructor(private http: HttpClient){}

    doSimpleRequest(model: RegisterViewModel): Promise<TestViewModel>
    {
        return this.http.post('test', model)
            .toPromise()
            .then( (user: TestViewModel ) => {
                return user;
            },
            err => {
                throw new DOMException("ERROR");
            }
        );
    }
}