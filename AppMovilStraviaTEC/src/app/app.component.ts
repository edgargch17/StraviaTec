import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  titule = "AppMovilStraviaTEC"

  rutaDirecciones: ArrayBuffer;

  constructor() {
    localStorage.setItem('rutaDirecciones','Direcciones: ');
  }

}

