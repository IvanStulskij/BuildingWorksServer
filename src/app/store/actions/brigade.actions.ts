import { Action } from '@ngrx/store';
import { Brigade } from 'src/app/types/brigades';

export enum EBrigadeActions {
    GetBrigades= '[Brigade] Get Building Objects',
    GetBrigadesSuccess = '[Brigade] Get Building Objects Success',
    GetBrigadesFail = '[Brigade] Get Building Objects Fail',

    GetBrigade = '[Brigade] Get Building Object',
    GetBrigadeSuccess = '[Building Object] Get Building Object Success',
    GetBrigadeFail = '[Building Object] Get Building Object Fail',

    CreateBrigade = '[Building Object] Create Building Object',
    CreateBrigadeSuccess = '[Building Object] Create Building Object Success',
    CreateBrigadeFail = '[Building Object] Create Building Object Fail',

    DeleteBrigade = '[Building Object] Delete Building Object',
    DeleteBrigadeSuccess = '[Building Object] Delete Building Object Success',
    DeleteBrigadeFail = '[Building Object] Delete Building Object Fail',

    UpdateBrigade = '[Building Object] Update Building Object',
    UpdateBrigadeSuccess = '[Building Object] Update Building Object Success',
    UpdateBrigadeFail = '[Building Object] Update Building Object Fail',
}

export class GetBrigades implements Action {
    public readonly type = EBrigadeActions.GetBrigades;
}

export class GetBrigadesSuccess implements Action {
    public readonly type = EBrigadeActions.GetBrigadeSuccess;
    constructor(public payload: Brigade[]) {}
}

export class GetBrigade implements Action {
    public readonly type = EBrigadeActions.GetBrigade;
    constructor(public payload: string) {}
}

export class GetBrigadeSuccess implements Action {
    public readonly type = EBrigadeActions.GetBrigadeSuccess;
    constructor(public payload: Brigade) {}
}

export class CreateBrigade implements Action {
    public readonly type = EBrigadeActions.CreateBrigade ;
    constructor(public payload: Brigade) {}
}

export class CreateBrigadeSuccess implements Action {
    public readonly type = EBrigadeActions.CreateBrigadeSuccess;
    constructor(public payload: Brigade) {}
}

export class DeleteBrigade implements Action {
    public readonly type = EBrigadeActions.DeleteBrigade;
    constructor(public payload: string) {}
}

export class DeleteBrigadeSuccess implements Action {
    public readonly type = EBrigadeActions.DeleteBrigadeSuccess;
}

export class UpdateBrigade implements Action {
    public readonly type = EBrigadeActions.UpdateBrigade;
    constructor(public payload: Brigade) {}
}

export class UpdateBrigadeSuccess implements Action {
    public readonly type = EBrigadeActions.UpdateBrigadeSuccess;
    constructor(public payload: Brigade) {}
}

export type BuildingObjectActions = GetBrigades | GetBrigadesSuccess | GetBrigade | GetBrigadeSuccess | CreateBrigade | CreateBrigadeSuccess | DeleteBrigade | DeleteBrigadeSuccess | UpdateBrigade | UpdateBrigadeSuccess;