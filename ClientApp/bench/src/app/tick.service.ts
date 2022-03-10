import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Tick } from './models/tick';
import { HttpParams } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class TickService {

  constructor(private http:HttpClient) { }

  //getTicks(startDate: Date, endDate: Date): Observable<Tick[]>{
  getTicks(): Observable<Tick>{
  //getTicks(){

   // const params = { params: new HttpParams({fromString: "_page=1&_limit=10"}) };
   //  return this.http.get<Tick[]>("https://localhost:44377/ticker", params);    
    return this.http.get<Tick>("https://localhost:44377/Ticker?startDate=2019-01-02%2016%3A00%3A00&endDate=2019-01-09%2016%3A00%3A00");    
    //return this.http.get("https://localhost:44377/Ticker?startDate=2019-01-02%2016%3A00%3A00&endDate=2019-01-09%2016%3A00%3A00");    
  }
}
