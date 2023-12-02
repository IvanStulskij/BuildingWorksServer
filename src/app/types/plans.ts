export interface Plan {
    id: string;
    startDate: Date;
    completeTime : Date | null;
    isCompleted : boolean;
    cost: number;
    pathToImage: string;
    buildingObjectId: string;
}