import { HttpResponse } from '@angular/common/http';
import {
  Component,
  Input,
  OnInit,
  SimpleChanges,
  ViewChild,
  OnChanges,
} from '@angular/core';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap';
import { ChartsModule } from 'angular-bootstrap-md';
import { Subscription } from 'rxjs';
import { Tick } from '../models/tick';
import { TickService } from '../tick.service';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.scss'],
})
export class ChartComponent implements OnInit, OnChanges {
  @Input() series: Array<Tick> = [];

  constructor(private tickService: TickService) {}
  ngOnChanges(changes: SimpleChanges): void {
    console.log('ZMIENIONE');
    this.reloadChart();
  }

  reloadChart() {
    this.setDataToChart();
  }

  ngOnInit(): void {}

  public chartType: string = 'line';

  public chartDatasets: Array<any> = [{ data: [], label: 'Google chart' }];

  public chartLabels: Array<any> = [];

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

  chartOptions: any = {
    responsive: true,
  };
  public chartClicked(e: any): void {}
  public chartHovered(e: any): void {}

  setDataToChart() {
    let datasetArray = [];
    let labelArray = [];

    this.series.forEach((data) => {
      datasetArray.push(data.tickValue);
      labelArray.push(data.tickDateTime);
    });
    this.chartDatasets[0].data = datasetArray;
    this.chartLabels = labelArray;

    for (let i = 0; i < this.chartDatasets[0].data.length; i++) {
      console.log(
        'CHART DATASET: ' + i + ' TO: ' + this.chartDatasets[0].data[i]
      );
      console.log('CHART LABELS: ' + i + ' TO: ' + this.chartLabels[i]);
    }
  }
}
