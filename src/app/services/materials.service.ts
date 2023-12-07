import { Injectable } from '@angular/core';
import { Service } from './service';
import { Material, MaterialContract, MaterialProvider } from '../types/material';
import { HttpClient } from '@angular/common/http';
import { contractsUrl, materialsUrl, ordersUrl, providersUrl } from '../constants';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MaterialsService extends Service<Material> {

  constructor(private httpClient: HttpClient) {
    super(httpClient, materialsUrl);
  }

  getByProvider(providerId: string) : Observable<Material[]> {
    const url = `${providersUrl}/${providerId}/materials`;
    
    return this.httpClient.get<Material[]>(url);
  }

  addToProvider(materialProvider: MaterialProvider) : void {
    const url = `${providersUrl}/${materialProvider.providersId}/materials`;

    this.httpClient.post<Material[]>(url, materialProvider).subscribe();
  }

  deleteAtProvider(materialProvider: MaterialProvider) : void {
    const url = `${providersUrl}/${materialProvider.providersId}/materials`;

    this.httpClient.delete(url).subscribe();
  }

  getByOrder(orderId: string) : Observable<Material[]> {
    const url = `${ordersUrl}/${orderId}/materials`;
    
    return this.httpClient.get<Material[]>(url);
  }
}
