import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { IngresarDineroComponent } from './ingresar-dinero/ingresar-dinero.component';
import { EgresarDineroComponent } from './egresar-dinero/egresar-dinero.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    IngresarDineroComponent,
    EgresarDineroComponent,
    LoginComponent,
    RegisterComponent

  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule    
  ],

  exports: [
    IngresarDineroComponent,
    EgresarDineroComponent,
    LoginComponent,
    RegisterComponent
  ]
})
export class CompModule { }
