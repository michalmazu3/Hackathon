import { Injectable, Inject } from '@angular/core';
import { Observable  } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
 
 export class BaseService {




   constructor(protected httpClient: HttpClient, protected controllerName: string, protected baseUrl: string) { }

  protected get controllerUrl(): string {
    return `api/${this.controllerName}`;
  }


  //protected handleError<T>(operation = 'operation', result?: T) {
  //  return (error: any): Observable<T> => {

  //    // TODO: send the error to remote logging infrastructure
  //    console.error(error); // log to console instead

  //    // TODO: better job of transforming error for user consumption
  //    console.log(`${operation} failed: ${error.message}`);

  //    // Let the app keep running by returning an empty result.
  //    return of(result as T);
  //  };
  //}
}