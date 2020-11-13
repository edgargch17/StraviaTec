import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import * as $ from 'jquery';

import { MainPageComponent } from './main-page/main-page.component';
import { NavbarComponent } from './navbar/navbar.component';
import { CrearCuentaComponent } from './crear-cuenta/crear-cuenta.component';
import { LoginComponent } from './login/login.component';
import { EntradaDeportistaComponent } from './entrada-deportista/entrada-deportista.component';
import { VistaOrganizadorComponent } from './vista-organizador/vista-organizador.component';
import { CrearCuentaFormService } from './crear-cuenta-form.service';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';




@NgModule({
  declarations: [
    AppComponent,
    MainPageComponent,
    NavbarComponent,
    CrearCuentaComponent,
    LoginComponent,
    EntradaDeportistaComponent,
    VistaOrganizadorComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [CrearCuentaFormService],
  bootstrap: [AppComponent]
})
export class AppModule { }
