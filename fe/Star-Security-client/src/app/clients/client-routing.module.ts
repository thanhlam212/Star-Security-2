import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './feature/home/home.component';
import { AboutComponent } from './feature/about/about.component';

const routes: Routes = [
  {
    path:'user',
    children: [
      {
        path:'home',
        component: HomeComponent,
        data: { title: 'Home Page' },
        pathMatch: 'full',
      },
      {
        path:'about-us',
        component: AboutComponent,
        data: { title: 'About Us' },
        pathMatch: 'full',
      }
    ]
  }
]

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClientRoutingModule { }
