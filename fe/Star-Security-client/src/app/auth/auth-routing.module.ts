import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';

const routes: Routes = [
  {
    path:'auth',
    children: [
      {
        path: 'login',
        component: LoginComponent,
        data: { title: 'Login' },
        pathMatch: "full"
      },
      {
        path: 'forgot-password',
        component: ForgotPasswordComponent,
        data: { tittle: 'Forget Password' },
        pathMatch: "full"
      },
      {
        path: 'register',
        component: RegisterComponent,
        data: { title: 'Register' },
        pathMatch: "full"
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
