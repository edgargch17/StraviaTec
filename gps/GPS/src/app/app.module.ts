import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';

//componentes
import { MainPageComponent } from './main-page/main-page.component';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { GpsComponent } from './gps/gps.component';
import { IngresoUsuarioComponent } from './ingreso-usuario/ingreso-usuario.component';




@NgModule({
  declarations: [
    AppComponent,
    MainPageComponent,
    GpsComponent,
    IngresoUsuarioComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
