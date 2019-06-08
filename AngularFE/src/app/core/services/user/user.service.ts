import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserViewModel } from "../../models/user/userViewModel";

@Injectable()
export class UserService {
    constructor(private http: HttpClient) { }

    find(): Promise<UserViewModel> {
        return this.http.get('userFind')
            .toPromise()
            .then((user: UserViewModel) => {
                console.log(user);
                return user;
            });
    }

    update(model: UserViewModel): Promise<boolean> {
        return this.http.put(`userUpdate`, model)
            .toPromise()
            .then((response: boolean) => {
                console.log(response);
                return response;
            })
    }
}