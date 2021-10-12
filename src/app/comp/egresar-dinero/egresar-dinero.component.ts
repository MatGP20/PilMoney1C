import { Component, OnInit } from '@angular/core';
import {
  Validators,
  FormControl,
  FormBuilder,
  FormGroup,
} from '@angular/forms';
import { Movimiento } from 'src/app/models/movimiento.model';
import { MovimientosService } from 'src/app/servicios/movimientos.service';
import { CuentaService } from '../../servicios/cuenta.service';
@Component({
  selector: 'app-egresar-dinero',
  templateUrl: './egresar-dinero.component.html',
  styleUrls: ['./egresar-dinero.component.css'],
})
export class EgresarDineroComponent implements OnInit {
  transferencia: Movimiento = new Movimiento();
  // formTransferencia: FormGroup = this.formBuilder.group({})
  monto = new FormControl('', [Validators.required]);
  cvu = new FormControl('', [Validators.required]);
  // mail = new FormControl('', [Validators.required]);
  concepto = new FormControl('', [Validators.required]);
  idcuenta: number = 0;
  fechayhora: Date = new Date();

  constructor(private cuentaService: CuentaService, private movimientosService: MovimientosService) {}

  ngOnInit(): void {
    let idcliente = localStorage.getItem('currentUser');
    let user = {
      ID_Cliente : 0
    };
    if (idcliente) {
      user = JSON.parse(idcliente);
      console.log(user);
    }
    this.cuentaService.getCuentaPorClyTi(user.ID_Cliente, 0).subscribe((res: any) => {
      this.idcuenta = res;
      console.log(this.idcuenta);
    });
  }

  onEnviar() {
    this.transferencia.ID_Tipo_Movimiento = 1;
    this.transferencia.Monto = this.monto.value;
    this.transferencia.ID_Cuenta_Final = this.cvu.value;
    this.transferencia.Descripcion = this.concepto.value;
    this.transferencia.ID_Cuenta = this.idcuenta;
    // this.transferencia.Fecha = this.fechayhora;
    console.log(this.transferencia);

    this.movimientosService.postTransferencia(this.transferencia).subscribe((res: any)=>{
      console.log(res);
    });
  }
}
