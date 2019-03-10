import { Component } from '@angular/core';
import { IdentityService } from '../../core/services/auth/identity/identity.service';
import { Router } from '@angular/router';


@Component({
    selector: 'app-logout',
    templateUrl: './logout.component.html',
    styleUrls: ['./logout.component.scss']
})
export class LogoutComponent{
    constructor(private identityService: IdentityService, private router: Router){
        identityService.logout();
        router.navigateByUrl('/');
    }
}