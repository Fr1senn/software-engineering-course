import { Book } from "./book";
import { Reader } from "./reader";

export type Order = {
    id: number,
    orderDate: Date,
    refundDate?: Date,
    readerId: number,
    bookId: number,

    books?: Book[],
    readers?: Reader[]
};