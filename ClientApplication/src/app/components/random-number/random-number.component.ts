import { Component, ViewChild } from '@angular/core';
import { ChartConfiguration } from 'chart.js';
import { BaseChartDirective } from 'ng2-charts';
import { IRandomNumber } from 'src/app/interfaces/IRandomNumber';
import { RandomNumberService } from 'src/app/services/random-number.service';

@Component({
  selector: 'app-random-number',
  templateUrl: './random-number.component.html',
  styleUrls: ['./random-number.component.css']
})
export class RandomNumberComponent {
  public array: number[] = [];

  public barChartData: ChartConfiguration<'bar'>['data'] = {
    labels: [],
    datasets: [
      {data: []}
    ]
  };

  private readonly _randomNumber: IRandomNumber;
  @ViewChild(BaseChartDirective) chart: BaseChartDirective | undefined;

  constructor(randomNumber: RandomNumberService) {
    this._randomNumber = randomNumber;
  }

  public getRandomNumbers() {
    this._randomNumber.getRandomNumbers().subscribe(response => {
      this.array = response.sort((a, b) => a - b);
      this.barChartData.labels = this.countIntervals(this.array);
      this.barChartData.datasets[0].data = this.countNumbersInIntervals(this.array);
      this.chart?.update();
    })
  }

  public countNumbers(numbers: number[]): { [key: number]: number } {
    const numberCount: { [key: number]: number } = {};

    for (const number of numbers) {
      if (numberCount[number]) {
        numberCount[number]++;
      } else {
        numberCount[number] = 1;
      }
    }

    return numberCount;
  }

  public calculateVariance(numbers: number[]): number {

    const mean = numbers.reduce((sum, num) => sum + num, 0) / numbers.length;

    const sumOfSquares = numbers.reduce((sum, num) => sum + Math.pow(num - mean, 2), 0);

    return +(sumOfSquares / numbers.length).toFixed(3);
  }

  public calculateAverage(numbers: number[]): number {
    return +(numbers.reduce((sum, num) => sum + num, 0) / numbers.length).toFixed(3);
  }

  private countIntervals(numbers: number[]): number[] {
    let min: number = Math.min(...numbers);
    let intervalGap: number = (Math.max(...numbers) - min) / 10;
    let intervals: number[] = [];
    for (let i: number = 0; i < 10; i++) {
      let intervalStart: number = min + (i * intervalGap);
      let intervalEnd: number = intervalStart + intervalGap;
      intervals.push(intervalEnd);
    }

    return intervals;
  }

  private countNumbersInIntervals(numbers: number[]): number[] {
    const intervals: number[] = Array.from({ length: 10 }, () => 0);

    const min = Math.min(...numbers);
    const max = Math.max(...numbers);
    const intervalWidth = (max - min) / 10;

    numbers.forEach(num => {
        const intervalIndex = Math.floor((num - min) / intervalWidth);
        intervals[intervalIndex]++;
    });

    return intervals;
}

}
