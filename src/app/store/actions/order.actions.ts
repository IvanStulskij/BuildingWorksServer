import { Action } from "@ngrx/store";
import { Order } from "src/app/types/order";

export enum EOrderActions {
    GetOrders = '[Order] Get Orders',
    GetOrdersSuccess = '[Order] Get Orders Success',
    GetOrdersFail = '[Order] Get Orders Fail',

    GetOrder = '[Order] Get Order',
    GetOrderSuccess = '[Order] Get Order Success',
    GetOrderFail = '[Order] Get Order Fail',

    CreateOrder = '[Order] Create Order',
    CreateOrderSuccess = '[Order] Create Order Success',
    CreateOrderFail = '[Order] Create Order Fail',
}

export class GetOrders implements Action {
    public readonly type = EOrderActions.GetOrders;
    constructor(public payload: string) {}
}

export class GetOrdersSuccess implements Action {
    public readonly type = EOrderActions.GetOrdersSuccess;
    constructor(public payload: Order[]) {}
}

export class GetOrder implements Action {
    public readonly type = EOrderActions.GetOrder;
    constructor(public payload: string) {}
}

export class GetOrderSuccess implements Action {
    public readonly type = EOrderActions.GetOrderSuccess;
    constructor(public payload: Order) {}
}

export class CreateOrder implements Action {
    public readonly type = EOrderActions.CreateOrder;
    constructor(public payload: Order) {}
}

export class CreateOrderSuccess implements Action {
    public readonly type = EOrderActions.CreateOrderSuccess;
    constructor(public payload: Order) {}
}

export type OrderActions =
                        GetOrders | GetOrdersSuccess |
                        GetOrder | GetOrderSuccess |
                        CreateOrder | CreateOrderSuccess;