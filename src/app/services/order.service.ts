import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { buildingObjectsUrl, ordersUrl } from '../constants';
import { Observable } from 'rxjs';
import { Order } from '../types/order';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  constructor(private httpClient: HttpClient) {
    
  }

  getOrders(buildingObjectId: string) : Observable<Order[]> {
    const url = `${buildingObjectsUrl}/${buildingObjectId}/orders`;

    return this.httpClient.get<Order[]>(url);
  }

  createOrder(order: Order) : Observable<Order> {
    const url = `${ordersUrl}`;
    
    return this.httpClient.post<Order>(url, order);
  }
}
