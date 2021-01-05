import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from '../api/api.service';

@Injectable({
  providedIn: 'root'
})
export class LibraryService {

  private readonly endpoint = 'book';

  constructor(private http: HttpClient, private apiService: ApiService) { }

  getBooks(): Observable<any> {
    return this.apiService.get(this.endpoint);
  }

  findByTitle(title): Observable<any> {
    return this.apiService.get(`${this.endpoint}/title/${title}`);
  }

  findByAuthor(name): Observable<any> {
    return this.apiService.get(`${this.endpoint}/author/${name}`);
  }

  return(id): Observable<any> {
    return this.apiService.put(`${this.endpoint}/return/${id}`);
  }

  borrow(id): Observable<any> {
    return this.apiService.put(`${this.endpoint}/borrow/${id}`);
  }

}
