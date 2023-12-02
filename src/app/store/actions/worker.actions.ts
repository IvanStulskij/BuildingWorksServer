import { Action } from "@ngrx/store";
import { Worker } from "src/app/types/workers";

export enum EWorkerActions {
    GetWorkers = '[Worker] Get Workers',
    GetWorkersSuccess = '[Worker] Get Workers Success',
    GetWorkersFail = '[Worker] Get Workers Fail',

    GetWorker = '[Worker] Get Worker',
    GetWorkerSuccess = '[Worker] Get Worker Success',
    GetWorkerFail = '[Worker] Get Worker Fail',

    CreateWorker = '[Worker] Create Worker',
    CreateWorkerSuccess = '[Worker] Create Worker Success',
    CreateWorkerFail = '[Worker] Create Worker Fail',

    DeleteWorker = '[Worker] Delete Worker',
    DeleteWorkerSuccess = '[Worker] Delete Worker Success',
    DeleteWorkerFail = '[Worker] Delete Worker Fail',

    UpdateWorker = '[Worker] Update Worker',
    UpdateWorkerSuccess = '[Worker] Update Worker Success',
    UpdateWorkerFail = '[Worker] Update Worker Fail',
}

export class GetWorkers implements Action {
    public readonly type = EWorkerActions.GetWorkers;
}

export class GetWorkersSuccess implements Action {
    public readonly type = EWorkerActions.GetWorkersSuccess;
    constructor(public payload: Worker[]) {}
}

export class GetWorker implements Action {
    public readonly type = EWorkerActions.GetWorker;
    constructor(public payload: string) {}
}

export class GetWorkerSuccess implements Action {
    public readonly type = EWorkerActions.GetWorkerSuccess;
    constructor(public payload: Worker) {}
}

export class CreateWorker implements Action {
    public readonly type = EWorkerActions.CreateWorker;
    constructor(public payload: Worker) {}
}

export class CreateWorkerSuccess implements Action {
    public readonly type = EWorkerActions.CreateWorkerSuccess;
    constructor(public payload: Worker) {}
}

export class DeleteWorker implements Action {
    public readonly type = EWorkerActions.DeleteWorker;
    constructor(public payload: string) {}
}

export class DeleteWorkerSuccess implements Action {
    public readonly type = EWorkerActions.DeleteWorkerSuccess;
}

export class UpdateWorker implements Action {
    public readonly type = EWorkerActions.UpdateWorker;
    constructor(public payload: Worker) {}
}

export class UpdateWorkerSuccess implements Action {
    public readonly type = EWorkerActions.UpdateWorkerSuccess;
    constructor(public payload: Worker) {}
}

export type WorkerActions = GetWorkers | GetWorkersSuccess | GetWorker | GetWorkerSuccess | CreateWorker | CreateWorkerSuccess | DeleteWorker | DeleteWorkerSuccess | UpdateWorker | UpdateWorkerSuccess;  