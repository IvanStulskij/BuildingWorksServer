import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { DictionaryItem } from '../types/common';
import { LoadConditions, LoadResult } from '../types/loader';

export class Service<T> {

  constructor(private http: HttpClient, protected url: string) { }

  getAll(loadConditions: LoadConditions) : Observable<LoadResult<T>> {
    const url = `${this.url}/overview?${this.getLoadConditionsString(loadConditions)}`;

    return this.http.get<LoadResult<T>>(url);
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

  getLoadConditionsString(loadConditions: LoadConditions) : string {
    let filter = "";
    let sorter = "";
    if (loadConditions.filter) {
      let filterIndex = 0;
      loadConditions.filter!.forEach(filterElement => {
        filter += `Filter[${filterIndex}]=${filterElement}`;
        filterIndex++;
        if (filterIndex != loadConditions.filter?.length) {
          filter += '&';
        }
      });
    }
    if (loadConditions.sorter) {
      let sortIndex = 0;
      loadConditions.sorter!.forEach(sorterElement => {
        sorter += `Sorter[${sortIndex}].Field=${sorterElement!.field}&Sorter[${sortIndex}].Order=${sorterElement!.order}`;
        sortIndex++;
        if (sortIndex != loadConditions.sorter?.length) {
          sorter += '&';
        }
      });
    }
    
    if (filter != "") {
      filter += "&";
    }
    if (sorter != "") {
      sorter += "&";
    }
    return `${filter}${sorter}Page=${loadConditions.page}&PageSize=${loadConditions.pageSize}`;
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