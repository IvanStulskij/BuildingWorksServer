import { Material } from "src/app/types/material";

export interface IOrderMaterialState{
    materials: Material[];
}

export const initialOrderMaterialState: IOrderMaterialState = {
    materials: [],
};
