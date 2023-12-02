import { createSelector } from "@ngrx/store";
import { IAppState } from "../states/app.state";
import { IBuildingObjectState } from "../states/building-objects.state";

const selectBuildingObjects = (state: IAppState) => state.buildingObjects;

export const selectBuildingObjectList = createSelector(
    selectBuildingObjects,
    (state: IBuildingObjectState) => state.buildingObjects
);

export const selectBuildingObject = createSelector(
    selectBuildingObjects,
    (state: IBuildingObjectState) => state.selectedBuildingObject
);