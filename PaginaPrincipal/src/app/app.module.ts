//este es el módulo principal de la aplicación
//aquí se importan las dependencias de angular y los componentes generados


//dependencias de angular
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

//componentes necesarios para el gps
import { AgmCoreModule } from '@agm/core';
import { MatCardModule } from '@angular/material/card';
import { FlexLayoutModule } from '@angular/flex-layout';
import { GooglePlaceModule} from "ngx-google-places-autocomplete";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

//componentes generados en la aplicación
import { MainPageComponent } from './main-page/main-page.component';
import { NavbarComponent } from './navbar/navbar.component';
import { CrearCuentaComponent } from './crear-cuenta/crear-cuenta.component';
import { LoginComponent } from './login/login.component';
import { EntradaDeportistaComponent } from './entrada-deportista/entrada-deportista.component';
import { VistaOrganizadorComponent } from './vista-organizador/vista-organizador.component';
import { ConnectionService } from './connection.service';
import { PaginaDeInicioComponent } from './pagina-de-inicio/pagina-de-inicio.component';
import { GestionCarreraComponent } from './gestion-carrera/gestion-carrera.component';
import { GestionRetosComponent } from './gestion-retos/gestion-retos.component';
import { ReporteParticipantesCarreraComponent } from './reporte-participantes-carrera/reporte-participantes-carrera.component';
import { AceptarInscripcionComponent } from './aceptar-inscripcion/aceptar-inscripcion.component';



// declaraciones e imports de los módulos dependiendo de su funcionamiento

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
    GestionRetosComponent,
    ReporteParticipantesCarreraComponent,
    AceptarInscripcionComponent,
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
