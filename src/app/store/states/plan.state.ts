import { Plan } from "src/app/types/plans";

export interface IPlanState {
    plans: Plan[];
    selectedPlan: Plan | null;
}

export const initialPlanState: IPlanState = {
    plans: [],
    selectedPlan: null
};
