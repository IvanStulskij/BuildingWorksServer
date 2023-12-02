import { createSelector } from "@ngrx/store";
import { IAppState } from "../states/app.state";
import { IProviderMaterialState } from "../states/provider-material.state";

const selectProviderMaterials = (state: IAppState) => state.providerMaterials;

export const selectProviderMaterialList = createSelector(
    selectProviderMaterials,
    (state: IProviderMaterialState) => state.providerMaterials
);

export const selectProviderMaterial = createSelector(
    selectProviderMaterials,
    (state: IProviderMaterialState) => state.selectedMaterial
);