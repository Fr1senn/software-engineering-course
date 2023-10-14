import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Order } from 'src/app/models/order';
import { OrderService } from 'src/app/services/order.service';
import { AddOrderDialogComponent } from './add-order-dialog/add-order-dialog.component';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {
  public orders: Order[] = [];
  public displayedColumns: string[] = ['Book', 'Reader', 'Order Date', 'Refund Date', 'Action'];

  constructor(
    public dialog: MatDialog,
    private readonly _orderService: OrderService) { }

  ngOnInit(): void {
    this.getOrders();
  }

  public deleteOrder(order: Order) {
    this._orderService.deleteOrder(order.id!).subscribe((data: any) => {
      this.orders = this.orders.filter((o: Order) => {
        return o.id !== order.id
      });
    });
  }

  public openDialog(): void {
    let books: string[] = this.orders.map(order => order.book!.title);
    let readers = [...new Set(this.orders
      .map(order => order.reader!.fullName)
      .filter(name => name !== null && name !== undefined))];
    this.dialog.open(AddOrderDialogComponent, {
      data: {
        'books': books,
        'readers': readers
      }
    }).afterClosed().subscribe(() => {
      this.getOrders();
    });
  }

  private getOrders() {
    this._orderService.getOrders().subscribe(data => {
      this.orders = data;
    });
  }

}
