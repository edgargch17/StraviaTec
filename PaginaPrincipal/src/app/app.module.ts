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
import { ConnectionService } from './connection.service';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { PaginaDeInicioComponent } from './pagina-de-inicio/pagina-de-inicio.component';

//gps
import { AgmCoreModule } from '@agm/core';
import { MatCardModule } from '@angular/material/card';
import { FlexLayoutModule } from '@angular/flex-layout';
import { GooglePlaceModule} from "ngx-google-places-autocomplete";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { GestionCarreraComponent } from './gestion-carrera/gestion-carrera.component';


@NgModule({
  declarations: [
    AppComponent,
    MainPageComponent,
    NavbarComponent,
    CrearCuentaComponent,
    LoginComponent,
    EntradaDeportistaComponent,
    VistaOrganizadorComponent,
    PaginaDeInicioComponent,
    GestionCarreraComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,

    //imports de maps
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyDYp93ij7X3_elgT0FFT0RTZKHRb_gpRsw'
    }),
    MatCardModule,
    FlexLayoutModule,
    GooglePlaceModule,

    FormsModule,

    BrowserAnimationsModule
  ],
  providers: [ConnectionService],
  bootstrap: [AppComponent]
})
export class AppModule { }
