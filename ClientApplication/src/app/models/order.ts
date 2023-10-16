import { Book } from "./book";
import { Reader } from "./reader";

export type Order = {
    id: number,
    orderDate: Date,
    refundDate?: Date,

    book?: Book,
    reader?: Reader
};