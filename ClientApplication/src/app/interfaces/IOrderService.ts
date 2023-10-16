import { Observable } from "rxjs";
import { Order } from "../models/order";

export interface IOrderRepository {
    getOrders(): Observable<Order[]>;
    deleteOrder(orderId: number): Observable<string>;
    createOrder(order: {
        book: {
            title: string
        },
        reader: {
            fullName: string
        }
    }): Observable<string>;
}