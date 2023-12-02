import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BuildingObject } from '../types/building-objects';
import { buildingObjectsUrl } from '../constants';
import { Service } from './service';

@Injectable({
  providedIn: 'root'
})

export class BuildingObjectService extends Service<BuildingObject> {

  constructor(private httpClient: HttpClient) {
    super(httpClient, buildingObjectsUrl);
  }
}
