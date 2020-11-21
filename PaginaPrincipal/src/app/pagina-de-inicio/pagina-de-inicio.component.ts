import { Component, OnInit, ViewChild } from '@angular/core';

import { GooglePlaceDirective } from 'ngx-google-places-autocomplete';
import { Address } from 'ngx-google-places-autocomplete/objects/address';
import { HttpClient } from '@angular/common/http';
import { CrearCuentaModel } from '../crear-cuenta/crear-cuenta-form.model';
import { NgForm } from '@angular/forms';
import { ConnectionService } from 'src/app/connection.service';


export class Search{
  constructor(
      public full_name: string, 
      public activity: string
  ){

  }
}


declare const google: any;

@Component({
  selector: 'app-pagina-de-inicio',
  templateUrl: './pagina-de-inicio.component.html',
  styleUrls: ['./pagina-de-inicio.component.css']
})
export class PaginaDeInicioComponent implements OnInit {
  //la variable athletes almacena a los atletas amigos del usuario, y info_URL es de 
  //donde se obtiene esa información

  athletes: CrearCuentaModel[];
  readonly info_URL = 'http://localhost:55004/api/ahtlete/photo';

  //variables del boton de búsqueda
  readonly post_search_URL = 'http://localhost:55004/api/search';
  readonly result_URL = 'http://localhost:55004/api/ahtlete/photo';
  search_query : string = null;
  challenges: Search[];
  

  //Mapa
  map = null;

  //Valores del mapa cargado
  lat: number;
  long: number;
  zoom: number;
  mapTypeId: string;

  //Puntos de inicio y final
  lat_Inicio: number;
  lat_Final: number;
  long_Inicio: number;
  long_Final: number;

  //Valores para calcular la ruta y renderizar la ruta optima
  directionService = new google.maps.DirectionsService();
  //Dibuja la ruta optima en el mapa
  directionDisplay = new google.maps.DirectionsRenderer();

  @ViewChild("placesRef") placesRef : GooglePlaceDirective;
  options = {
    types: [],
    componentRestrictions: { country: 'CR'}
  }

  constructor(
    private service : ConnectionService,
    private httpClient: HttpClient
  ) { 
    this.lat = 9.8558;
    this.long = -83.9115;
    this.zoom = 17;
    this.mapTypeId = 'roadmap';

  }

  ngOnInit(): void {
    this.loadMap();
    this.getAthletes();
  }

  //Funcion para solicitar address
  public handleAddressChange(address: Address){
    //imprime en la consola la direccion
    console.log(address);
    console.log('Latitud: '+address.geometry.location.lat());
    console.log('Longitud: '+address.geometry.location.lng());

    //Carga el mapa en las coordenadas dadas en el buscardor
    this.lat = address.geometry.location.lat();
    this.long = address.geometry.location.lng();

    //Carga latitud y longitud del distino
    this.lat_Final = address.geometry.location.lat();
    this.long_Final = address.geometry.location.lng();

    //Cambia los valores del mapa en latitud y longitud (Center)
    this.map.setCenter({lat: address.geometry.location.lat(), lng: address.geometry.location.lng()});
  }

  //Funcion para obtener la posicion en tiempo real
  getPosition (){
    navigator.geolocation.getCurrentPosition(position => {
      this.lat = position.coords.latitude;
      this.long = position.coords.longitude;
      this.map.setZoom(18);

      this.lat_Inicio = position.coords.latitude;
      this.long_Inicio = position.coords.longitude;

      //Cambia los valores del mapa en latitud y longitud (Center)
      this.map.setCenter({lat: position.coords.latitude, lng: position.coords.longitude});

      //Imprimir en la consola las coordenadas en tiempo real del usuario
      console.log('Latitud: '+position.coords.latitude);
      console.log('Longitud: '+position.coords.longitude);
    })
  }

  //Funcion para cargar el mapa
  loadMap() {

    //crea un elemento mapa y lo pasa al HTML
    const mapEle: HTMLElement = document.getElementById('map');
    //Indicadores del mapa
    const indicatorsEle: HTMLElement = document.getElementById('indicators');

    //crea el mapa
    this.map = new google.maps.Map(mapEle, {
      center: {lat: 9.8558, lng: -83.9115},
      zoom: 16,
    });

    this.directionDisplay.setMap(this.map);
    this.directionDisplay.setPanel(indicatorsEle);

    google.maps.event.addListenerOnce(this.map, 'idle', () => {
      mapEle.classList.add('show-map');
      this.getRoute();
    });

  }

  //Funcion para obtener y dibujar la ruta optima
  getRoute (){
    this.directionService.route({
      origin: {lat: this.lat_Inicio, lng: this.long_Inicio},
      destination: {lat: this.lat_Final, lng: this.long_Final},
      travelMode: google.maps.TravelMode.DRIVING,
    }, (response, status)  => {
      if (status === google.maps.DirectionsStatus.OK) {
        this.directionDisplay.setDirections(response);
      } else {
        alert('Could not display directions due to: ' + status);
      }
    });
  }

  getAthletes(){
    this.httpClient.get<any>(this.info_URL).subscribe(
        response => {
            console.log(response);
            this.athletes = JSON.parse(response);
        }
    );
  }

  onSubmit(form: NgForm) {
    this.service.PostForm(this.search_query,this.post_search_URL).subscribe(
      response => {
          console.log(response);
          this.search_query = response;
      },
      error => {
        alert("no se logro conectar con la base de datos");
       }
  );
  }

  getsearch(){
    this.httpClient.get<any>(this.result_URL).subscribe(
        response => {
            console.log(response);
            this.search_query = response;
        },
        error => {
          alert("no se logro conectar con la base de datos");
         }
    );
  }
}

