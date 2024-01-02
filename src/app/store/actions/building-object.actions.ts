import { Action } from '@ngrx/store';
import { BuildingObject } from 'src/app/types/building-objects';
import { LoadConditions, LoadResult } from 'src/app/types/loader';

export enum EBuildingObjectActions {
    GetBuildingObjects = '[Building Object] Get Building Objects',
    GetBuildingObjectsSuccess = '[Building Object] Get Building Objects Success',
    GetBuildingObjectsFail = '[Building Object] Get Building Objects Fail',

    GetBuildingObject = '[Building Object] Get Building Object',
    GetBuildingObjectSuccess = '[Building Object] Get Building Object Success',
    GetBuildingObjectFail = '[Building Object] Get Building Object Fail',

    CreateBuildingObject = '[Building Object] Create Building Object',
    CreateBuildingObjectSuccess = '[Building Object] Create Building Object Success',
    CreateBuildingObjectFail = '[Building Object] Create Building Object Fail',

    DeleteBuildingObject = '[Building Object] Delete Building Object',
    DeleteBuildingObjectSuccess = '[Building Object] Delete Building Object Success',
    DeleteBuildingObjectFail = '[Building Object] Delete Building Object Fail',

    UpdateBuildingObject = '[Building Object] Update Building Object',
    UpdateBuildingObjectSuccess = '[Building Object] Update Building Object Success',
    UpdateBuildingObjectFail = '[Building Object] Update Building Object Fail',
}

export class GetBuildingObjects implements Action {
    public readonly type = EBuildingObjectActions.GetBuildingObjects;
    constructor(public payload: LoadConditions) {}
}

export class GetBuildingObjectsSuccess implements Action {
    public readonly type = EBuildingObjectActions.GetBuildingObjectsSuccess;
    constructor(public payload: LoadResult<BuildingObject>) {}
}

export class GetBuildingObject implements Action {
    public readonly type = EBuildingObjectActions.GetBuildingObject;
    constructor(public payload: string) {}
}

export class GetBuildingObjectSuccess implements Action {
    public readonly type = EBuildingObjectActions.GetBuildingObjectSuccess;
    constructor(public payload: BuildingObject) {}
}

export class CreateBuildingObject implements Action {
    public readonly type = EBuildingObjectActions.CreateBuildingObject;
    constructor(public payload: BuildingObject) {}
}

export class CreateBuildingObjectSuccess implements Action {
    public readonly type = EBuildingObjectActions.CreateBuildingObjectSuccess;
    constructor(public payload: BuildingObject) {}
}

export class DeleteBuildingObject implements Action {
    public readonly type = EBuildingObjectActions.DeleteBuildingObject;
    constructor(public payload: string) {}
}

export class DeleteBuildingObjectSuccess implements Action {
    public readonly type = EBuildingObjectActions.DeleteBuildingObjectSuccess;
}

export class UpdateBuildingObject implements Action {
    public readonly type = EBuildingObjectActions.UpdateBuildingObject;
    constructor(public payload: BuildingObject) {}
}

export class UpdateBuildingObjectSuccess implements Action {
    public readonly type = EBuildingObjectActions.UpdateBuildingObjectSuccess;
    constructor(public payload: BuildingObject) {}
}

export type BuildingObjectActions = GetBuildingObjects | GetBuildingObjectsSuccess | GetBuildingObject | GetBuildingObjectSuccess | CreateBuildingObject | CreateBuildingObjectSuccess | DeleteBuildingObject | DeleteBuildingObjectSuccess | UpdateBuildingObject | UpdateBuildingObjectSuccess;