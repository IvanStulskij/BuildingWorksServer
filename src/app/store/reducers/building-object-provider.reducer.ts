import { EProviderActions, ProviderActions } from "../actions/provider.actions";
import { IBuildingObjectProviderState, initialBuildingObjectProviderState } from "../states/building-object-provider.state";

export const buildingObjectProviderReducer = (
    state = initialBuildingObjectProviderState,
    action: ProviderActions
) : IBuildingObjectProviderState => {
    switch (action.type) {
        case EProviderActions.GetProvidersByBuildingObjectSuccess: {
            return {
                ...state,
                providers: action.payload
            }
        }
        case EProviderActions.AddProviderToBuildingObjectSuccess: {
            return {
                ...state,
                providers: state.providers
            }
        }
        default: {
            return state;
        }
    }
}