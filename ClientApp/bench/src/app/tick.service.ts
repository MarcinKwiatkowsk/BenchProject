import { Injectable, Input, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { delay, Observable, Subject } from 'rxjs';
import { Tick } from './models/tick';
import { HttpParams } from '@angular/common/http';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap';
import { EventEmitter } from '@angular/core';
import { setSyntheticTrailingComments } from 'typescript';
import { Company } from './models/company';

@Injectable({
  providedIn: 'root',
})
export class TickService {
  constructor(private http: HttpClient) {}

  @Output() generateChart = new EventEmitter<string>();

  private url = '';
  private series: Array<Tick> = [];
  private subject = new Subject<any>();
  @Input() companyCodeService: string = "GOOG";

  // setTicks(fromDate: NgbDate, toDate: NgbDate | null){

  //   let fromDateParsed = this.parseDate(fromDate);
  //   let toDateParsed = this.parseDate(toDate);    

  //   this.http.get<Tick[]>(`https://localhost:44377/Ticker?startDate=${fromDateParsed}%2016%3A00%3A00&endDate=${toDateParsed}%2016%3A00%3A00`).subscribe((res)=>{
  //     this.series = res;
  //   });
    
  // }

  getCompanies(){
    return this.http.get<Company[]>(`https://localhost:44377/Company`);
  }

  getTicks(fromDate: NgbDate, toDate: NgbDate | null, companyCode:string){
    let fromDateParsed = this.parseDate(fromDate);
    let toDateParsed = this.parseDate(toDate);
    
    // return this.http.get<Tick[]>(`https://localhost:44377/Ticker?startDate=${fromDateParsed}%2016%3A00%3A00&endDate=${toDateParsed}%2016%3A00%3A00`)

    return this.http.get<Tick[]>(`https://localhost:44377/Ticker?startDate=${fromDateParsed}&endDate=${toDateParsed}&companyCode=${companyCode}`);
  }

  setCompanyCode(companyCode: string){
    this.companyCodeService = companyCode;
    window.location.reload();
  }
 
  getSeries(){
    return this.series;
  }

  parseDate(date: NgbDate | null) {
    let year = date.year;
    let month = date.month;
    let day = date.day;
    let stringYear = year.toString();
    let stringMonth = month.toString();
    let stringDay = day.toString();
    if (month < 10) {
      stringMonth = `0${month}`;
    }
    if (day < 10) {
      stringDay = `0${day}`;
    }

    let result = `${year}-${month}-${day}`;

    return result;
  }
}
