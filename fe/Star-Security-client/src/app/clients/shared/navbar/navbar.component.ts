import { Component, OnInit, HostListener } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})

export class NavbarComponent implements OnInit{
  
  constructor(){}

  ngOnInit(): void {
  }

  header_variable = false;
  @HostListener("window:scroll", [])
  onWindowScroll() {
    if (window.scrollY > 0) {
      this.header_variable = true;
    } else {
      this.header_variable = false;
    }
  }
}
