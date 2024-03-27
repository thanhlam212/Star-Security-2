import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';

import * as fromEmployee from '../../state/employee'
import * as fromRoot from '../../state'
import { Observable, Subject, take, takeUntil } from 'rxjs';
import { Store, select } from '@ngrx/store';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginForm: FormGroup;

  loading$: Observable<boolean> = new Observable(); 
  success$: Observable<boolean> = new Observable();
  error$: Observable<boolean> = new Observable();
  employeeEmail$: Observable<string> = new Observable();
  destroy$: Subject<void> = new Subject();
  
  constructor(
    private fb: FormBuilder,
    private store: Store<fromRoot.IAppState>,
    private router: Router,
  ) {
    this.loginForm = this.fb.group({
      email: '',
      password: ''
    })
   }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email, this.emailValidator]],
      password: ['', [Validators.required, this.passwordValidator]],
    });   

    this.loading$ = this.store.select(fromEmployee.getLoadingLogin).pipe(takeUntil(this.destroy$));
    this.success$ = this.store.select(fromEmployee.getSuccessLogin).pipe(takeUntil(this.destroy$));
    this.error$ = this.store.select(fromEmployee.getFailLogin).pipe(takeUntil(this.destroy$));
    this.employeeEmail$ = this.store.select(fromEmployee.getEmployeeEmail);

    this.onLoginSuccess();
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  submit(){
    const { email, password } = this.loginForm.value;
    this.store.dispatch(new fromEmployee.Login({ email, password }));
  }

  passwordValidator(control: AbstractControl): { [key: string]: boolean} | null {
    const passwordPattern = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$/;
    if (!passwordPattern.test(control.value)) {
      return { 'invalidPassword': true };
    }
    return null;
  }

  emailValidator(control: AbstractControl): { [key: string]: boolean } | null {
    const emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
    if (!emailPattern.test(control.value)) {
      return { 'invalidEmail': true };
    }
    return null;
  }

  onLoginSuccess() {
    this.success$.pipe(
      takeUntil(this.destroy$),
    ).subscribe(() => {
      this.employeeEmail$.pipe(
        take(1)  
      ).subscribe(employeeEmail => {
        if (employeeEmail) {
          localStorage.setItem('userEmail', employeeEmail);
          // console.log('User Email:', userEmail);
        }
      });
      
      this.store.pipe(
        select(fromEmployee.getToken), 
        take(1)  
      ).subscribe(token => {
        if (token) {
          localStorage.setItem('token', token);
          this.router.navigate(['/user/home']);
        }
      });
    });
  }

}
