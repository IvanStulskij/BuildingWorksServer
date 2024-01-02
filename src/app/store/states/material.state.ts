import { LoadResult } from "src/app/types/loader";
import { Material } from "src/app/types/material";

export interface IMaterialState {
    loadResult: LoadResult<Material> | null;
    selectedMaterial: Material | null;
}

export const initialMaterialState: IMaterialState = {
    loadResult: null,
    selectedMaterial: null
};
