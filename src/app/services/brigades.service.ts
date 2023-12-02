import { Injectable } from '@angular/core';
import { Service } from './service';
import { HttpClient } from '@angular/common/http';
import { brigadesUrl } from '../constants';
import { Brigade } from '../types/brigades';

@Injectable({
  providedIn: 'root'
})
export class BrigadesService extends Service<Brigade> {

  constructor(private httpClient: HttpClient) {
    super(httpClient, brigadesUrl);
  }
}
