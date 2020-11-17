import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })

export class ConnectionService {

  items = [];

  constructor(
    private http: HttpClient
  ) {}
  
  readonly rootURL = 'http://localhost:55003/api/main/post';

  PostForm(val:any){
  this.http.post(this.rootURL,val).subscribe(
   response => {
       alert(response);
       console.log(response);
       //this.clients = response;
   }
   );
  return this.http.post(this.rootURL,val);
}
}