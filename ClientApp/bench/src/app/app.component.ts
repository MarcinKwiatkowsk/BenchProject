import { Component, OnInit } from '@angular/core';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap';
import { TickService } from './tick.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'bench';
  public fromDateEvent;

  receiveFromDate(event: NgbDate){
    this.fromDateEvent = event;
  }

  ngOnInit(): void {
   
  }

  constructor(private tickService: TickService){ }

}
