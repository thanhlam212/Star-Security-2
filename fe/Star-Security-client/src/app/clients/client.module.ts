import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { FooterComponent } from './shared/footer/footer.component';
import { HomeComponent } from './feature/home/home.component';
import { AboutComponent } from './feature/about/about.component';
import { ClientRoutingModule } from './client-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { OurBusinessComponent } from './feature/our-business/our-business.component';
import { CareersWithUsComponent } from './feature/careers-with-us/careers-with-us.component';
import { JobsListComponent } from './feature/jobs-list/jobs-list.component';
import { JobFormApplyComponent } from './feature/job-form-apply/job-form-apply.component';



@NgModule({
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  declarations: [
    NavbarComponent,
    FooterComponent,
    HomeComponent,
    AboutComponent,
    OurBusinessComponent,
    CareersWithUsComponent,
    JobsListComponent,
    JobFormApplyComponent,
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
