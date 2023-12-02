import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { DictionaryItem } from '../types/common';

export class Service<T> {

  constructor(private http: HttpClient, protected url: string) { }

  getAll() : Observable<T[]> {
    const url = `${this.url}/overview`;
    
    return this.http.get<T[]>(url);
  }

  getById(id: string) : Observable<T> {
    const url = `${this.url}/${id}`;

    return this.http.get<T>(url);
  }

  create(entity: T) : Observable<T> {
    var created = this.http.post<T>(this.url, entity);

    return created;
  }

  update(entity: T) : Observable<T> {
    var updated = this.http.put<T>(this.url, entity);

    return updated;
  }

  delete(id: string) : void {
    const url = `${this.url}/${id}`;
    
    this.http.delete(url).subscribe();
  }
}

export class ShortInfoService<T> extends Service<T> {
  constructor(private httpClient: HttpClient, protected override url: string) {
    super(httpClient, url);
  }

  getShortInfos() : Observable<DictionaryItem[]> {
    const url = `${this.url}/short-infos`;

    return this.httpClient.get<DictionaryItem[]>(url);
  }
}