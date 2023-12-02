import { createSelector } from "@ngrx/store";
import { IAppState } from "../states/app.state";
import { IOrderState } from "../states/building-object-order.state";

const selectOrders = (state: IAppState) => state.orders;

export const selectBuildingObjectOrderList = createSelector(
    selectOrders,
    (state: IOrderState) => state.orders
);

export const selectBuildingObjectOrder = createSelector(
    selectOrders,
    (state: IOrderState) => state.selectedOrder
);