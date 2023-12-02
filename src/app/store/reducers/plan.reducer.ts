import { EPlanActions, PlanActions } from "../actions/plan.actions";
import { IPlanState, initialPlanState } from "../states/plan.state";

export const planReducer = (
    state = initialPlanState,
    action: PlanActions
) : IPlanState => {
    switch (action.type) {
        case EPlanActions.GetPlansSuccess: {
            return {
                ...state,
                plans: action.payload
            }
        }
        case EPlanActions.GetPlanSuccess: {
            return {
                ...state,
                selectedPlan: action.payload
            }
        }
        case EPlanActions.CreatePlanSuccess: {
            state.plans.push(action.payload);

            return {
                ...state,
                plans: state.plans
            }
        }
        case EPlanActions.UpdatePlanSuccess: {
            let planIndex = state.plans.indexOf(state.plans.filter(plan => plan.id == action.payload.id)[0]);
            
            state.plans[planIndex] = action.payload;
            

            return {
                ...state,
                plans: state.plans
            }
        }
        case EPlanActions.DeletePlan: {
            let plans = state.plans.filter(plan => plan.id != action.payload);

            return {
                ...state,
                plans: plans
            }
        }
        default: {
            return state;
        }
    }
}