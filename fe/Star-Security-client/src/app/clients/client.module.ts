import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { FooterComponent } from './shared/footer/footer.component';
import { HomeComponent } from './feature/home/home.component';
import { AboutComponent } from './feature/about/about.component';
import { ClientRoutingModule } from './client-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  declarations: [
    NavbarComponent,
    FooterComponent,
    HomeComponent,
    AboutComponent,
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ClientRoutingModule,
  ],
  exports: [NavbarComponent, FooterComponent],
})
export class ClientModule { }
