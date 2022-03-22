import { HttpResponse } from '@angular/common/http';
import { Component, Input, OnInit, SimpleChanges } from '@angular/core';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap';
import { Subscription } from 'rxjs';
import { Tick } from '../models/tick';
import { TickService } from '../tick.service';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.scss'],
})
export class ChartComponent implements OnInit {
  constructor(private tickService: TickService) {}

  @Input() eventFromDate: NgbDate;
  series: Array<Tick> = [];
  seriesY: Array<number> = [];
  seriesX: Array<string> = [];

  ngOnInit(): void {}

  getData() {
    this.series = this.tickService.getSeries();
    this.seriesY = this.series.map(y => y.tickValue);
    this.seriesX = this.series.map(x => x.tickDateTime);
  }

  public chartType: string = 'line';

  public chartDatasets: Array<any> = [
    { data: this.seriesY, label: 'Google chart' },
  ];

  public chartLabels: Array<any> = [this.seriesX];

  public chartColors: Array<any> = [
    {
      backgroundColor: 'rgba(105, 0, 132, .2)',
      borderColor: 'rgba(200, 99, 132, .7)',
      borderWidth: 2,
    },
    {
      backgroundColor: 'rgba(0, 137, 132, .2)',
      borderColor: 'rgba(0, 10, 130, .7)',
      borderWidth: 2,
    },
  ];

  public chartOptions: any = {
    responsive: true,
  };
  public chartClicked(e: any): void {}
  public chartHovered(e: any): void {}
  
  ngOnChanges(changes: SimpleChanges) {
    if (changes.series) {
      this.reloadChart();
    }
  }
  reloadChart() {
    if (this.chart !== undefined) {
      this.setDataToChart();
    }
  }
}
