import { Material } from "./material";


export interface Order {
    id: string;
    orderId: string;
    cost: number;
    factDeliveredAt: Date;
    plannedDeliveredAt: Date;
    startDeliverAt: Date;
    providerName: string;
    providerId: string;
    buildingObjectId: string;
    materials: Material[]
}

export interface OrderStatusInfo {
    id: string;
    statusId: number;
    status: string;
}