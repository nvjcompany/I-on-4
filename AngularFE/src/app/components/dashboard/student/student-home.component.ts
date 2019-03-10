import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-student-home',
  templateUrl: './student-home.component.html',
  styleUrls: ['./student-home.component.scss']
})
export class StudentHomeComponent implements OnInit {

  constructor(private httpClient: HttpClient) { }

  ngOnInit() {
  }

  test()
  {
    this.httpClient.post('login-test',{})
    .toPromise()
    .then(r=>{
      console.log(r);
    },
    err =>{

    });
  }
}
