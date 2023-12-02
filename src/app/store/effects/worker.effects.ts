import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store, select } from "@ngrx/store";
import { IAppState } from "../states/app.state";
import { catchError, map, of, switchMap, withLatestFrom } from "rxjs";
import { WorkersService } from "src/app/services/workers.service";
import { CreateWorker, CreateWorkerSuccess, DeleteWorker, DeleteWorkerSuccess, EWorkerActions, GetWorker, GetWorkerSuccess, GetWorkers, GetWorkersSuccess, UpdateWorker, UpdateWorkerSuccess } from "../actions/worker.actions";
import { Worker } from "src/app/types/workers";
import { selectWorkerList } from "../selectors/worker.selector";

@Injectable()
export class WorkerEffects {
    createProvider$ = createEffect(() => this.actions$.pipe(
        ofType<CreateWorker>(EWorkerActions.CreateWorker),
        switchMap((createModel) => this.service.create(createModel.payload)),
        switchMap((created: Worker) => of(new CreateWorkerSuccess(created))),
        catchError((err, caught$) => {
            console.log(err['message']);
            
            return caught$;
        })
    ));

    deleteWorker$ = createEffect(() => this.actions$.pipe(
        ofType<DeleteWorker>(EWorkerActions.DeleteWorker),
        map(action => action.payload),
        withLatestFrom(this.store.pipe(select(selectWorkerList))),
        switchMap(([id, workers]) => {
            this.service.delete(id);

            return of(workers);
        }),
        switchMap(() => of(new DeleteWorkerSuccess())),
        catchError((err, caught$) => {
            console.log(err['message']);
            
            return caught$;
        })
    ));

    getWorkers$ = createEffect(() => this.actions$.pipe(
        ofType<GetWorkers>(EWorkerActions.GetWorkers),
        switchMap(() => this.service.getAll()),
        switchMap((workers: Worker[]) => of(new GetWorkersSuccess(workers))),
        catchError((err, caught$) => {
            console.log(err['message']);
            
            return caught$;
        })
    ));

    getWorker$ = createEffect(() => this.actions$.pipe(
        ofType<GetWorker>(EWorkerActions.GetWorker),
        map(action => action.payload),
        switchMap((id) => this.service.getById(id)),
        switchMap((worker: Worker) => of(new GetWorkerSuccess(worker)))
    ));

    updateWorker$ = createEffect(() => this.actions$.pipe(
        ofType<UpdateWorker>(EWorkerActions.UpdateWorker),
        switchMap((updateModel) => this.service.update(updateModel.payload)),
        switchMap((updated: Worker) => of(new UpdateWorkerSuccess(updated))),
        catchError((err, caught$) => {
            console.log(err['message']);
            
            return caught$;
        })
    ));

    constructor(
        private service: WorkersService,
        private actions$: Actions,
        private store: Store<IAppState>
    ) {}
}