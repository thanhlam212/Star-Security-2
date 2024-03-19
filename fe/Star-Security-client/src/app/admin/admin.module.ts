import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { SidebarComponent } from './shared/sidebar/sidebar.component';
import { MainComponent } from './featured/main/main.component';
import { ProfileAdminComponent } from './featured/profile-admin/profile-admin.component';
import { EmployeeComponent } from './featured/employee/employee.component';
import { PaymentComponent } from './featured/payment/payment.component';
import { CreateEmployeeComponent } from './featured/employee/create-employee/create-employee.component';
import { EditEmployeeComponent } from './featured/employee/edit-employee/edit-employee.component';


@NgModule({
  declarations: [
    NavbarComponent,
    SidebarComponent,
    MainComponent,
    ProfileAdminComponent,
    EmployeeComponent,
    PaymentComponent,
    CreateEmployeeComponent,
    EditEmployeeComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule
  ]
})
export class AdminModule { }
