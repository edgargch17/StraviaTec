import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

export class Reports{
  constructor(
      public category_name: string,
      public full_name: string,
      public age: number,
      public race_id: string
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

  readonly rootURL = 'http://localhost:55004/api/view/race';

  ngOnInit(): void {
      this.getReport();
  }

  getReport(){
    this.httpClient.get<any>(this.rootURL).subscribe(
        response => {
            console.log(response);
            this.reports = response;
        },
        error => {
          alert("no se logro conectar con la base de datos");
         }
    );
  }

  /*delete(id){
    this.httpClient.delete(this.rootURL+'/'+id).subscribe(
      response => {}
    );
  }*/
}