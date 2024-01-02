import { LoadResult } from "src/app/types/loader";
import { Worker } from "src/app/types/workers";

export interface IWorkerState {
    loadResult: LoadResult<Worker> | null;
    selectedWorker: Worker | null;
}

export const initialWorkerState: IWorkerState = {
    loadResult: null,
    selectedWorker: null
};
