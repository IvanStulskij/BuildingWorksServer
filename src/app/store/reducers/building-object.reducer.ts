import { EBuildingObjectActions } from "./../actions/building-object.actions";
import { BuildingObjectActions } from "../actions/building-object.actions";
import { IBuildingObjectState, initialBuildingObjectState } from "../states/building-objects.state";

export const buildingObjectReducer = (
    state = initialBuildingObjectState,
    action: BuildingObjectActions
) : IBuildingObjectState => {
    switch (action.type) {
        case EBuildingObjectActions.GetBuildingObjectsSuccess: {
            return {
                ...state,
                loadResult: action.payload
            }
        }
        case EBuildingObjectActions.GetBuildingObjectSuccess: {
            return {
                ...state,
                selectedBuildingObject: action.payload
            }
        }
        case EBuildingObjectActions.CreateBuildingObjectSuccess: {
            state.loadResult!.data.push(action.payload);

            return {
                ...state,
                loadResult: state.loadResult
            }
        }
        case EBuildingObjectActions.UpdateBuildingObjectSuccess: {
            let buildingObjectIndex = state.loadResult!.data.indexOf(state.loadResult!.data.filter(buildingObject => buildingObject.id == action.payload.id)[0]);

            state.loadResult!.data[buildingObjectIndex] = action.payload;
            
            return {
                ...state,
                loadResult: state.loadResult
            }
        }
        case EBuildingObjectActions.DeleteBuildingObject: {
            let buildingObjects = state.loadResult!.data.filter(buildingObject => buildingObject.id != action.payload);
            state.loadResult!.data = buildingObjects;

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