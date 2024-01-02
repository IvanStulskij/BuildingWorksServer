import { LoadResult } from "src/app/types/loader";
import { EProviderActions, ProviderActions } from "../actions/provider.actions";
import { IProviderState, initialProviderState } from "../states/provider.state";
import { Provider } from "src/app/types/providers";

export const providerReducer = (
    state = initialProviderState,
    action: ProviderActions
) : IProviderState => {
    switch (action.type) {
        case EProviderActions.GetProvidersSuccess: {
            return {
                ...state,
                loadResult: action.payload
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
                loadResult: action.payload
            }
        }
        case EProviderActions.CreateProviderSuccess: {
            let providers = state.loadResult!.data;
            providers.push(action.payload);
            let loadResult: LoadResult<Provider> = {
                data: providers,
                totalCount: providers.length
            };

            return {
                ...state,
                loadResult: loadResult
            }
        }
        case EProviderActions.AddProviderToBuildingObjectSuccess: {
            return {
                ...state,
                loadResult: state.loadResult
            }
        }
        case EProviderActions.UpdateProviderSuccess: {
            let providerIndex = state.loadResult!.data.indexOf(state.loadResult!.data.filter(provider => provider.id == action.payload.id)[0]);
            
            state.loadResult!.data[providerIndex] = action.payload;
            
            return {
                ...state,
                loadResult: state.loadResult
            }
        }
        case EProviderActions.DeleteProvider: {
            let providers = state.loadResult!.data.filter(provider => provider.id != action.payload);
            let loadResult: LoadResult<Provider> = {
                data: providers,
                totalCount: providers.length
            };

            return {
                ...state,
                loadResult: loadResult
            }
        }
        default: {
            return state;
        }
    }
}