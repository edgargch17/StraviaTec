import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })

export class ConnectionService {

  items = [];

  constructor(
    private http: HttpClient
  ) {}
  


  PostForm(val:any,rootURL){
  this.http.post(rootURL,val).subscribe(
   response => {
       alert(response);
       console.log(response);
       //this.clients = response;
   }
   );
  return this.http.post(rootURL,val);
}
}