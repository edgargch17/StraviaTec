import { Injectable } from '@angular/core';
import { FormModel } from './crear-cuenta/crear-cuenta-form.model';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })

export class CrearCuentaFormService {


  formData: FormModel= {
    name:null
  };

  items = [];

  constructor(
    private http: HttpClient
  ) {}
  
  readonly rootURL = 'http://localhost:59035/api';

  PostForm() {
    alert("safadhfsfjdf");
    this.http.post(this.rootURL + '/values', this.formData ).subscribe(
     response => {
         console.log(response);
         //this.clients = response;
     }
     );
    return this.http.get(this.rootURL + '/values');
 }

 addDepartment(val:any){
  // val = {
  //   "username": "RoJo_Savs",
  //   "name": "Josue",
  //   "last_name": "Santamaria",
  //   "nationality": "Costarricense",
  //   "birth_date": "25 sept 1999",
  //   "photo": "url",
  //   "age": 21,
  //   "password": "abcd1234"
  // };
  alert("safadhfsfjdf");
  var d="pene";
  this.http.post('http://localhost:55003/api/main/post', val ).subscribe(
   response => {
       console.log(response);
       alert("fdsf");
       alert(response);
       //this.clients = response;
   }
   );

  return this.http.post('http://localhost:55003/api/main/post',val);
}
}