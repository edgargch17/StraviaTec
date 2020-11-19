import { Component, OnInit } from '@angular/core';
import { GestionCarreraModel } from './gestion-carrera.model';
import { HttpClient } from '@angular/common/http';
import { ConnectionService } from 'src/app/connection.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-gestion-carrera',
  templateUrl: './gestion-carrera.component.html',
  styleUrls: ['./gestion-carrera.component.css']
})
export class GestionCarreraComponent implements OnInit {
  formData: GestionCarreraModel= {
    race_name :null,
    race_date: null,
    activity_type: null,
    route: null,
    money_cost: null,
    bank_account: null,
    category: null,
    sponsors: null
  };

  constructor(
    private http: HttpClient,
    private service : ConnectionService) { } 
    
  readonly rootURL = 'http://localhost:55004/api/race';

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
  
    this.service.PostForm(this.formData,this.rootURL).subscribe(res=>{
    });
}

}
