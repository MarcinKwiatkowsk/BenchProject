import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { tick } from '@angular/core/testing';
import { NgbDate, NgbCalendar } from '@ng-bootstrap/ng-bootstrap';
import { Tick } from '../models/tick';
import { TickService } from '../tick.service';
import {Company} from 'src/app/models/company'

@Component({
  selector: 'app-datepicker',
  templateUrl: './datepicker.component.html',
  styleUrls: ['./datepicker.component.scss'],
})
export class DatepickerComponent implements OnInit {
  ngOnInit(): void {
    this.downloadDataToDropdown();
  }

  downloadDataToDropdown(){
    this.tickService.getCompanies()
    .subscribe(data => this.companies = data);
  }

  hoveredDate: NgbDate | null = null;
  ticks: Tick[] = [];
  companies: Company[];
  companyCode: string;
  fromDate: NgbDate;
  toDate: NgbDate | null;
  isSubmitted: boolean;

  constructor(calendar: NgbCalendar, private tickService: TickService) {
    this.fromDate = calendar.getToday();
    this.toDate = calendar.getNext(calendar.getToday(), 'd', 10);
  }

  onDateSelection(date: NgbDate) {
    if (!this.fromDate && !this.toDate) {
      this.fromDate = date;
    } else if (this.fromDate && !this.toDate && date.after(this.fromDate)) {
      this.toDate = date;
    } else {
      this.toDate = null;
      this.fromDate = date;
    }
  }

  isHovered(date: NgbDate) {
    return (
      this.fromDate &&
      !this.toDate &&
      this.hoveredDate &&
      date.after(this.fromDate) &&
      date.before(this.hoveredDate)
    );
  }

  isInside(date: NgbDate) {
    return this.toDate && date.after(this.fromDate) && date.before(this.toDate);
  }

  isRange(date: NgbDate) {
    return (
      date.equals(this.fromDate) ||
      (this.toDate && date.equals(this.toDate)) ||
      this.isInside(date) ||
      this.isHovered(date)
    );

  }

  submitDatesAndCode() {   
   //  this.tickService.setTicks(this.fromDate, this.toDate);
    
     this.tickService.getTicks(this.fromDate, this.toDate, this.companyCode).subscribe((res)=>{
       this.ticks = res;
       this.isSubmitted=true;
     });
     
     console.log(this.ticks);
  }

  getCompanyCode(){

  }
}
