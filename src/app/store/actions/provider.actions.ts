import { Action } from "@ngrx/store";
import { BuildingObjectProvider } from "src/app/types/building-objects";
import { Provider } from "src/app/types/providers";

export enum EProviderActions {
    GetProviders = '[Provider] Get Providers',
    GetProvidersSuccess = '[Provider] Get Providers Success',
    GetProvidersFail = '[Provider] Get Providers Fail',

    GetProvider = '[Provider] Get Provider',
    GetProviderSuccess = '[Provider] Get Provider Success',
    GetProviderFail = '[Provider] Get Provider Fail',

    GetProvidersByBuildingObject = '[Provider] Get Providers By Building Object',
    GetProvidersByBuildingObjectSuccess = '[Provider] Get Providers By Building Object Success',
    GetProvidersByBuildingObjectFail = '[Provider] Get Providers By Building Object Fail',

    CreateProvider = '[Provider] Create Provider',
    CreateProviderSuccess = '[Provider] Create Provider Success',
    CreateProviderFail = '[Provider] Create Provider Fail',

    AddProviderToBuildingObject = '[Provider] Add Provider To Building Object',
    AddProviderToBuildingObjectSuccess = '[Provider] Add Provider To Building Object Success',
    AddProviderToBuildingObjectFail = '[Provider] Add Provider To Building Object Fail',

    DeleteProvider = '[Provider] Delete Provider',
    DeleteProviderSuccess = '[Provider] Delete Provider Success',
    DeleteProviderFail = '[Provider] Delete Provider Fail',

    UpdateProvider = '[Provider] Update Provider',
    UpdateProviderSuccess = '[Provider] Update Provider Success',
    UpdateProviderFail = '[Provider] Update Provider Fail',
}

export class GetProviders implements Action {
    public readonly type = EProviderActions.GetProviders;
}

export class GetProvidersSuccess implements Action {
    public readonly type = EProviderActions.GetProvidersSuccess;
    constructor(public payload: Provider[]) {}
}

export class GetProvider implements Action {
    public readonly type = EProviderActions.GetProvider;
    constructor(public payload: string) {}
}

export class GetProviderSuccess implements Action {
    public readonly type = EProviderActions.GetProviderSuccess;
    constructor(public payload: Provider) {}
}

export class GetProvidersByBuildingObject implements Action {
    public readonly type = EProviderActions.GetProvidersByBuildingObject;
    constructor(public payload: string) {}
}

export class GetProvidersByBuildingObjectSuccess implements Action {
    public readonly type = EProviderActions.GetProvidersByBuildingObjectSuccess;
    constructor(public payload: Provider[]) {}
}

export class CreateProvider implements Action {
    public readonly type = EProviderActions.CreateProvider;
    constructor(public payload: Provider) {}
}

export class CreateProviderSuccess implements Action {
    public readonly type = EProviderActions.CreateProviderSuccess;
    constructor(public payload: Provider) {}
}

export class AddProviderToBuildingObject implements Action {
    public readonly type = EProviderActions.AddProviderToBuildingObject;
    constructor(public payload: BuildingObjectProvider) {}
}

export class AddProviderToBuildingObjectSuccess implements Action {
    public readonly type = EProviderActions.AddProviderToBuildingObjectSuccess;
}

export class DeleteProvider implements Action {
    public readonly type = EProviderActions.DeleteProvider;
    constructor(public payload: string) {}
}

export class DeleteProviderSuccess implements Action {
    public readonly type = EProviderActions.DeleteProviderSuccess;
}

export class UpdateProvider implements Action {
    public readonly type = EProviderActions.UpdateProvider;
    constructor(public payload: Provider) {}
}

export class UpdateProviderSuccess implements Action {
    public readonly type = EProviderActions.UpdateProviderSuccess;
    constructor(public payload: Provider) {}
}

export type ProviderActions = GetProviders | GetProvidersSuccess | GetProvider | GetProviderSuccess | GetProvidersByBuildingObject | GetProvidersByBuildingObjectSuccess | CreateProvider | CreateProviderSuccess | AddProviderToBuildingObject | AddProviderToBuildingObjectSuccess | DeleteProvider | DeleteProviderSuccess | UpdateProvider | UpdateProviderSuccess; 