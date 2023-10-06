import { Observable } from "rxjs";

export interface IRandomNumber {
    getRandomNumbers(): Observable<number[]>;
}