 
import { Injectable, Inject } from '@angular/core';
import { BaseService } from '../base.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { Field, Cordinate, Order, Alerts } from '../../model/api/api.models';
 
@Injectable()
export class GreenFieldsService extends BaseService {


  constructor(httpClient: HttpClient) {
    super(httpClient, "Fields", "http://localhost:60464")
  }
  //getListForDataTables(parameters: any, weighstationId): Observable<IDataTablesResponse> {
  //  return this.httpClient.post<IDataTablesResponse>(`${this.baseUrl}/${this.controllerUrl}/listallweighingdefinitionsdt/${weighstationI       parameters)
  //}
  getList(): Observable<Field[]> {

    return this.httpClient.get<Field[]>(`${this.baseUrl}/${this.controllerUrl}/getAll`).
      pipe(
        tap((t) => { console.log(t) })
        //catchError(this.handleError('getById select2', null))
      );
  }


  //getById(id: number): Observable<ProblemNotificationModel> {

  //  return this.httpClient.get<ProblemNotificationModel>(`${this.baseUrl}/${this.controllerUrl}/${id}`).
  //    pipe(
  //      tap((t) => { console.log(t) })
  //      //catchError(this.handleError('getById select2', null))
  //    );
  //}
  //getById(id: number): Observable<WeighingDefinitionModel> {

  //  return this.httpClient.get<WeighingDefinitionModel>(`${this.baseUrl}/${this.controllerUrl}/getweighingdefinitionbyid/${id}`).
  //    pipe(
  //      tap((t) => { console.log(t) }),
  //      catchError(this.handleError('getById select2', null))
  //    );
  //}
  //delete(id: number): Observable<WeighingDefinitionModel> {

  //  return this.httpClient.delete<WeighingDefinitionModel>(`${this.baseUrl}/${this.controllerUrl}/deleteweighingdefinitionbyid/${id}`).
  //    pipe(
  //      tap((t) => { console.log(t) }),
  //      catchError(this.handleError('delete WeighningDefinition', null))
  //    );
  //}
  //update(id: number, model: any): Observable<WeighingDefinitionModel> {
  //  let headers = new HttpHeaders();

  //  headers = headers.set('Content-Type', 'application/json');
  //  headers = headers.set('Accept', 'application/json');

  //  var body = {
  //    "weighingDefinition": model
  //  }

  //  return this.httpClient.put<WeighingDefinitionModel>(`${this.baseUrl}/${this.controllerUrl}/updateweighingdefinition/${id}`, model, { headers: headers }).
  //    pipe(
  //      tap((t) => { console.log(t) }),
  //      catchError(this.handleError('update WeighingDefinition', null))
  //    );
  //}

  createAlert(model: any): Observable<Alerts> {
    let headers = new HttpHeaders();

    headers = headers.set('Content-Type', 'application/json');
    headers = headers.set('Accept', 'application/json');

    var body = {
      "alert": model
    }

    return this.httpClient.post<Alerts>(`${this.baseUrl}/api/alert`, model, { headers: headers }).
      pipe(
        tap((t) => { console.log(t) }),
       );
  }

  createOrder(model: any): Observable<Order> {
    let headers = new HttpHeaders();

    headers = headers.set('Content-Type', 'application/json');
    headers = headers.set('Accept', 'application/json');

    var body = {
      "order": model
    }

    return this.httpClient.post<Order>(`${this.baseUrl}/api/Orders`, model, { headers: headers }).
      pipe(
        tap((t) => { console.log(t) }),
    );
  }



  //selectToEdit(weighingDefinitionModel: WeighingDefinitionMessage) {
  //  this.weighingDefinitionSource.next(weighingDefinitionModel);
  //}
}
