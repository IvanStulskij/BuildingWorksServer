import { LoadResult } from "src/app/types/loader";
import { Material } from "src/app/types/material";

export interface IOrderMaterialState{
    materials: LoadResult<Material> | null;
}

export const initialOrderMaterialState: IOrderMaterialState = {
    materials: null,
};
