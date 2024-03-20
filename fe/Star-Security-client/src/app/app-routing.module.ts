import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ErrorPageComponent } from './shared/error-page/error-page.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/user/home',
    pathMatch: 'full',
  },
  {
    path: 'user',
    loadChildren: () => 
      import('./clients/client.module').then((m) => m.ClientModule),
  },
  {
    path: 'auth',
    loadChildren : () =>
      import('./auth/auth.module').then((m) => m.AuthModule)
  },
  {
    path: 'admin',
    loadChildren: () => 
      import('./admin/admin.module').then((m) => m.AdminModule)
  },
  {
    path: 'error',
    component: ErrorPageComponent,
    data: {title: 'Error page'}
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
