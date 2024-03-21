import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeComponent } from './featured/employee/employee.component';
import { DashboardComponent } from './featured/dashboard/dashboard.component';
import { ProfileAdminComponent } from './featured/profile-admin/profile-admin.component';
import { PaymentComponent } from './featured/payment/payment.component';

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
        path:'profile-admin',
        component: ProfileAdminComponent,
        data:{ title: 'Profile Admin' }
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
