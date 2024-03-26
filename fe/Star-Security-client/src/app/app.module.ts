import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClientModule } from './clients/client.module';
import { AdminModule } from './admin/admin.module';
import { HttpClientModule } from '@angular/common/http';
import { DatePipe } from '@angular/common';
import { AuthModule } from './auth/auth.module';
import axios from 'axios';
import { ErrorPageComponent } from './shared/error-page/error-page.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { ServicesDetailComponent } from './services-detail/services-detail.component';
import { StoreModule } from '@ngrx/store';
import { appReducer } from './state';

@NgModule({
    schemas: [CUSTOM_ELEMENTS_SCHEMA],
    declarations: [
        AppComponent,
        ErrorPageComponent,
        ServicesDetailComponent,
    ],
    providers: [DatePipe, provideAnimationsAsync()],
    bootstrap: [AppComponent],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        ClientModule,
        AuthModule,
        AdminModule,

        
        StoreModule.forRoot(appReducer)
    ],
})
export class AppModule { }
