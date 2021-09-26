import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Localidad } from '../models/localidades.model';

  // = 'https://localhost:44345/api/localidad/';

@Injectable({
  providedIn: 'root'
})
export class LocalidadService {
  urlLocalidad: string;
  List: Localidad[] = [];

  constructor(private http: HttpClient) {
    this.urlLocalidad='https://localhost:44345/api/localidad/'
   }

  getLocalidadPorId(ID_Provincia : number): Observable<Localidad[]> {
    return this.http.get<Localidad[]>(this.urlLocalidad+ID_Provincia)
  }
}
