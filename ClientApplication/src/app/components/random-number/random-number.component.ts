import { Component } from '@angular/core';

@Component({
  selector: 'app-random-number',
  templateUrl: './random-number.component.html',
  styleUrls: ['./random-number.component.css']
})
export class RandomNumberComponent {
  public array: number[] = [];

  private readonly _randomNumber: IRandomNumber;

  constructor(randomNumber: RandomNumberService) {
    this._randomNumber = randomNumber;
  }

  public getRandomNumbers() {
    this._randomNumber.getRandomNumbers().subscribe(response => {
      this.array = response.sort((a, b) => a - b);
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
}
