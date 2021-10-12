import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cuenta } from '../models/cuenta.model';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class CuentaService {
  urlIDCuenta: string;
  urlIDCuenta2: string;
  
  List: Cuenta[] = [];

  constructor( private http: HttpClient) { 
    this.urlIDCuenta = 'https://localhost:44345/api/Cuenta?iD_Cliente='
    this.urlIDCuenta2 = '&iD_Tipo_Cuenta='
    
  }

  getCuentaPorID( ID_Cliente: number ): Observable<Cuenta[]> {
    return this.http.get<Cuenta[]>(this.urlIDCuenta+ID_Cliente, httpOptions);
  }

  getCuentaPorClyTi(ID_Cliente:number, ID_Tipo_Cuenta:number){
    return this.http.get(this.urlIDCuenta+ID_Cliente+this.urlIDCuenta2+ID_Tipo_Cuenta);
  }

}
