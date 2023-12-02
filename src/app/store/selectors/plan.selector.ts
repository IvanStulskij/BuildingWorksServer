import { createSelector } from "@ngrx/store";
import { IAppState } from "../states/app.state";
import { IPlanState } from "../states/plan.state";


const selectPlans = (state: IAppState) => state.plans;

export const selectPlanList = createSelector(
    selectPlans,
    (state: IPlanState) => state.plans
);

export const selectPlan = createSelector(
    selectPlans,
    (state: IPlanState) => state.selectedPlan
);