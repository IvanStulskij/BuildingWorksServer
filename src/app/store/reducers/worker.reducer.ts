import { EWorkerActions, WorkerActions } from "../actions/worker.actions";
import { IWorkerState, initialWorkerState } from "../states/worker.state";

export const workerReducer = (
    state = initialWorkerState,
    action: WorkerActions
) : IWorkerState => {
    switch (action.type) {
        case EWorkerActions.GetWorkersSuccess: {
            return {
                ...state,
                workers: action.payload
            }
        }
        case EWorkerActions.GetWorkerSuccess: {
            return {
                ...state,
                selectedWorker: action.payload
            }
        }
        case EWorkerActions.CreateWorkerSuccess: {
            state.workers.push(action.payload);

            return {
                ...state,
                workers: state.workers
            }
        }
        case EWorkerActions.UpdateWorkerSuccess: {
            let workerIndex = state.workers.indexOf(state.workers.filter(worker => worker.id == action.payload.id)[0]);

            state.workers[workerIndex] = action.payload;
            

            return {
                ...state,
                workers: state.workers
            }
        }
        case EWorkerActions.DeleteWorker: {
            let workers = state.workers.filter(worker => worker.id != action.payload);

            return {
                ...state,
                workers: workers
            }
        }
        default: {
            return state;
        }
    }
}