import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthRoutingModule } from './auth-routing.module';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AdminLoginComponent } from './admin-login/admin-login.component';


@NgModule({
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  declarations: [
    LoginComponent,
    RegisterComponent,
    AdminLoginComponent
  ],
  imports: [
    CommonModule,
    AuthRoutingModule,
    HttpClientModule,
  ],
})

export class AuthModule { }
