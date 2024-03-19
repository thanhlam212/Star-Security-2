import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

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
    path: 'admin',
    loadChildren: () => 
      import('./admin/admin.module').then((m) => m.AdminModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
