import { Order } from "./order";

export type Reader = {
    id: number,
    fullName: string,
    education?: string,
    birthDate: Date,

    orders?: Order[]
};