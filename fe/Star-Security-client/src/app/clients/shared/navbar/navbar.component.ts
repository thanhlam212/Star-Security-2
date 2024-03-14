import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent{
  isDropdownOpen = false;
  isNavBarVisible = true;
  profileVisible = true;

  toggleDropdown() {
    this.isDropdownOpen = !this.isDropdownOpen;
  }

  public toggleSignIn() : void {
    this.isNavBarVisible = !this.isNavBarVisible;
  }
}
