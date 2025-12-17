import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class PostServicesService {
  apiUrl = 'http://localhost:5276/api/Post';

  constructor(private http: HttpClient) {}

  getComment(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/GetComment`);
  }

  postComment(data: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/PostComment`, data);
  }
}
