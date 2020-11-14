import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { IngresoUsuarioComponent } from './ingreso-usuario/ingreso-usuario.component';
import { MainPageComponent } from './main-page/main-page.component';


const routes: Routes = [
  { path: '', component: MainPageComponent},
  { path: 'ingreso-usuario', component: IngresoUsuarioComponent},
  { path: '**', pathMatch: 'full', redirectTo: 'home' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
