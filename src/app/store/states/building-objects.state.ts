import { BuildingObject } from "src/app/types/building-objects";
import { LoadResult } from "src/app/types/loader";

export interface IBuildingObjectState{
    loadResult: LoadResult<BuildingObject> | null;
    selectedBuildingObject: BuildingObject | null;
}

export const initialBuildingObjectState: IBuildingObjectState = {
    loadResult: null,
    selectedBuildingObject: null
};
