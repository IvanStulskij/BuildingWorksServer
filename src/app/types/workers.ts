export interface Worker {
    id: string;
    firstName: string;
    lastName: string;
    middleName: string;
    startWorkDate: Date;
    post: string;
    brigadierBrigadeId: string | null;
    brigadeId: string;
}