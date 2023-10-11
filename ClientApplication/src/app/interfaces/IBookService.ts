import { Observable } from "rxjs";
import { Book } from "../models/book";

export interface IBookService {
    getBooks(): Observable<Book[]>;
    deleteBook(bookId: number): any;
    createBook(bood: Book): any;
};