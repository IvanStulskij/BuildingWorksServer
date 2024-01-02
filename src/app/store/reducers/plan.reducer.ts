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
                loadResult: action.payload
            }
        }
        case EPlanActions.GetPlanSuccess: {
            return {
                ...state,
                selectedPlan: action.payload
            }
        }
        case EPlanActions.CreatePlanSuccess: {
            state.loadResult?.data.push(action.payload);

            return {
                ...state,
                loadResult: state.loadResult
            }
        }
        case EPlanActions.UpdatePlanSuccess: {
            let planIndex = state.loadResult?.data.indexOf(state.loadResult.data.filter(plan => plan.id == action.payload.id)[0]);
            
            state.loadResult!.data[planIndex!] = action.payload;

            return {
                ...state,
                loadResult: state.loadResult
            }
        }
        case EPlanActions.DeletePlan: {
            let plans = state.loadResult?.data.filter(plan => plan.id != action.payload);
            state.loadResult!.data = plans!;

            return {
                ...state,
                loadResult: state.loadResult
            }
        }
        default: {
            return state;
        }
    }
}