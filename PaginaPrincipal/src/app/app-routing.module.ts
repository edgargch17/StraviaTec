//aquí se invocan las dependencias de angular y los componentes de la aplicación
//se utilizan para linkear componentes y acceder a ellos mediante rutas de Angular

//dependencias de bibliotecas y componentes generados

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainPageComponent } from './main-page/main-page.component';
import { EntradaDeportistaComponent } from './entrada-deportista/entrada-deportista.component';
import { LoginComponent } from './login/login.component';
import { CrearCuentaComponent } from './crear-cuenta/crear-cuenta.component';
import { VistaOrganizadorComponent } from './vista-organizador/vista-organizador.component';
import { PaginaDeInicioComponent } from './pagina-de-inicio/pagina-de-inicio.component';
import { GestionCarreraComponent } from './gestion-carrera/gestion-carrera.component';
import { GestionRetosComponent } from './gestion-retos/gestion-retos.component';
import { ReporteParticipantesCarreraComponent } from './reporte-participantes-carrera/reporte-participantes-carrera.component';
import { AceptarInscripcionComponent } from './aceptar-inscripcion/aceptar-inscripcion.component';



//array de las rutas del programa
const routes: Routes = [
  { path: '', component: MainPageComponent},
  { path: 'entrada-deportista', component: EntradaDeportistaComponent},
  { path: 'login', component: LoginComponent},
  { path: 'crear-cuenta', component: CrearCuentaComponent},
  { path: 'pagina-de-inicio/:id', component: PaginaDeInicioComponent },
  { path: 'vista-organizador', component: VistaOrganizadorComponent},
  { path: 'gestion-carrera', component: GestionCarreraComponent},
  { path: 'gestion-retos', component: GestionRetosComponent},
  { path: 'aceptar-inscripcion', component: AceptarInscripcionComponent},
  { path: 'reporte-participantes-carrera', component: ReporteParticipantesCarreraComponent},
  /*{ path: 'publico', component: VistaPublicoComponent,
    children: [
      { path: 'form', component: LoginFormComponent, },     
    ]},*/
  { path: '**', pathMatch: 'full', redirectTo: 'home' }
];

//declara las dependencias de las rutas
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
