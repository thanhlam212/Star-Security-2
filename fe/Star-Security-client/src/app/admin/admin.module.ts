import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { SidebarComponent } from './shared/sidebar/sidebar.component';

import { EmployeeComponent } from './featured/employee/employee.component';
import { PaymentComponent } from './featured/payment/payment.component';
import { CreateEmployeeComponent } from './featured/employee/create-employee/create-employee.component';
import { EditEmployeeComponent } from './featured/employee/edit-employee/edit-employee.component';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import { NavbarAdminComponent } from './shared/navbar-admin/navbar-admin.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { DashboardComponent } from './featured/dashboard/dashboard.component';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatCardModule } from '@angular/material/card';
import { MatMenuModule } from '@angular/material/menu';
import { CustomerManagementComponent } from './featured/customer-management/customer-management.component';
import { BranchesComponent } from './featured/branches/branches.component';

@NgModule({
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  declarations: [
    SidebarComponent,
    EmployeeComponent,
    PaymentComponent,
    CreateEmployeeComponent,
    EditEmployeeComponent,
    NavbarAdminComponent,
    DashboardComponent,
    CustomerManagementComponent,
    BranchesComponent,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatSidenavModule,
    MatListModule,
    MatGridListModule,
    MatCardModule,
    MatMenuModule
  ],
  exports:[
    SidebarComponent,
    NavbarAdminComponent
  ]
})
export class AdminModule { }
