import { Author } from "./author";
import { Order } from "./order";

export type Book = {
    id?: number,
    title: string,
    publicationDate: Date,

    authors?: Author[],
    orders?: Order[]
};