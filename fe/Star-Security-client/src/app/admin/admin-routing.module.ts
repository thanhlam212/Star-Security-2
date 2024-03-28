import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeComponent } from './featured/employee/employee.component';
import { DashboardComponent } from './featured/dashboard/dashboard.component';

import { PaymentComponent } from './featured/payment/payment.component';
import { CustomerManagementComponent } from './featured/customer-management/customer-management.component';
import { BranchesComponent } from './featured/branches/branches.component';

const routes: Routes = [
  {
    path:'admin',
    children: [
      {
        path:'dashboard',
        component:DashboardComponent,
        data:{ title: 'Dashboard' }
      },
      {
        path:'branches',
        component: BranchesComponent,
        data:{ title: 'Branches' }
      },
      {
        path:'employees',
        component: EmployeeComponent,
        data:{ title: 'Employee Manager' }
      },
      {
        path:'customer',
        component: CustomerManagementComponent,
        data:{ title: 'Customer Management'}
      },
      {
        path:'payment',
        component: PaymentComponent,
        data:{ title: 'Payment' }
      },
      {
        path: '**',
        redirectTo: '/error',
        pathMatch: 'full',
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
