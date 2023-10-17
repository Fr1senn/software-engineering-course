import { Component, OnInit } from '@angular/core';
import { ChartConfiguration } from 'chart.js';
import { IntegralService } from 'src/app/services/integral.service';

@Component({
  selector: 'app-integral-graph',
  templateUrl: './integral-graph.component.html',
  styleUrls: ['./integral-graph.component.css']
})
export class IntegralGraphComponent implements OnInit {
  public chartData: ChartConfiguration<'line'>['data'] = {
    labels: [],
    datasets: [
      { data: [], label: 'y(x) = (ln^2(x)) / x', fill: 'origin' },
      { data: [], label: 'Integrated', fill: 'origin' }
    ]
  };

  constructor(
    private readonly _integralService: IntegralService
  ) { }

  ngOnInit(): void {
    this.calculateIntegral();
  }

  private calculateIntegral() {
    const func = (x: number) => (Math.log(x) * Math.log(x)) / x;
    const a = 0.5;
    const b = 10;

    for (let x = a; x <= b; x += 0.5) {
      this.chartData.datasets[0].data.push(func(x));
      this.chartData.datasets[1].data.push(this._integralService.integrateTrapezoidal(func, x, b))
      this.chartData.labels?.push(x);
    }
  }
}
