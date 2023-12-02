import { Injectable } from '@angular/core';
import { Service } from './service';
import { WorkerSalary } from '../types/workers-salaries';
import { HttpClient } from '@angular/common/http';
import { workerSalariesUrl } from '../constants';

@Injectable({
  providedIn: 'root'
})
export class WorkersSalariesService extends Service<WorkerSalary> {

  constructor(private httpClient: HttpClient) {
    super(httpClient, workerSalariesUrl);
  }
}
