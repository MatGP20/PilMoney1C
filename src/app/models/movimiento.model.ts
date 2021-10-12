import { Cuenta } from "./cuenta.model";
import { TipoMovimiento } from "./tipoMovimiento.model";

export class Movimiento {
    ID_Movimiento!:number;
    ID_Tipo_Movimiento! : TipoMovimiento;
    Descripcion! : string;
    Fecha! : Date;
    Monto! : number;
    ID_Cuenta_Origen! : number;
    ID_Cuenta_Final! : number;
    ID_Cuenta! : Cuenta;    
}