import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Service } from './service';
import { Provider } from '../types/providers';
import { buildingObjectsUrl, contractsUrl, providersUrl } from '../constants';
import { Observable } from 'rxjs';
import { DictionaryItem } from '../types/common';
import { BuildingObjectProvider } from '../types/building-objects';

@Injectable({
  providedIn: 'root'
})
export class ProvidersService extends Service<Provider> {

  constructor(private httpClient: HttpClient) {
    super(httpClient, providersUrl);
  }

  getProvidersByBuildingObject(buildingObjectId: string) : Observable<Provider[]> {
    const url = `${buildingObjectsUrl}/${buildingObjectId}/providers`;

    return this.httpClient.get<Provider[]>(url);
  }

  getProvidersShortInfosByBuildingObject(buildingObjectId: string) : Observable<DictionaryItem[]> {
    const url = `${buildingObjectsUrl}/${buildingObjectId}/providers/short-infos`;

    return this.httpClient.get<DictionaryItem[]>(url);
  }

  addProviderToBuildingObject(buildingObjectProvider: BuildingObjectProvider) : void {
    const url = `${buildingObjectsUrl}/${buildingObjectProvider.buildingObjectsId}/providers`;
    const params = new HttpParams()
                    .set('providerId', buildingObjectProvider.providersId);

    this.httpClient.post(url, null, { params }).subscribe();
  }

  getProvidersByContract(contractId: string) : Observable<Provider[]> {
    const url = `${contractsUrl}/${contractId}/providers`;

    return this.httpClient.get<Provider[]>(url);
  }

  getShortInfos() : Observable<DictionaryItem[]> {
    const url = `${this.url}/short-infos`;
    
    return this.httpClient.get<Provider[]>(url);
  }
}
