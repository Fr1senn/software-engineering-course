import { BooksAuthor } from "./booksAuthor";

export type Author = {
    id: number,
    fullName: string,

    booksAuthor?: BooksAuthor[]
};