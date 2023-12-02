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
                buildingObjects: action.payload
            }
        }
        case EBuildingObjectActions.GetBuildingObjectSuccess: {
            return {
                ...state,
                selectedBuildingObject: action.payload
            }
        }
        case EBuildingObjectActions.CreateBuildingObjectSuccess: {
            state.buildingObjects.push(action.payload);

            return {
                ...state,
                buildingObjects: state.buildingObjects
            }
        }
        case EBuildingObjectActions.UpdateBuildingObjectSuccess: {
            let buildingObjectIndex = state.buildingObjects.indexOf(state.buildingObjects.filter(buildingObject => buildingObject.id == action.payload.id)[0]);

            state.buildingObjects[buildingObjectIndex] = action.payload;
            
            return {
                ...state,
                buildingObjects: state.buildingObjects
            }
        }
        case EBuildingObjectActions.DeleteBuildingObject: {
            let buildingObjects = state.buildingObjects.filter(buildingObject => buildingObject.id != action.payload);

            return {
                ...state,
                buildingObjects: buildingObjects
            }
        }
        default: {
            return state;
        }
    }
}