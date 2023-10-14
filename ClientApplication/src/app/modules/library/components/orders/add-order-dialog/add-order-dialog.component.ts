import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-add-order-dialog',
  templateUrl: './add-order-dialog.component.html',
  styleUrls: ['./add-order-dialog.component.css']
})
export class AddOrderDialogComponent {
  public order: {
    book: {
      title: string
    },
    reader: {
      fullName: string
    }
  } = {
      book: {
        title: ''
      },
      reader: {
        fullName: ''
      }
    };
  constructor(
    public dialog: MatDialogRef<AddOrderDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { 'books': string[], 'readers': string[] },
    private readonly _orderService: OrderService
  ) { }

  public closeDialog(): void {
    this.dialog.close();
  }

  public createOrder() {
    this._orderService.createOrder(this.order).subscribe(() => {
      this.dialog.close();
    });
  }
}
