import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

//............................Imports para Routes......................//
import { AppRoutingModule } from './app-routing.module';

//.............................Imports para poder realizar el gps........................//
import { AgmCoreModule } from '@agm/core';
import { MatCardModule } from '@angular/material/card';
import { FlexLayoutModule } from '@angular/flex-layout';
import { GooglePlaceModule} from "ngx-google-places-autocomplete";
//.......................................................................................//

import { MainPageComponent } from './componentes/main-page/main-page.component';
import { AppComponent } from './app.component';
import { GPSComponent } from './componentes/gps/gps.component';
import { IngresoUsuarioComponent } from './componentes/ingreso-usuario/ingreso-usuario.component';
import { from } from 'rxjs';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

//............................Librerias para abrir y crear archivos.....................//
import { NgxFileDropModule } from 'ngx-file-drop';
import { saveAs } from 'file-saver';

@NgModule({
  declarations: [
    AppComponent,
    GPSComponent,
    IngresoUsuarioComponent,
    MainPageComponent
  ],
  imports: [
    BrowserModule,

    //...............Imports...............//
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyDYp93ij7X3_elgT0FFT0RTZKHRb_gpRsw'
    }),
    MatCardModule,
    FlexLayoutModule,
    GooglePlaceModule,
    //.....................................//

    AppRoutingModule,
    BrowserAnimationsModule,

    //.....................................//
    NgxFileDropModule,

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
