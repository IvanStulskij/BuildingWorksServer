import { Action } from "@ngrx/store";
import { LoadConditions, LoadResult } from "src/app/types/loader";
import { Plan } from "src/app/types/plans";

export enum EPlanActions {
    GetPlans = '[Plan] Get Plans',
    GetPlansSuccess = '[Plan] Get Plans Success',
    GetPlansFail = '[Plan] Get Plan Fail',

    GetPlan = '[Plan] Get Plan',
    GetPlanSuccess = '[Plan] Get Plan Success',
    GetPlanFail = '[Plan] Get Plan Fail',

    CreatePlan = '[Plan] Create Plan',
    CreatePlanSuccess = '[Plan] Create Plan Success',
    CreatePlanFail = '[Plan] Create Plan Fail',

    DeletePlan = '[Plan] Delete Plan',
    DeletePlanSuccess = '[Plan] Delete Plan Success',
    DeletePlanFail = '[Plan] Delete Plan Fail',

    UpdatePlan = '[Plan] Update Plan',
    UpdatePlanSuccess = '[Plan] Update Plan Success',
    UpdatePlanFail = '[Plan] Update Plan Fail',
}

export class GetPlans implements Action {
    public readonly type = EPlanActions.GetPlans;
    constructor(public payload: LoadConditions) {}
}

export class GetPlansSuccess implements Action {
    public readonly type = EPlanActions.GetPlansSuccess;
    constructor(public payload: LoadResult<Plan>) {}
}

export class GetPlan implements Action {
    public readonly type = EPlanActions.GetPlan;
    constructor(public payload: string) {}
}

export class GetPlanSuccess implements Action {
    public readonly type = EPlanActions.GetPlanSuccess;
    constructor(public payload: Plan) {}
}

export class CreatePlan implements Action {
    public readonly type = EPlanActions.CreatePlan;
    constructor(public payload: Plan) {}
}

export class CreatePlanSuccess implements Action {
    public readonly type = EPlanActions.CreatePlanSuccess;
    constructor(public payload: Plan) {}
}

export class DeletePlan implements Action {
    public readonly type = EPlanActions.DeletePlan;
    constructor(public payload: string) {}
}

export class DeletePlanSuccess implements Action {
    public readonly type = EPlanActions.DeletePlanSuccess;
}

export class UpdatePlan implements Action {
    public readonly type = EPlanActions.UpdatePlan;
    constructor(public payload: Plan) {}
}

export class UpdatePlanSuccess implements Action {
    public readonly type = EPlanActions.UpdatePlanSuccess;
    constructor(public payload: Plan) {}
}

export type PlanActions = GetPlans | GetPlansSuccess | GetPlan | GetPlanSuccess | CreatePlan | CreatePlanSuccess | DeletePlan | DeletePlanSuccess | UpdatePlan | UpdatePlanSuccess;  