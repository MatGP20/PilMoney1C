import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Register } from '../interfaces/register.interface';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class RegisterService {
  urlRegister: string = 'https://localhost:44345/api/cliente';

  constructor(private http: HttpClient) {}
postRegister(form: Register){
  return this.http.post(this.urlRegister,form)
}
}

