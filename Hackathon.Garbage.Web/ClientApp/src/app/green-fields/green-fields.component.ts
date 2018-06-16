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
import { MatDialog, MatDialogRef, MatDialogConfig, MAT_DIALOG_DATA, MatFormField, MatCard, MatIcon, MatDialogActions, MatDialogContent, MatInput, MatList } from '@angular/material';
import { FormBuilder, FormGroup } from '@angular/forms';
import { EXPANSION_HELPERS } from '../material-widgets/expansion-panel/helpers.data';
import { ScrollStrategy } from '@angular/cdk/overlay';
import { GreenFieldsService } from '../service/green-fields/green-fields.service';
import { log } from '@firebase/database/dist/esm/src/core/util/util';
import { Image } from '@ks89/angular-modal-gallery';
import { StarPipe } from './star.pipe'
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
  expansionHelpers = EXPANSION_HELPERS;
 




  @ViewChild(AgmMap) private myMap: AgmMap;
  @ViewChild('mapContainer') mapContainer: any;
  constructor(private mapsAPILoader: MapsAPILoader, @Inject('problemNotificationService') private problemNotificationService,
    @Inject('greenFieldsService') private greenFieldsService, public dialog: MatDialog
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
    this.openDialog(field);
    console.log(field.name);

  }
  ngDoCheck() {
    // let h = this.mapContainer.nativeElement.offsetHeight - 10;
    // this.height = String(h) + 'px';
  }


  test: string = "dfsdfsf";
  openDialog(field: Field) {


    const dialogConfig = new MatDialogConfig();
    dialogConfig.maxHeight = '200px',
      dialogConfig.minWidth = '400px',
      dialogConfig.position = {
        top: '5px'
      };

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;

    dialogConfig.data = {
      field: field
    };

    this.dialog.open(DialogOverviewExampleDialog, dialogConfig);
  }
  mouseOver(): void{

    console.log('over');
  }


  private convertStringToNumber(value: string): number {
    return +value;
  }
}
@Component({
  selector: 'dialog-overview-example-dialog',
  templateUrl: 'dialog-overview-example-dialog.html',
  styleUrls: ['./green-fields.component.scss']

})
export class DialogOverviewExampleDialog {

  planExecutiveForm: FormGroup;
  alertForm: FormGroup;
  form: FormGroup;
  description: string;


  field: Field;

  images: Image[] = [
    new Image(
      0,
      { // modal
        img: 'http://images29.fotosik.pl/196/b6ddff77267a1c4amed.jpg',
        extUrl: 'http://www.google.com'
      }
    )
 
  ];
  constructor(
    private fb: FormBuilder,
    @Inject('greenFieldsService') private greenFieldsService: GreenFieldsService,
    private dialogRef: MatDialogRef<DialogOverviewExampleDialog>,
    @Inject(MAT_DIALOG_DATA) data) {

    this.field = data.field;
    this.description = data.description;


  }

  ngOnInit() {
    this.form = this.fb.group({
      description: [this.description, []],

    });

    this.planExecutiveForm = this.fb.group({
      fieldId: [this.field.id],
      executiveId: ['', []],
      deadlineDate: [new Date(), []],
      status: [1]
    });
    this.alertForm = this.fb.group({
      title: ['', []],
      message: ['', []],
      startDate: ['', []],
      endDate: ['', []]

    });
  }

  planExecutive(): void {


    console.log(this.planExecutiveForm.value)
    this.greenFieldsService.createOrder(this.planExecutiveForm.value).subscribe(res => {
      console.log("dodano");
      
    });

  }

  alerts(): void {
    console.log(this.alertForm.value)
    this.greenFieldsService.createAlert(this.alertForm.value).subscribe(res => console.log("dodano"));


  }

  save() {
    this.dialogRef.close(this.form.value);
  }

  close() {
    this.dialogRef.close();
  }
}
