import { LoadResult } from "src/app/types/loader";
import { EWorkerActions, WorkerActions } from "../actions/worker.actions";
import { IWorkerState, initialWorkerState } from "../states/worker.state";
import { Worker } from "src/app/types/workers";

export const workerReducer = (
    state = initialWorkerState,
    action: WorkerActions
) : IWorkerState => {
    switch (action.type) {
        case EWorkerActions.GetWorkersSuccess: {
            return {
                ...state,
                loadResult: action.payload
            }
        }
        case EWorkerActions.GetWorkerSuccess: {
            return {
                ...state,
                selectedWorker: action.payload
            }
        }
        case EWorkerActions.CreateWorkerSuccess: {
            state.loadResult!.data.push(action.payload);

            return {
                ...state,
                loadResult: state.loadResult
            }
        }
        case EWorkerActions.UpdateWorkerSuccess: {
            let workerIndex = state.loadResult!.data.indexOf(state.loadResult?.data.filter(worker => worker.id == action.payload.id)[0]!);

            state.loadResult!.data[workerIndex] = action.payload;

            return {
                ...state,
                loadResult: state.loadResult
            }
        }
        case EWorkerActions.DeleteWorker: {
            let workers = state.loadResult!.data.filter(worker => worker.id != action.payload);
            let loadResult: LoadResult<Worker> = {
                data: workers,
                totalCount: workers.length
            };
            return {
                ...state,
                loadResult: loadResult
            }
        }
        default: {
            return state;
        }
    }
}