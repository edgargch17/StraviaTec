import { Component, NgModule, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { CrearCuentaModel } from './crear-cuenta-form.model';
import { ConnectionService } from 'src/app/connection.service';


@Component({
  selector: 'app-crear-cuenta',
  templateUrl: './crear-cuenta.component.html',
  styleUrls: ['./crear-cuenta.component.css']

})
export class CrearCuentaComponent implements OnInit {
  formData: CrearCuentaModel= {
    name :null,
    birth_date: null,
    nationality: null,
    photo: null,
    username: null,
    password: null,
  };


  constructor(
    private http: HttpClient,
    private service : ConnectionService) { } 
    
  readonly rootURL = 'http://localhost:55003/api/main/post';


  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
      this.service.PostForm(this.formData,this.rootURL).subscribe(res=>{
      });
  }
}
