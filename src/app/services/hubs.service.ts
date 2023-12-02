import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { Observable, Subject } from 'rxjs';
import { OrderStatusInfo } from '../types/order';

@Injectable({
  providedIn: 'root'
})
export class SignalrService {
    private hubConnection!: HubConnection;

    constructor() { }

    public startConnection() {
        return new Promise((resolve, reject) => {
            this.hubConnection = new HubConnectionBuilder()
                                .withUrl("http://localhost:5196/orders/submit-status")
                                .build();
            
            this.hubConnection.start()
            .then(() => {
                console.log("connection established");
                return resolve(true);
            })
            .catch((err: any) => {
                console.log("error occured" + err);
                reject(err);
            });
        });
    }

    public listenToOrderStatusReceive() : void {
        this.hubConnection.on("ReceiveOrderStatus", (data: OrderStatusInfo) => {
            console.log("Order status received");
        });
    } 
}