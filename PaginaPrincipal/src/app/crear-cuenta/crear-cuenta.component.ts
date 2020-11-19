import { Component, NgModule, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { CrearCuentaModel } from './crear-cuenta-form.model';
import { ConnectionService } from 'src/app/connection.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-crear-cuenta',
  templateUrl: './crear-cuenta.component.html',
  styleUrls: ['./crear-cuenta.component.css']

})
export class CrearCuentaComponent implements OnInit {
  //este JSON es modificado desde el HTML para ser enviado al server
  formData: CrearCuentaModel= {
    full_name:null,
    birth_date: null,
    nationality: null,
    photo: null,
    username: null,
    password: null,
  };

  //este es el archivo que va a ser enviado
  fileToUpload: File = null;

  //declara "this" de las clases HttpClient y el service de conexión, y el router 
  //para redirigir luego de llenar el form
  constructor(
    private http: HttpClient,
    private service : ConnectionService,
    private router: Router) { } 
  
  //url hacia donde se realizará el post
  readonly rootURL = 'http://localhost:55004/api/athlete';
  readonly photoURL = 'http://localhost:55004/api/ahtlete/photo';


  ngOnInit(): void {
  }

  //se obtiene el post y se envía al service para ser enviado al backend
  onSubmit(form: NgForm) {
      this.service.PostForm(this.formData,this.rootURL).subscribe(res=>{
      });

      //se realiza un post unicamente con el archivo
      this.service.PostForm(this.fileToUpload,this.photoURL).subscribe(res=>{
      });
      alert("sus datos han sido procesados con éxito");
      
      //redirige luego de indicar que se procesaron los datos
      this.router.navigate(['']);
  }
}
