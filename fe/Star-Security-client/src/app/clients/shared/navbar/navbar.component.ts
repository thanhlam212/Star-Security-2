import { AuthServiceService } from './../../../auth/services/auth-service.service';
import { Component, OnInit, HostListener } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route, Router, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})

export class NavbarComponent implements OnInit{
  header_variable = false;
  isLoggedIn: boolean = false;
  showDropdown: boolean = false;

  constructor(private authService: AuthServiceService){}

  ngOnInit(): void {
    this.isLoggedIn = this.authService.isLoggedIn();
  }

  @HostListener('window:scroll', ['$event']) onScroll(){
  if(window.scrollY > 0){
      this.header_variable = true;
  }else{
      this.header_variable = false;
    }
  }

  toggleDropdown(): void {
    this.showDropdown = !this.showDropdown;
  }
  
  logout(): void {
    this.authService.logout();
  }
}
