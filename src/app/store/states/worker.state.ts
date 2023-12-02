import { Worker } from "src/app/types/workers";

export interface IWorkerState {
    workers: Worker[];
    selectedWorker: Worker | null;
}

export const initialWorkerState: IWorkerState = {
    workers: [],
    selectedWorker: null
};
