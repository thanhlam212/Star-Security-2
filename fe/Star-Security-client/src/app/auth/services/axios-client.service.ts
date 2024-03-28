import { ForgotPasswordComponent } from './../forgot-password/forgot-password.component';
import { Login, Logout } from './../../state/employee/employee.actions';
import { Injectable } from '@angular/core';
import axios, { AxiosInstance } from 'axios';
import { environment } from '../../environments/environment';
import { HttpBackend, HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AxiosClientService {

  private baseUrl: string;
  private axiosInstance: AxiosInstance;

  constructor() { 
    this.baseUrl = environment.nodejsApiUrl;
    this.axiosInstance = axios.create({
      baseURL: this.baseUrl,
      timeout: 5000,
      headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json'
      },
    });
  }

  async Login(email: string, password: string): Promise<any>{ 
    const url = `${this.baseUrl}/Auth/login`;
    try{
      const response = await this.axiosInstance.post(url, { email, password });
      if (response.data.accessToken) {
        localStorage.setItem('accessToken', response.data.accessToken);
      }
      return response.data;
    }catch(error){
      throw error;
    }
  }

  async Logout(): Promise<void> {
    localStorage.removeItem('accessToken');
  }
}


