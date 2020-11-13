import { Component, NgModule, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { FormModel } from './crear-cuenta-form.model';
import { CrearCuentaFormService } from 'src/app/crear-cuenta-form.service';


@Component({
  selector: 'app-crear-cuenta',
  templateUrl: './crear-cuenta.component.html',
  styleUrls: ['./crear-cuenta.component.css']

})
export class CrearCuentaComponent implements OnInit {
  formData: FormModel= {
    name:null
  };
  readonly rootURL = 'http://localhost:59035/api/main/post';


  constructor(
    private http: HttpClient,
    private service : CrearCuentaFormService) { }  


  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {

    /*var val = {age:"fwd",
      birth_date:"fddsfds"};


    this.PostForm(val).subscribe(
      res => {
        debugger;
      
      },
      err => {
        debugger;
        console.log(err);
      }
    )*/

       var val = {
                     "username": "RoJo_Savs",
                     "name": "Josue",
                     "last_name": "Santamaria",
                     "nationality": "Costarricense",
                     "birth_date": "25 sept 1999",
                   "photo": "url",
                     "age": 21,
                     "password": "abcd1234"
                   };
      this.service.addDepartment(val).subscribe(res=>{
      alert(res.toString());
      });
  }

  PostForm(val) {
    alert("safadhfsfjdf");
    this.http.post('http://localhost:55003/api/main/post', val ).subscribe(
     response => {
         console.log(response);
         alert(response);
         alert("fdsf");
         //this.clients = response;
     }
     );
    
    return this.http.post('http://localhost:55003/api/main/post', val ); //this.http.get('http://localhost:55003/api/main/post');
 }


}


  /*registro(){
    alert("Sus datos se han procesado con éxito");
  }*/

  /*registro() {
    var data = {
        objUsuario: {
            idUsuario: 1,
            user: "usuardcsio",
            password: "contrascdsceña"
        }
    }
    $.ajax({
        method: "POST",
        url: "Index.aspx/Login",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json"
    }).done(function (info) {
        //Respuesta del servidor
        console.log(info);
        $(".mensaje").html( info.d );
    })
    
  }*/
 /*
 increase(){
    var dataString='sdfdds';
    $.ajax({
    type:"post",
    url: "increase_likes.php",
    dataType: "json",
    data:dataString,
    cache:false,
    success:function(data) {

    },
    error: function (data) {
    alert("F");
    }

    });
    return false;
    }*/

/*import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';

import { CrearCuentaFormService } from '../crear-cuenta-form.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CrearCuentaComponent implements OnInit {
  items;
  checkoutForm;

  constructor(
    private crearCuentaService: CrearCuentaFormService,
    private formBuilder: FormBuilder,
  ) {
    this.checkoutForm = this.formBuilder.group({
      name: '',
      address: ''
    });
  }

  ngOnInit() {
    this.items = this.crearCuentaService.getItems();
  }

  onSubmit(customerData) {
    // Process checkout data here
    this.items = this.crearCuentaService.clearCart();
    this.checkoutForm.reset();

    console.warn('Your order has been submitted', customerData);
  }
}*/