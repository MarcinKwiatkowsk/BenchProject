import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Tick } from '../models/tick';
import { TickService } from '../tick.service';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.scss'],
})
export class ChartComponent implements OnInit {
  constructor(private tickService: TickService) {}

  seriesX: Array<number> = [];
  seriesY: Array<string> = [];

  ngOnInit(): void {
    this.getData(this.seriesX, this.seriesY);
    console.log(this.seriesX);
    console.log(this.seriesY);
  }

  getData(seriesX: Array<number>, seriesY: Array<string>) {
    this.tickService.getTicks().forEach(function (i: Tick): void {
      seriesX.push(i.getValue);
      seriesY.push(i.getDate);
    });
  }

  public chartType: string = 'line';

  public chartDatasets: Array<any> = [
    { data: this.seriesX, label: 'Google chart' },
  ];

  public chartLabels: Array<any> = [this.seriesY];

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
}
