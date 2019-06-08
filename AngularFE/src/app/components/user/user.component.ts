import { Component } from '@angular/core';
import { UserViewModel } from "../../core/models/user/userViewModel";
import { UserService } from "../../core/services/user/user.service";

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent
{
  public user: UserViewModel = new UserViewModel();

  constructor(private service: UserService) {
    this.service.find()
      .then((user: UserViewModel) => {
        this.user = user;          
    });
  }

  updateUser(){
    this.service.update(this.user).then(user => {
      alert("Campaign updated!");
    })
  }
}
