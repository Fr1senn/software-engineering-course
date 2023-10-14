import { Injectable } from '@angular/core';
import { IBookService } from '../interfaces/IBookService';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/envs/env';
import { Observable } from 'rxjs';
import { Book } from '../models/book';

@Injectable({
  providedIn: 'root'
})
export class BookService implements IBookService {
  private readonly _http: HttpClient;
  private readonly _apiURL: string = environment.baseApiUrl;

  constructor(http: HttpClient) {
    this._http = http;
  }

  createBook(book: Book) {
    return this._http.post(this._apiURL + '/Book', book);
  }

  deleteBook(bookId: number): any {
    return this._http.delete(this._apiURL + '/Book', {
      params: { 'bookId': bookId }
    });
  }

  public getBooks(): Observable<Book[]> {
    return this._http.get<Book[]>(this._apiURL + '/Book');
  }
}
