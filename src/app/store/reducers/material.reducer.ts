import { EMaterialActions, MaterialActions } from "../actions/material.actions";
import { IMaterialState, initialMaterialState } from "../states/material.state";

export const materialReducer = (
    state = initialMaterialState,
    action: MaterialActions,
) : IMaterialState => {
    switch (action.type) {
        case EMaterialActions.GetMaterialsSuccess: {
            return {
                ...state,
                materials: action.payload
            }
        }
        case EMaterialActions.GetMaterialSuccess: {
            return {
                ...state,
                selectedMaterial: action.payload
            }
        }
        case EMaterialActions.CreateMaterialSuccess: {
            let materials = state.materials;
            materials.push(action.payload);

            return {
                ...state,
                materials: materials
            }
        }
        case EMaterialActions.UpdateMaterialSuccess: {
            let materialIndex = state.materials.indexOf(state.materials.filter(material => material.id == action.payload.id)[0]);
            state.materials[materialIndex] = action.payload;
            
            return {
                ...state,
                materials: state.materials
            }
        }
        case EMaterialActions.DeleteMaterialSuccess: {
            return {
                ...state,
                materials: state.materials
            }
        }
        default: {
            return state;
        }
    }
}