import { Action } from "@ngrx/store";
import { Material, MaterialContract } from "src/app/types/material";

export enum EMaterialActions {
    GetMaterials = '[Material] Get Materials',
    GetMaterialsSuccess = '[Material] Get Materials Success',
    GetMaterialsFail = '[Material] Get Materials Fail',

    GetMaterial = '[Material] Get Material',
    GetMaterialSuccess = '[Material] Get Material Success',
    GetMaterialFail = '[Material] Get Material Fail',

    GetMaterialsByProvider = '[Material] Get Materials By Provider',
    GetMaterialsByProviderSuccess = '[Material] Get Materials By Provider Success',
    GetMaterialsByProviderFail = '[Material] Get Materials By Provider Fail',

    GetMaterialsByContract = '[Material] Get Materials By Contract',
    GetMaterialsByContractSuccess = '[Material] Get Materials By Contract Success',
    GetMaterialsByContractFail = '[Material] Get Materials By Contract Fail',

    CreateMaterial = '[Material] Create Material',
    CreateMaterialSuccess = '[Material] Create Material Success',
    CreateMaterialFail = '[Material] Create Material Fail',

    AddMaterialToProvider = '[Material] Add Material To Provider',
    AddMaterialToProviderSuccess = '[Material] Add Material To Provider Success',
    AddMaterialToProviderFail = '[Material] Add Material To Provider Fail',

    AddMaterialToContract = '[Material] Add Material To Contract',
    AddMaterialToContractSuccess = '[Material] Add Material To Contract',
    AddMaterialToContractFail = '[Material] Create Material Fail',

    DeleteMaterial = '[Material] Delete Material',
    DeleteMaterialSuccess = '[Material] Delete Material Success',
    DeleteMaterialFail = '[Material] Delete Material Fail',

    DeleteContractMaterial = '[Material] Delete Contract Material',
    DeleteContractMaterialSuccess = '[Material] Delete Contract Material Success',
    DeleteContractMaterialFail = '[Material] Delete Contract Material Fail',

    UpdateMaterial = '[Material] Update Material',
    UpdateMaterialSuccess = '[Material] Update Material Success',
    UpdateMaterialFail = '[Material] Update Material Fail',
}

export class GetMaterials implements Action {
    public readonly type = EMaterialActions.GetMaterials;
}

export class GetMaterialsSuccess implements Action {
    public readonly type = EMaterialActions.GetMaterialsSuccess;
    constructor(public payload: Material[]) {}
}

export class GetMaterialsByProvider implements Action {
    public readonly type = EMaterialActions.GetMaterialsByProvider;
    constructor(public payload: string) {} 
}

export class GetMaterialsByProviderSuccess implements Action {
    public readonly type = EMaterialActions.GetMaterialsByProviderSuccess;
    constructor(public payload: Material[]) {} 
}

export class GetMaterial implements Action {
    public readonly type = EMaterialActions.GetMaterial;
    constructor(public payload: string) {}
}

export class GetMaterialSuccess implements Action {
    public readonly type = EMaterialActions.GetMaterialSuccess;
    constructor(public payload: Material) {}
}

export class GetMaterialsByContract implements Action {
    public readonly type = EMaterialActions.GetMaterialsByContract;
    constructor(public payload: string, public providerId: string) {}
}

export class GetMaterialsByContractSuccess implements Action {
    public readonly type = EMaterialActions.GetMaterialsByContractSuccess;
    constructor(public payload: Material[]) {}
}

export class AddMaterialToProvider implements Action {
    public readonly type = EMaterialActions.AddMaterialToProvider;
    constructor(public payload: MaterialContract) {}
}

export class AddMaterialToProviderSuccess implements Action {
    public readonly type = EMaterialActions.AddMaterialToProviderSuccess;
}

export class AddMaterialToContract implements Action {
    public readonly type = EMaterialActions.AddMaterialToContract;
    constructor(public payload: MaterialContract) {}
}

export class AddMaterialToContractSuccess implements Action {
    public readonly type = EMaterialActions.AddMaterialToContractSuccess;
}

export class CreateMaterial implements Action {
    public readonly type = EMaterialActions.CreateMaterial;
    constructor(public payload: Material) {}
}

export class CreateMaterialSuccess implements Action {
    public readonly type = EMaterialActions.CreateMaterialSuccess;
    constructor(public payload: Material) {}
}

export class DeleteMaterial implements Action {
    public readonly type = EMaterialActions.DeleteMaterial;
    constructor(public payload: string) {}
}

export class DeleteMaterialSuccess implements Action {
    public readonly type = EMaterialActions.DeleteMaterialSuccess;
}

export class DeleteContractMaterial implements Action {
    public readonly type = EMaterialActions.DeleteContractMaterial;
    constructor(public payload: MaterialContract) {}
}

export class DeleteContractMaterialSuccess implements Action {
    public readonly type = EMaterialActions.DeleteContractMaterialSuccess;
}

export class DeleteContractMaterialFail implements Action {
    public readonly type = EMaterialActions.DeleteContractMaterialFail;
}

export class UpdateMaterial implements Action {
    public readonly type = EMaterialActions.UpdateMaterial;
    constructor(public payload: Material) {}
}

export class UpdateMaterialSuccess implements Action {
    public readonly type = EMaterialActions.UpdateMaterialSuccess;
    constructor(public payload: Material) {}
}

export type MaterialActions = 
    GetMaterials | GetMaterialsSuccess | 
    GetMaterial | GetMaterialSuccess | 
    GetMaterialsByProvider | GetMaterialsByProviderSuccess |
    GetMaterialsByContract  | GetMaterialsByContractSuccess |
    AddMaterialToContract | AddMaterialToContractSuccess |
    AddMaterialToProvider | AddMaterialToProviderSuccess |
    CreateMaterial | CreateMaterialSuccess | 
    DeleteMaterial | DeleteMaterialSuccess | 
    DeleteContractMaterial | DeleteContractMaterialSuccess |
    UpdateMaterial | UpdateMaterialSuccess;