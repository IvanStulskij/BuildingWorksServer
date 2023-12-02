import { Order } from "src/app/types/order";

export interface IOrderState {
    orders: Order[];
    selectedOrder: Order | null;
}

export const initialOrderState: IOrderState = {
    orders: [],
    selectedOrder: null
};
