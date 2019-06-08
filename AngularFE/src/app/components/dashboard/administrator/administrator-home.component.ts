import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router/';

@Component({
  selector: 'app-administrator-home',
  templateUrl: './administrator-home.component.html',
  styleUrls: ['./administrator-home.component.scss']
})
export class AdministratorHomeComponent implements OnInit {
  ngOnInit(): void {
     
  }
  constructor(private router: Router) { }

  redirect(url){
    this.router.navigateByUrl(url);
  }

}
