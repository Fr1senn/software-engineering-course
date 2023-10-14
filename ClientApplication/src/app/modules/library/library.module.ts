import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { LibraryComponent } from './components/library/library.component';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { BooksComponent } from './components/books/books.component';
import { AddBookDialogComponent } from './components/books/add-book-dialog/add-book-dialog.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    LibraryComponent,
    BooksComponent,
    AddBookDialogComponent
  ],
  imports: [
    RouterModule.forRoot(routes),
    CommonModule,
    FormsModule,
    MatTableModule,
    MatTabsModule,
    MatButtonModule,
    MatIconModule,
    MatDialogModule,
    MatInputModule,
    MatSelectModule
  ]
})
export class LibraryModule { }
