export interface Material {
    id: string;
    name: string;
    pricePerOne: number;
    measure: string;
    quantity: number;
}

export interface MaterialContract {
    providerId: string;
    contractsId: string;
    materialsId: string;
}

export interface MaterialProvider {
    providersId: string;
    materialsId: string;
}

export interface OrderMaterialResource {
    id: string;
    quantity: number;
    pricePerOne: number;
}