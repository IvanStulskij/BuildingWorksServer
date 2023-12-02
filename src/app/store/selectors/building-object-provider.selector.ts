import { createSelector } from "@ngrx/store";
import { IAppState } from "../states/app.state";
 import { IBuildingObjectProviderState } from "../states/building-object-provider.state";

const selectBuildingObjectProviders = (state: IAppState) => state.buildingObjectProviders;

export const selectBuildingObjectProviderList = createSelector(
    selectBuildingObjectProviders,
    (state: IBuildingObjectProviderState) => state.providers
);

export const selectBuildingObjectProvider = createSelector(
    selectBuildingObjectProviders,
    (state: IBuildingObjectProviderState) => state.selectedProvider
);