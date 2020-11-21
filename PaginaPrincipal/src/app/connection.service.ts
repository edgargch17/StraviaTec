//desde este módulo se realizan todas las conexiones con el backend

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })

export class ConnectionService {

  items = [];

  //utiliza la bilbioteca HttpClient de angular
  constructor(
    private http: HttpClient
  ) {}
  

  //postea hacia el server
  PostForm(val:any,rootURL){
    return this.http.post<any>(rootURL,val);
  }

  //permite actualizar un valor basado en una id
  UpdateForm(val:any,updateURL){
    return this.http.put<boolean>(updateURL,val);
  }
  
}