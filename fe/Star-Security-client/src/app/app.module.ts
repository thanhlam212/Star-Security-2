import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClientModule } from './clients/client.module';
import { HttpClientModule } from '@angular/common/http';
import { DatePipe } from '@angular/common';
import { AuthModule } from './auth/auth.module';
import axios from 'axios';
import { ErrorPageComponent } from './shared/error-page/error-page.component';

@NgModule({
    schemas: [CUSTOM_ELEMENTS_SCHEMA],
    declarations: [
        AppComponent,
        ErrorPageComponent,
    ],
    providers: [DatePipe],
    bootstrap: [AppComponent],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        ClientModule,
        AuthModule
    ],
})
export class AppModule { }
