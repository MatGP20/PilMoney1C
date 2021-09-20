import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Provincia } from '../interfaces/provincia.interface';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class ProvinciaService {
  urlProvincia: string = 'https://localhost:44345/api/provincia';
  constructor(private http: HttpClient) {}
  getProvincia(): Observable<Provincia> {
    return this.http.get<Provincia>(this.urlProvincia);
  }
}
