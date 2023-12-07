import { EMaterialActions, MaterialActions } from "../actions/material.actions";
import { IOrderMaterialState, initialOrderMaterialState } from "../states/order-material.state";

export const orderMaterialReducer = (
    state = initialOrderMaterialState,
    action: MaterialActions,
) : IOrderMaterialState => {
    switch (action.type) {
        case EMaterialActions.GetMaterialsByOrderSuccess: {
            return {
                ...state,
                materials: action.payload
            }
        }
        default: {
            return state;
        }
    }
}