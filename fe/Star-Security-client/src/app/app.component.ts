import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Star Security';
  constructor(private activatedRoute : ActivatedRoute, private router : Router){

  }

  isAdminPage() : boolean {
    return this.activatedRoute.snapshot.firstChild?.routeConfig?.path === 'admin';
  }

  isLoginPage() : boolean {
    return this.activatedRoute.snapshot.firstChild?.routeConfig?.path === 'auth';
  }
  is404Page() : boolean {
    return this.router.url.includes('/error');
  }
}
