import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { latLng, LeafletMouseEvent, marker, Marker, tileLayer } from 'leaflet';
import * as Mapboxgl from 'mapbox-gl';
import { environment } from 'src/environments/environment';
import { coordinatesMap,coordinatesMapWithMessage} from './coordinate';



@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css'],
})
export class MapComponent implements OnInit {
  map!:Mapboxgl.Map;
  constructor() {}

  ngOnInit(): void {
  // this.layers = this.initialCoordinates.map(value => marker([value.latitude,value.longitude]));

(Mapboxgl as any).accessToken=environment.mapboxKey;

var map = new Mapboxgl.Map({
  container: 'map-mapbox', // container ID
  style: 'mapbox://styles/mapbox/streets-v11', // style URL
  center: [17.813761,43.3437038], // starting position
  zoom: 12 // starting zoom
  });
      
  }

/*  @Input()
  initialCoordinates: coordinatesMap[] = [];

  @Input()
  editMode: boolean = true;

  @Output()
  onSelectedLocation = new EventEmitter<coordinatesMap>();

  options = {
    layers: [
      tileLayer('https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token={accessToken}', {
        maxZoom: 18,
        
        id:'mapbox/streets-v11',
    tileSize: 512,
    zoomOffset: -1,
     accessToken:'pk.eyJ1IjoiYWRlbTE5OTk5MSIsImEiOiJjbDE4NWUzcG0xbXlrM2NtdG9xbmM1ZWxoIn0.guSRFjHwAfqja-8oTJXyPg'
      }),
    ],
    zoom: 14,
    center: latLng(43.34828638969954, 17.805190086187128),
  };

  layers: Marker<any>[] = [];

  handleMapClick(event: LeafletMouseEvent) {
    //if (this.editMode){
      const latitude = event.latlng.lat;
      const longitude = event.latlng.lng;
      console.log({ latitude, longitude });
      this.layers = [];
      this.layers.push(marker([latitude, longitude]));
      this.onSelectedLocation.emit({ latitude, longitude });
    }
 */
}
