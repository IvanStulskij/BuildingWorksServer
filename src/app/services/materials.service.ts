import { Injectable } from '@angular/core';
import { Service } from './service';
import { Material, MaterialContract, MaterialProvider } from '../types/material';
import { HttpClient } from '@angular/common/http';
import { contractsUrl, materialsUrl, providersUrl } from '../constants';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MaterialsService extends Service<Material> {

  constructor(private httpClient: HttpClient) {
    super(httpClient, materialsUrl);
  }

  getByContract(contractId: string, providerId: string) : Observable<Material[]> {
    const url = `${contractsUrl}/${contractId}/providers/${providerId}/materials`;
    
    return this.httpClient.get<Material[]>(url);
  }

  addToContract(materialContract: MaterialContract) : void {
    const url = `${contractsUrl}/${materialContract.contractsId}/materials`;

    this.httpClient.post<Material[]>(url, materialContract).subscribe();
  }

  deleteAtContract(materialContract: MaterialContract) : void {
    const url = `${contractsUrl}/${materialContract.contractsId}/materials`;

    this.httpClient.delete(url).subscribe();
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
}
