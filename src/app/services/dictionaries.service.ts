import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DictionaryItem } from '../types/common';
import { Observable } from 'rxjs';
import { dictionariesUrl } from '../constants';

@Injectable({
  providedIn: 'root'
})

export class DictionariesService {

  constructor(private httpClient: HttpClient) {
  }

  getBuildingObjectTypes() : Observable<DictionaryItem[]> {
    const url = `${dictionariesUrl}/building-object-types`;
    
    return this.httpClient.get<DictionaryItem[]>(url);
  }
}
