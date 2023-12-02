import { createSelector } from "@ngrx/store";
import { IAppState } from "../states/app.state";
import { IWorkerState } from "../states/worker.state";


const selectWorkers = (state: IAppState) => state.workers;

export const selectWorkerList = createSelector(
    selectWorkers,
    (state: IWorkerState) => state.workers
);

export const selectWorker = createSelector(
    selectWorkers,
    (state: IWorkerState) => state.selectedWorker
);