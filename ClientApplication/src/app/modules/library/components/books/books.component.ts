import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { IBookService } from 'src/app/interfaces/IBookService';
import { Book } from 'src/app/models/book';
import { BookService } from 'src/app/services/book.service';
import { AddBookDialogComponent } from './add-book-dialog/add-book-dialog.component';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css'],
})
export class BooksComponent implements OnInit {
  public books: Book[] = [];
  public displayedColumns: string[] = ['Title', 'Publication Date', 'Authors Name', 'Action'];

  private readonly _bookService: IBookService;

  constructor(bookService: BookService, public dialog: MatDialog) {
    this._bookService = bookService;
  }

  ngOnInit(): void {
    this.getBooks();
  }

  public delete(book: Book) {
    this._bookService.deleteBook(book.id!).subscribe((data: any) => {
      this.books = this.books.filter((b: Book) => {
        return b.id !== book.id
      });
    })
  }

  public openDialog(): void {
    const authorsFullName: string[] = Array.from(new Set(this.books.flatMap(book => book.authors!.map(author => author.fullName))));

    this.dialog.open(AddBookDialogComponent, {
      data: authorsFullName
    }).afterClosed().subscribe(() => {
      this.getBooks();
    });
  }

  private getBooks(): void {
    this._bookService.getBooks().subscribe(data => {
      this.books = data;
    });
  }
}
