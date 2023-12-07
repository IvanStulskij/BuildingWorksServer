import { createSelector } from "@ngrx/store";
import { IAppState } from "../states/app.state";
import { IOrderMaterialState } from "../states/order-material.state";

const selectOrderMaterials = (state: IAppState) => state.orderMaterials;

export const selectOrderMaterialList = createSelector(
    selectOrderMaterials,
    (state: IOrderMaterialState) => state.materials
);