import { Material } from "src/app/types/material";

export interface IProviderMaterialState {
    providerMaterials: Material[];
    selectedMaterial: Material | null;
}

export const initialProviderMaterialState: IProviderMaterialState = {
    providerMaterials: [],
    selectedMaterial: null
};
