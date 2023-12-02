import { EProviderActions, ProviderActions } from "../actions/provider.actions";
import { IProviderState, initialProviderState } from "../states/provider.state";

export const providerReducer = (
    state = initialProviderState,
    action: ProviderActions
) : IProviderState => {
    switch (action.type) {
        case EProviderActions.GetProvidersSuccess: {
            return {
                ...state,
                providers: action.payload
            }
        }
        case EProviderActions.GetProviderSuccess: {
            return {
                ...state,
                selectedProvider: action.payload
            }
        }
        case EProviderActions.GetProvidersByBuildingObjectSuccess: {
            return {
                ...state,
                providers: action.payload
            }
        }
        case EProviderActions.CreateProviderSuccess: {
            let providers = state.providers;
            providers.push(action.payload);

            return {
                ...state,
                providers: providers
            }
        }
        case EProviderActions.AddProviderToBuildingObjectSuccess: {
            return {
                ...state,
                providers: state.providers
            }
        }
        case EProviderActions.UpdateProviderSuccess: {
            let providerIndex = state.providers.indexOf(state.providers.filter(provider => provider.id == action.payload.id)[0]);
            
            state.providers[providerIndex] = action.payload;
            

            return {
                ...state,
                providers: state.providers
            }
        }
        case EProviderActions.DeleteProvider: {
            let providers = state.providers.filter(provider => provider.id != action.payload);

            return {
                ...state,
                providers: providers
            }
        }
        default: {
            return state;
        }
    }
}