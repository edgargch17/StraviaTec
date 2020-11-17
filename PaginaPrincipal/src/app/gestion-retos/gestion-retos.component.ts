import { Component, OnInit } from '@angular/core';
import { GestionRetosModel } from './gestion-retos.model';
import { HttpClient } from '@angular/common/http';
import { ConnectionService } from 'src/app/connection.service';
import { NgForm } from '@angular/forms';

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