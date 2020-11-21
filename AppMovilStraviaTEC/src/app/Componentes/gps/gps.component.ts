import { Component, OnInit, ViewChild } from '@angular/core';
import { GooglePlaceDirective } from 'ngx-google-places-autocomplete';
import { Address } from 'ngx-google-places-autocomplete/objects/address';

declare var google;
//declare var saveAs:any;

@Component({
  selector: 'app-gps',
  templateUrl: './gps.component.html',
  styleUrls: ['./gps.component.css']
})
export class GPSComponent implements OnInit {

  //Ubicacion en tiempo real
  //ubi = navigator.geolocation.watchPosition(this.getPositionRealTime);
  //Se declara la variable ubicacion null
  ubicacion = null;

  //valor de la geolocalizacion
  ValGeolocalizacion: number;

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

  //Valores de los contadores del cronometro
  cronometro = null;
  /*segundos = document.getElementById("segundosT");
  minutos = document.getElementById("minutosT");
  horas = document.getElementById("horasT");*/
  contador_s: number;
  contador_m: number;
  contador_h: number;


  @ViewChild("placesRef") placesRef : GooglePlaceDirective;
  options = {
    types: [],
    componentRestrictions: { country: 'CR'}
  }

  constructor() { 
    this.lat = 9.8558;
    this.long = -83.9115;
    this.zoom = 17;
    this.mapTypeId = 'roadmap';

    
    //contadores de horas,minutos,segundos
    this.contador_s = 0;
    this.contador_m = 0;
    this.contador_h = 0;

    //Valor de la Geolocalizacion
    this.ValGeolocalizacion = 0;

  }

  ngOnInit(): void {
    this.loadMap();
  }

  //Funcion para solicitar address de Destino de Ruta
  public handleAddressChangeDestino(address: Address){
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

  //Funcion para solicitar address de Inicio de Ruta
  public handleAddressChangeInicio(address: Address){
    //imprime en la consola la direccion
    console.log(address);
    console.log('Latitud: '+address.geometry.location.lat());
    console.log('Longitud: '+address.geometry.location.lng());

    //Carga el mapa en las coordenadas dadas en el buscardor
    this.lat = address.geometry.location.lat();
    this.long = address.geometry.location.lng();

    //Carga latitud y longitud del distino
    this.lat_Inicio = address.geometry.location.lat();
    this.long_Inicio = address.geometry.location.lng();

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


  //Funcion para obtener la ubicacion constantemente
  getPositionRealTime (){ 
    /*//Ubicacion en tiempo real
    this.ubicacion = navigator.geolocation.watchPosition(position => {
    
      //Cambia los valores del mapa en latitud y longitud (Center)
      this.map.setCenter({lat: position.coords.latitude, lng: position.coords.longitude});
      //Imprimir en la consola las coordenadas en tiempo real del usuario
      console.log('Latitud en tiempo real: '+position.coords.latitude);
      console.log('Longitud en tiempo real: '+position.coords.longitude);

      if (this.ValGeolocalizacion==0){
        navigator.geolocation.clearWatch(this.ubicacion);
        //this.ubicacion = null;
        console.log('Salio de la ubicacion');
      }
    })*/
  }

  PositionRealTime (position: number){
    /*if (position==1){
      this.ValGeolocalizacion = 1;
      console.log("ValGeo: "+this.ValGeolocalizacion);
      this.getPositionRealTime();
    } else {
      this.ValGeolocalizacion = 0;
      console.log("ValGeo: "+this.ValGeolocalizacion);
    }*/
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

        //console.log(this.directionDisplay.panel.innerText);
        //console.log(this.directionDisplay);
        this.direccionesRuta(response);

      } else {
        alert('su dispositivo no permite la geolocalizacion');
      }

      //Guarda e Imprime la direcciones en un archivo .txt      
      //var blob = new Blob(["Hola soy Edgar"], {type: "text/plain;charset=utf-8"});
      //saveAs(blob, "ruta GPX.txt");

      //console.log(this.directionDisplay.directions.routes[0].legs[0].steps);
  
    });

  }


  direccionesRuta(directionResult) {
    var myRoute = directionResult.routes[0].legs[0];
     for (var i = 0; i < myRoute.steps.length; i++) {
      var duration = myRoute.steps[i].duration.text;
      var path = myRoute.steps[i].path;
      var polyline1 = myRoute.steps[i].distance.text;
    }
    console.log(myRoute);
    console.log(myRoute.distance.text);

    //Titulo Direcciones
    document.getElementById('KilometrajeRuta').innerHTML=myRoute.distance.text;
    //console.log(myRoute.steps[17].instructions);
   }



  getCronometro(){

    var contadorS: number; 
    contadorS = 0;
    var contadorM: number; 
    contadorM = 0;
    var contadorH: number; 
    contadorH = 0;

    this.cronometro = setInterval(
      function(){

        if(contadorS==60){
          contadorS=0;
          contadorM++;

          if(contadorM==60){
            contadorM=0;
            contadorH++;
            this.horasT.innerHTML = contadorH;
          }

          this.minutosT.innerHTML = contadorM;

        }

        this.contador_s=contadorS;
        this.contador_m=contadorM;
        this.contador_h=contadorH;

        console.log(this.contador_h+":"+this.contador_m+":"+this.contador_s);
        
        //Visualiza los segundos y minutos en el html
        contadorS++;
        this.segundosT.innerHTML = contadorS;
      }
      //Cantidad de tiempo para ejecutar el codigo
      ,1000
    );
  }

  reiniciarCronometro(){

    clearInterval(this.cronometro);

    var contadorS: number; 
    contadorS = 0;

    this.cronometro = setInterval(
      function(){

        if(contadorS==0){
          this.segundosT.innerHTML = "0";
          this.minutosT.innerHTML = "0";
          this.horasT.innerHTML = "0";
          clearInterval(this.cronometro);
        }
        //segundos
        contadorS++;
      }
      //Cantidad de tiempo para ejecutar el codigo
      ,1000
    );

    console.log(this.contador_h+":"+this.contador_m+":"+this.contador_s);
  }

  detenerCronometro(){
    clearInterval(this.cronometro);
  }

}



/*
var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
      if (this.readyState == 4 && this.status == 200) {
          var address = JSON.parse(this.responseText);
          console.log(address);
          console.log(address.results[1].formatted_address);
          console.log(address.results[2].formatted_address);

      }
    };
    xhttp.open("GET", "https://maps.googleapis.com/maps/api/geocode/json?latlng="+this.lat_Inicio+","+this.long_Inicio+"&key=AIzaSyDYp93ij7X3_elgT0FFT0RTZKHRb_gpRsw", true);
    xhttp.send();
*/