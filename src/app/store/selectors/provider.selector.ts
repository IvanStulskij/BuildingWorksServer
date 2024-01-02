import { createSelector } from "@ngrx/store";
import { IAppState } from "../states/app.state";
import { IProviderState } from "../states/provider.state";


const selectProviders = (state: IAppState) => state.providers;

export const selectProviderList = createSelector(
    selectProviders,
    (state: IProviderState) => state.loadResult
);

export const selectProvider = createSelector(
    selectProviders,
    (state: IProviderState) => state.selectedProvider
);