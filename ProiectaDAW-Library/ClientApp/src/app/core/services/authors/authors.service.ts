import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiService } from '../api/api.service';
@Injectable({
  providedIn: 'root'
})
export class AuthorsService {

  private readonly endpoint = 'author';

  constructor(private http: HttpClient, private apiService: ApiService) { }

  getAll(): Observable<any> {
    return this.apiService.get(this.endpoint);
  }

  get(id): Observable<any> {
    return this.apiService.get(`${this.endpoint}/id/${id}`);
  }

  create(data): Observable<any> {
    return this.apiService.post(this.endpoint, data);
  }

  update(id, data): Observable<any> {
    return this.apiService.put(`${this.endpoint}/id/${id}`, data);
  }

  findByName(name): Observable<any> {
    return this.apiService.get(`${this.endpoint}/name/${name}`);
  }

  delete(id): Observable<any> {
    return this.apiService.delete(`${this.endpoint}/id/${id}`);
  }

}
