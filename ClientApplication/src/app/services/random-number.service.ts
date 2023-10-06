import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/envs/env';
import { IRandomNumber } from '../interfaces/IRandomNumber';

@Injectable({
  providedIn: 'root'
})
export class RandomNumberService implements IRandomNumber {
  private readonly _http: HttpClient;
  private readonly _apiURL: string = environment.baseApiUrl;

  constructor(http: HttpClient) {
    this._http = http;
  }

  public getRandomNumbers(): Observable<number[]> {
    return this._http.get<number[]>(this._apiURL + '/RandomNumber');
  }
}
