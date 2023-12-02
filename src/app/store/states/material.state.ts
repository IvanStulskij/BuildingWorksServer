import { Material } from "src/app/types/material";

export interface IMaterialState {
    materials: Material[];
    selectedMaterial: Material | null;
}

export const initialMaterialState: IMaterialState = {
    materials: [],
    selectedMaterial: null
};
