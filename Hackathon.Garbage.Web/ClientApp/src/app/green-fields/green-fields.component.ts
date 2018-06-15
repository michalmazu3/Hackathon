import { Component, OnInit, ViewChild, HostListener, Inject, SimpleChange } from '@angular/core';
import { AgmMap, AgmCoreModule } from '@agm/core';
import { MapsAPILoader } from '@agm/core';
import { ProblemNotificationService } from '../service/problem-notification/problem-notification.service';
import { Marker } from '@agm/core/services/google-maps-types';
import { ProblemNotificationModel } from '../model/api/problem-notification';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr'
import { VertexModel } from '../models/vertex.model';
import { LatLngLiteral } from '../models/google-maps-types';
import { Field, Cordinate, Order } from '../model/api/api.models';


@Component({
  selector: 'app-green-fields',
  templateUrl: './green-fields.component.html',
  styleUrls: ['./green-fields.component.scss']
})
export class GreenFieldsComponent implements OnInit {
  markers: ProblemNotificationModel[];
  title: string = 'Kielce';
  lng: number = 20.628671;
  lat: number = 50.865544;
  zoom: number = 0;
  height: string = '500px';
  fields: Field[];

  paths: Array<LatLngLiteral> = [
    { lat: 25.774, lng: -80.190 },
    { lat: 18.466, lng: -66.118 },
    { lat: 32.321, lng: -64.757 },
    { lat: 25.774, lng: -80.190 }

  ]


  @ViewChild(AgmMap) private myMap: AgmMap;
  @ViewChild('mapContainer') mapContainer: any;
  constructor(private mapsAPILoader: MapsAPILoader, @Inject('problemNotificationService') private problemNotificationService,
    @Inject('greenFieldsService') private greenFieldsService

  ) {
  }

  ngOnInit() {


    this.greenFieldsService.getList().subscribe(res => {
      console.log(res);
      this.fields = res;
    });





    const connection = new HubConnectionBuilder()
      .withUrl("http://localhost:60464/PhotoNotification")
      .build();

    connection.on("NewProblemNotification", (message, id) => {
      console.log(`recevie: ${message} - ${id}`)
      this.problemNotificationService.getById(id).subscribe(res => {
        this.markers.push(res);
      });
    });

    connection.start()
      //.then((m) => console.log(m))
      .catch(err => console.error(err.toString()));

    this.problemNotificationService.getList().subscribe(res => {
      this.markers = res;

    });
    setTimeout(() => {
      console.log(this.mapContainer.nativeElement.offsetHeight);
      // let h = this.mapContainer.nativeElement.offsetHeight - 10;
      // this.height = String(h) + 'px';
    }, 300);
  }

  clickField(field: Field) {
    console.log(field.name);

  }
  ngDoCheck() {
    // let h = this.mapContainer.nativeElement.offsetHeight - 10;
    // this.height = String(h) + 'px';
  }
  private convertStringToNumber(value: string): number {
    return +value;
  }
}
