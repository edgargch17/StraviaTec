import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

export class Reports{
  constructor(
      public id: number,
      public name: string,
      public lastName: string,
      public address: string,
      public phone: number,
      public sinpe: number,
      public places: string,
      public userName: string,
      public password: number
  ){

  }
}


@Component({
  selector: 'app-reporte-participantes-carrera',
  templateUrl: './reporte-participantes-carrera.component.html',
  styleUrls: ['./reporte-participantes-carrera.component.css']
})
export class ReporteParticipantesCarreraComponent implements OnInit {

  reports: Reports[];

  constructor(private httpClient: HttpClient) { }

  readonly rootURL = 'http://localhost:55004/api/login';

  ngOnInit(): void {
  }

  getReport(){
    this.httpClient.get<any>(this.rootURL).subscribe(
        response => {
            console.log(response);
            this.reports = response;
        }
    );
  }

  delete(id){
  this.httpClient.delete(this.rootURL+'/'+id).subscribe(
    response => {}
  );
  alert(this.rootURL+'/'+id);
  }
}


