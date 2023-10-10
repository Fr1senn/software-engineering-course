import { BooksAuthor } from "./booksAuthor";
import { Order } from "./order";

export type Book = {
    id: number,
    title: string,
    publicationDate: Date,

    booksAuthor?: BooksAuthor[],
    orders?: Order[]
};