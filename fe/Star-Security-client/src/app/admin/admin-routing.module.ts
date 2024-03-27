import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeComponent } from './featured/employee/employee.component';
import { DashboardComponent } from './featured/dashboard/dashboard.component';

import { PaymentComponent } from './featured/payment/payment.component';
import { CustomerManagementComponent } from './featured/customer-management/customer-management.component';
import { DepartmentComponent } from './featured/department/department.component';
import { VacanciesComponent } from './featured/vacancies/vacancies.component';

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
        path:'department',
        component: DepartmentComponent,
        data:{ title: 'Deparment'}
      },
      {
        path:'payment',
        component: PaymentComponent,
        data:{ title: 'Payment' }
      },
      {
        path:'vacancies',
        component: VacanciesComponent,
        data:{ title: 'Vacancies'}
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
