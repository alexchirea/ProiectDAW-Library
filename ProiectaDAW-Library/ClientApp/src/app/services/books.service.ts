import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

const baseUrl = 'https://localhost:5001/api/book';
@Injectable({
  providedIn: 'root'
})
export class BooksService {

  constructor(private http: HttpClient) { }

  getAll(): Observable<any> {
    return this.http.get(baseUrl);
  }

  get(id): Observable<any> {
    return this.http.get(`${baseUrl}/id/${id}`);
  }

  create(data): Observable<any> {
    return this.http.post(baseUrl, data);
  }

  update(id, data): Observable<any> {
    return this.http.put(`${baseUrl}/id/${id}`, data);
  }

  findByTitle(name): Observable<any> {
    return this.http.get(`${baseUrl}/name/${name}`);
  }

  findByAuthor(name): Observable<any> {
    return this.http.get(`${baseUrl}/author/${name}`);
  }

  delete(id): Observable<any> {
    return this.http.delete(`${baseUrl}/id/${id}`);
  }

}
