import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-student-home',
  templateUrl: './student-home.component.html',
  styleUrls: ['./student-home.component.scss']
})
export class StudentHomeComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {}

  redirect(url){
    this.router.navigateByUrl(url);
  }
}
