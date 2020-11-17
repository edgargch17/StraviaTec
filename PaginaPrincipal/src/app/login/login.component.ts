import { Component, OnInit } from '@angular/core';
import { ConnectionService } from 'src/app/connection.service';
import { HttpClient } from '@angular/common/http';
import { LoginFormModel } from './login-form.model';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  formData: LoginFormModel= {
    username: null,
    password: null,
  };

  constructor(private http: HttpClient,
    private service : ConnectionService,
    private router: Router) { }

  readonly rootURL = 'http://localhost:55003/api/main/post';

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
    /*this.service.PostForm(this.formData,this.rootURL).subscribe(res=>{
    });*/
    this.router.navigate(['pagina-de-inicio/pene']);
  }

}
