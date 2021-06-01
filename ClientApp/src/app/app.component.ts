import { Component } from '@angular/core';
import { AuthenticationService } from './_services';
import { Router } from '@angular/router';

@Component({ selector: 'app', templateUrl: 'app.component.html' })
export class AppComponent {
  constructor(
        private router: Router,
        private authenticationService: AuthenticationService
    ) {
    }
  logout() {
        this.authenticationService.logout();
        this.router.navigate(['/login']);
    }
}
    