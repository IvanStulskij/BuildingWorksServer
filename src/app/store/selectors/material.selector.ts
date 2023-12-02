import { createSelector } from "@ngrx/store";
import { IAppState } from "../states/app.state";
import { IMaterialState } from "../states/material.state";


const selectMaterials = (state: IAppState) => state.materials;

export const selectMaterialList = createSelector(
    selectMaterials,
    (state: IMaterialState) => state.materials
);

export const selectMaterial = createSelector(
    selectMaterials,
    (state: IMaterialState) => state.selectedMaterial
);