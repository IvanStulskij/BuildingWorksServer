import { LoadResult } from "src/app/types/loader";
import { Plan } from "src/app/types/plans";

export interface IPlanState {
    loadResult: LoadResult<Plan> | null;
    selectedPlan: Plan | null;
}

export const initialPlanState: IPlanState = {
    loadResult: null,
    selectedPlan: null
};
