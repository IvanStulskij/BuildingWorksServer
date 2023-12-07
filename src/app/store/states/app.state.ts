import { RouterReducerState } from "@ngrx/router-store";
import { IBuildingObjectState, initialBuildingObjectState } from "./building-objects.state";
import { IPlanState, initialPlanState } from "./plan.state";
import { IProviderState, initialProviderState } from "./provider.state";
import { IWorkerState, initialWorkerState } from "./worker.state";
import { IMaterialState, initialMaterialState } from "./material.state";
import { IBuildingObjectProviderState, initialBuildingObjectProviderState } from "./building-object-provider.state";
import { IProviderMaterialState, initialProviderMaterialState } from "./provider-material.state";
import { IOrderState, initialOrderState } from "./building-object-order.state";
import { IOrderMaterialState, initialOrderMaterialState } from "./order-material.state";

export interface IAppState {
    router?: RouterReducerState;
    buildingObjects: IBuildingObjectState,
    plans: IPlanState,
    providers: IProviderState,
    workers: IWorkerState,
    materials: IMaterialState,
    buildingObjectProviders: IBuildingObjectProviderState,
    providerMaterials: IProviderMaterialState,
    orders: IOrderState,
    orderMaterials: IOrderMaterialState
}

export const initialAppState: IAppState = {
    buildingObjects: initialBuildingObjectState,
    plans: initialPlanState,
    providers: initialProviderState,
    workers: initialWorkerState,
    materials: initialMaterialState,
    buildingObjectProviders: initialBuildingObjectProviderState,
    providerMaterials: initialProviderMaterialState,
    orders: initialOrderState,
    orderMaterials: initialOrderMaterialState
}