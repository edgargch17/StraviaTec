import { Component, OnInit } from '@angular/core';
import { GestionRetosModel } from './gestion-retos.model';
import { HttpClient } from '@angular/common/http';
import { ConnectionService } from 'src/app/connection.service';
import { NgForm } from '@angular/forms';

export class Challenges{
  constructor(
      public description: string, 
      public name_challenge: string,
      public start_date: Date,
      public end_date: Date,
      public type_challenge: string,
      public activity_id: string,
      public challenge_identifier :string
  ){

  }
}

@Component({
  selector: 'app-gestion-retos',
  templateUrl: './gestion-retos.component.html',
  styleUrls: ['./gestion-retos.component.css']
})
export class GestionRetosComponent implements OnInit {
  formData: GestionRetosModel= {
    challenge_name :null,
    initial_date: null,
    final_date: null,
    activity: null,
    sponsors: null
  };

  constructor(
    private httpClient: HttpClient,
    private service : ConnectionService) { } 

  readonly rootURL = 'http://localhost:55004/api/challenge';

  challenges: Challenges[];

  ngOnInit(): void {
    this.getchallenge();
  }

  onSubmit(form: NgForm) {
    this.service.PostForm(this.formData,this.rootURL).subscribe(res=>{
    });
  }
  getchallenge(){
    this.httpClient.get<any>(this.rootURL).subscribe(
        response => {
            console.log(response);
            this.challenges = response;
        },
        error => {
          alert("no se logro conectar con la base de datos");
         }
    );
  }

  //elimina un reto existente
  delete(id){
  this.httpClient.delete(this.rootURL+'/'+id).subscribe(
    response => {}
  );
  //actualiza la tabla
  window.location.reload();
  }

}