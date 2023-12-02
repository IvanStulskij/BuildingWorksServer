import { EOrderActions, OrderActions } from "../actions/order.actions";
import { IOrderState, initialOrderState } from "../states/building-object-order.state";

export const orderReducer = (
    state = initialOrderState,
    action: OrderActions,
) : IOrderState => {
    switch (action.type) {
        case EOrderActions.GetOrdersSuccess: {
            return {
                ...state,
                orders: action.payload
            }
        }
        case EOrderActions.CreateOrder: {
            let orders = state.orders;
            orders.push(action.payload);

            return {
                ...state,
                orders: orders
            }
        }
        default: {
            return state;
        }
    }
}