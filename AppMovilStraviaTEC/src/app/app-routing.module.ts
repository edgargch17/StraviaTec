import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { IngresoUsuarioComponent } from './componentes/ingreso-usuario/ingreso-usuario.component';
import { GPSComponent } from './componentes/gps/gps.component';
import { MainPageComponent } from './componentes/main-page/main-page.component';


const routes: Routes = [
  { path: '', component: MainPageComponent},
  { path: 'ingreso-usuario', component: IngresoUsuarioComponent},
  { path: 'gps', component: GPSComponent},
  { path: '**', pathMatch: 'full', redirectTo: 'home' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
