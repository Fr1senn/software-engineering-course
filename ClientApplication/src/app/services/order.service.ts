import { Injectable } from '@angular/core';
import { IOrderRepository } from '../interfaces/IOrderService';
import { Observable } from 'rxjs';
import { Order } from '../models/order';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/envs/env';

@Injectable({
  providedIn: 'root'
})
export class OrderService implements IOrderRepository {
  private readonly _http: HttpClient;
  private readonly _apiURL: string = environment.baseApiUrl;

  constructor(http: HttpClient) {
    this._http = http;
  }
  createOrder(order: { book: { title: string; }; reader: { fullName: string; }; }): Observable<string> {
    return this._http.post<string>(this._apiURL + '/Order', order);
  }

  deleteOrder(orderId: number): Observable<string> {
    return this._http.delete<string>(this._apiURL + '/Order', {
      params: { 'orderId': orderId }
    });
  }

  getOrders(): Observable<Order[]> {
    return this._http.get<Order[]>(this._apiURL + '/Order')
  }
}
