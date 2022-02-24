import { Component, OnInit } from '@angular/core';
import { TickService } from './tick.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'bench';

  ngOnInit(): void {
    console.log(this.tickService.getTicks().subscribe());
  }

  constructor(private tickService: TickService){ }

}
