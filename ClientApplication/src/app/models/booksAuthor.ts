import { Author } from "./author";
import { Book } from "./book";

export type BooksAuthor = {
    id: number,
    bookId: number,
    authorId: number,

    authors?: Author[],
    books?: Book[]
};