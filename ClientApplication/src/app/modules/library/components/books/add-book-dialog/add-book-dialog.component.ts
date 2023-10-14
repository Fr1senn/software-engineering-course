import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Author } from 'src/app/models/author';
import { Book } from 'src/app/models/book';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-add-book-dialog',
  templateUrl: './add-book-dialog.component.html',
  styleUrls: ['./add-book-dialog.component.css']
})
export class AddBookDialogComponent {
  public book: Book = {
    title: '',
    publicationDate: new Date(),
    authors: []
  }

  constructor(
    public dialog: MatDialogRef<AddBookDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public authorsFullName: string[],
    private readonly _bookService: BookService
  ) {

  }

  public closeDialog(): void {
    this.dialog.close();
  }

  public createBook(): void {
    let authors: any = this.book.authors?.map(fullName => {
      return {
        fullName: fullName
      };
    });
    
    this.book.authors = authors;

    this._bookService.createBook(this.book).subscribe((data: any) => {
      this.dialog.close();
    });
  }
}
