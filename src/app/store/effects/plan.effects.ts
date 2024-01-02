import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store, select } from "@ngrx/store";
import { PlansService } from "src/app/services/plans.service";
import { IAppState } from "../states/app.state";
import { CreatePlan, CreatePlanSuccess, DeletePlan, DeletePlanSuccess, EPlanActions, GetPlan, GetPlanSuccess, GetPlans, GetPlansSuccess, UpdatePlan, UpdatePlanSuccess } from "../actions/plan.actions";
import { catchError, map, of, switchMap, withLatestFrom } from "rxjs";
import { Plan } from "src/app/types/plans";
import { selectPlanList } from "../selectors/plan.selector";
import { LoadResult } from "src/app/types/loader";

@Injectable()
export class PlanEffects {
    createPlan$ = createEffect(() => this.actions$.pipe(
        ofType<CreatePlan>(EPlanActions.CreatePlan),
        switchMap((createModel) => this.service.create(createModel.payload)),
        switchMap((created: Plan) => of(new CreatePlanSuccess(created))),
        catchError((err, caught$) => {
            console.log(err['message']);
            
            return caught$;
        })
    ));

    deletePlan$ = createEffect(() => this.actions$.pipe(
        ofType<DeletePlan>(EPlanActions.DeletePlan),
        map(action => action.payload),
        withLatestFrom(this.store.pipe(select(selectPlanList))),
        switchMap(([id, buildingObjects]) => {
            this.service.delete(id);

            return of(buildingObjects);
        }),
        switchMap(() => of(new DeletePlanSuccess())),
        catchError((err, caught$) => {
            console.log(err['message']);
            
            return caught$;
        })
    ));

    getPlans$ = createEffect(() => this.actions$.pipe(
        ofType<GetPlans>(EPlanActions.GetPlans),
        map(action => action.payload),
        switchMap((loadConditions) => this.service.getAll(loadConditions)),
        switchMap((loadResult: LoadResult<Plan>) => of(new GetPlansSuccess(loadResult))),
        catchError((err, caught$) => {
            console.log(err['message']);
            
            return caught$;
        })
    ));

    getPlan$ = createEffect(() => this.actions$.pipe(
        ofType<GetPlan>(EPlanActions.GetPlan),
        map(action => action.payload),
        switchMap((id) => this.service.getById(id)),
        switchMap((plan: Plan) => of(new GetPlanSuccess(plan)))
    ));

    updatePlan$ = createEffect(() => this.actions$.pipe(
        ofType<UpdatePlan>(EPlanActions.UpdatePlan),
        switchMap((updateModel) => this.service.update(updateModel.payload)),
        switchMap((updated: Plan) => of(new UpdatePlanSuccess(updated))),
        catchError((err, caught$) => {
            console.log(err['message']);
            
            return caught$;
        })
    ));

    constructor(
        private service: PlansService,
        private actions$: Actions,
        private store: Store<IAppState>
    ) {}
}