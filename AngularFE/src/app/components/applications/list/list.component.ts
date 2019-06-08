import {Component} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Component({
    selector: 'app-application-list-component',
    templateUrl: './list.component.html',

})
export class ListComponent {
    public applications: any = [];
    public isCompany: boolean;

    private loadApplications() {
      this.http.get('applications')
        .toPromise()
        .then(applications => {
          this.applications = applications;
        })
    }

    constructor(private http: HttpClient) {
      this.loadApplications();
      this.isCompany = localStorage.getItem('ROLE') == 'Company' ? true : false;
    }

    changeStatus(id, status){
      this.http.post('change-application-status', {
        Id: id,
        Status: status
      }).toPromise()
        .then(r=>{
          this.loadApplications();
        })
    }
}
