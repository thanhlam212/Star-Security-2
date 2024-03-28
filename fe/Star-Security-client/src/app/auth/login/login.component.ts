import { LoginSuccess } from './../../state/employee/employee.actions';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AxiosClientService } from '../services/axios-client.service';
import { timer } from 'rxjs';
import { AuthServiceService } from '../services/auth-service.service';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  email: string = '';
  password: string = '';
  loginMessage: string = '';
  LoginSuccess: boolean = false;
 

  constructor(
    private axiosService: AxiosClientService, 
    private router: Router,
    private authService: AuthServiceService) {}

  login(){
    this.axiosService.Login(this.email, this.password)
    .then(response => {
      console.log('Login successful', response.data);
      this.LoginSuccess = true;
      this.loginMessage = 'Login successful! Please wait a few seconds...'; 
      timer(2000).subscribe(() => {
        this.router.navigate(['/user/home']);
      })
    })
    .catch(error => {
      console.error('Login failed', error);
      this.LoginSuccess = false;
      this.loginMessage = 'Login failed. Please try again.'; 
    
    });
  }

  ngOnInit(): void {
    
    };   

  ngOnDestroy(): void {
   
  }
}
