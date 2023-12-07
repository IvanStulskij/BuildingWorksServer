import { ActionReducerMap } from "@ngrx/store";
import { IAppState } from "../states/app.state";
import { routerReducer } from "@ngrx/router-store";
import { buildingObjectReducer } from "./building-object.reducer";
import { planReducer } from "./plan.reducer";
import { workerReducer } from "./worker.reducer";
import { providerReducer } from "./provider.reducer";
import { materialReducer } from "./material.reducer";
import { buildingObjectProviderReducer } from "./building-object-provider.reducer";
import { providerMaterialReducer } from "./provider-material.reducer";
import { orderReducer } from "./order.reducer";
import { orderMaterialReducer } from "./order-material.reducer";

export const appReducers: ActionReducerMap<IAppState, any> = {
    router: routerReducer,
    buildingObjects: buildingObjectReducer,
    plans: planReducer,
    providers: providerReducer,
    workers: workerReducer,
    materials: materialReducer,
    buildingObjectProviders: buildingObjectProviderReducer,
    providerMaterials: providerMaterialReducer,
    orders: orderReducer,
    orderMaterials: orderMaterialReducer
};