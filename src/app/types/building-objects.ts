export interface BuildingObject {
    id: string;
    objectName: string;
    buildingObjectType: number;
    buildingObjectTypeName: string;
    objectCustomer: string;
    executorCompany: string;
}

export interface BuildingObjectProvider {
    providersId: string;
    buildingObjectsId: string;
}