import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class SharedService {
readonly APIUrl = "http://localhost:55003/api";
readonly PhotoUrl = "http://localhost:55003/weatherforecast";

  constructor(private http:HttpClient) { }

  getDepList():Observable<any[]>{
    return this.http.get<any>(this.PhotoUrl);//+'/department');
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

    return this.http.post(this.APIUrl+'/main/post',val);
  }

  updateDepartment(val:any){
    return this.http.put(this.APIUrl+'/Department',val);
  }

  deleteDepartment(val:any){
    return this.http.delete(this.APIUrl+'/Department/'+val);
  }


  getEmpList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Employee');
  }

  addEmployee(val:any){
    return this.http.post(this.APIUrl+'/Employee',val);
  }

  updateEmployee(val:any){
    return this.http.put(this.APIUrl+'/Employee',val);
  }

  deleteEmployee(val:any){
    return this.http.delete(this.APIUrl+'/Employee/'+val);
  }


  UploadPhoto(val:any){
    return this.http.post(this.APIUrl+'/Employee/SaveFile',val);
  }

  getAllDepartmentNames():Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl+'/Employee/GetAllDepartmentNames');
  }

}
