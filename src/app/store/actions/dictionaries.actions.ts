import { Action } from '@ngrx/store';
import { DictionaryItem } from 'src/app/types/common';

export enum EDictionaryActions {
    GetBuildingObjectTypes = '[Building Object] Get Building Object Types',
    GetBuildingObjectTypesSuccess = '[Building Object] Get Building Object Types Success',
    GetBuildingObjectTypesFail = '[Building Object] Get Building Object Types Fail',
}

export class GetBuildingObjectTypes implements Action {
    public readonly type = EDictionaryActions.GetBuildingObjectTypes;
}

export class GetBuildingObjectTypesSuccess implements Action {
    public readonly type = EDictionaryActions.GetBuildingObjectTypesSuccess;
    constructor(public payload: DictionaryItem[]) {}
}

export type DictionaryActions = GetBuildingObjectTypes | GetBuildingObjectTypesSuccess;