import { LoadResult } from "src/app/types/loader";
import { Material } from "src/app/types/material";

export interface IProviderMaterialState {
    providerMaterials: LoadResult<Material> | null;
    selectedMaterial: Material | null;
}

export const initialProviderMaterialState: IProviderMaterialState = {
    providerMaterials: null,
    selectedMaterial: null
};
