import { Injectable } from '@angular/core';
import { Service } from './service';
import { Plan } from '../types/plans';
import { HttpClient } from '@angular/common/http';
import { plansUrl } from '../constants';

@Injectable({
  providedIn: 'root'
})
export class PlansService extends Service<Plan> {

  constructor(private httpClient: HttpClient) {
    super(httpClient, plansUrl);
  }
}
