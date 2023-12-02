import { Injectable } from '@angular/core';
import { Service } from './service';
import { workersUrl } from '../constants';
import { HttpClient } from '@angular/common/http';
import { Worker } from '../types/workers';

@Injectable({
  providedIn: 'root'
})

export class WorkersService extends Service<Worker> {

  constructor(private httpClient: HttpClient) {
    super(httpClient, workersUrl);
  }
}
