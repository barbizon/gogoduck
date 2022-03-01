import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable()
export class DuckDuckGoService {
  environment = environment;  
  
  constructor(private http: HttpClient) { }

  search(query: string, page: number, pageSize: number) {
    return this.http.get<any>(this.environment.serviceUrl + '?q=' + query + '&page=' + page + '&pageSize=' + pageSize);
  }
  history() {
    return this.http.get<any>(this.environment.serviceUrl + '/history');
  }
}