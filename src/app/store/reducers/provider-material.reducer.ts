import { EMaterialActions, MaterialActions } from "../actions/material.actions";
import { IProviderMaterialState, initialProviderMaterialState } from "../states/provider-material.state";

export const providerMaterialReducer = (
    state = initialProviderMaterialState,
    action: MaterialActions
) : IProviderMaterialState => {
    switch (action.type) {
        case EMaterialActions.GetMaterialsByProviderSuccess: {
            return {
                ...state,
                providerMaterials: action.payload
            }
        }
        case EMaterialActions.AddMaterialToProvider: {
            return {
                ...state,
                providerMaterials: state.providerMaterials
            }
        }
        default: {
            return state;
        }
    }
}