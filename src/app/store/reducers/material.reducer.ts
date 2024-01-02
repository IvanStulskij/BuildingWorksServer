import { LoadResult } from "src/app/types/loader";
import { EMaterialActions, MaterialActions } from "../actions/material.actions";
import { IMaterialState, initialMaterialState } from "../states/material.state";
import { Material } from "src/app/types/material";

export const materialReducer = (
    state = initialMaterialState,
    action: MaterialActions,
) : IMaterialState => {
    switch (action.type) {
        case EMaterialActions.GetMaterialsSuccess: {
            return {
                ...state,
                loadResult: action.payload
            }
        }
        case EMaterialActions.GetMaterialSuccess: {
            return {
                ...state,
                selectedMaterial: action.payload
            }
        }
        case EMaterialActions.CreateMaterialSuccess: {
            let materials = state.loadResult!.data;
            materials.push(action.payload);
            let loadResult: LoadResult<Material> = {
                data: materials,
                totalCount: materials.length
            };
            return {
                ...state,
                loadResult: loadResult
            }
        }
        case EMaterialActions.UpdateMaterialSuccess: {
            let materialIndex = state.loadResult?.data.indexOf(state.loadResult.data.filter(material => material.id == action.payload.id)[0]);
            //state.loadResult?.data[materialIndex] = action.payload;
            
            return {
                ...state,
                loadResult: state.loadResult
            }
        }
        case EMaterialActions.DeleteMaterialSuccess: {
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