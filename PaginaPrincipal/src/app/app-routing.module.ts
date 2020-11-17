import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainPageComponent } from './main-page/main-page.component';
import { EntradaDeportistaComponent } from './entrada-deportista/entrada-deportista.component';
import { LoginComponent } from './login/login.component';
import { CrearCuentaComponent } from './crear-cuenta/crear-cuenta.component';
import { VistaOrganizadorComponent } from './vista-organizador/vista-organizador.component';
import { PaginaDeInicioComponent } from './pagina-de-inicio/pagina-de-inicio.component';
import { GestionCarreraComponent } from './gestion-carrera/gestion-carrera.component';


const routes: Routes = [
  { path: '', component: MainPageComponent},
  { path: 'entrada-deportista', component: EntradaDeportistaComponent},
  { path: 'login', component: LoginComponent},
  { path: 'crear-cuenta', component: CrearCuentaComponent},
  { path: 'pagina-de-inicio', component: PaginaDeInicioComponent},
  { path: 'vista-organizador', component: VistaOrganizadorComponent},
  { path: 'gestion-carrera', component: GestionCarreraComponent},
  /*{ path: 'publico', component: VistaPublicoComponent,
    children: [
      { path: 'form', component: LoginFormComponent, },     
    ]},*/
  { path: '**', pathMatch: 'full', redirectTo: 'home' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
