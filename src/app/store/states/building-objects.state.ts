import { BuildingObject } from "src/app/types/building-objects";

export interface IBuildingObjectState{
    buildingObjects: BuildingObject[];
    selectedBuildingObject: BuildingObject | null;
}

export const initialBuildingObjectState: IBuildingObjectState = {
    buildingObjects: [],
    selectedBuildingObject: null
};
