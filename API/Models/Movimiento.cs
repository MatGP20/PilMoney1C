namespace API.Models
{
    using System;
    using System.Collections.Generic;
    
    public class Movimiento
    {
    private int iD_movimiento;
    private string iD_tipo_movimiento;
    private string descripcion;
    private System.DateTime fecha_Hora;
    private decimal monto;
    private int iD_cuenta_origen;
    private int iD_cuenta_final;
        public Movimiento()
        {
            
        }

        public Movimiento(int ID_movimiento, string ID_tipo_Movimiento, string Descripcion, DateTime Fecha_Hora, decimal Monto, int ID_cuenta_origen, int ID_cuenta_final)
        {
          this.iD_movimiento = ID_movimiento;
          this.iD_tipo_movimiento = ID_tipo_Movimiento;
          this.descripcion = Descripcion;
          this.fecha_Hora = Fecha_Hora;
          this.monto = Monto;
          this.iD_cuenta_origen = ID_cuenta_origen;
          this.iD_cuenta_final = ID_cuenta_final;
        }

        public int ID_movimiento { get=>iD_movimiento; set => iD_movimiento=value; }
        public string ID_tipo_Movimiento { get=>iD_tipo_movimiento; set=>iD_tipo_movimiento=value; }
        public string Descripcion { get=>descripcion; set=>descripcion=value; }
        public System.DateTime Fecha_Hora { get=>fecha_Hora; set=>fecha_Hora=value; }
        public decimal Monto { get=>monto; set=>monto=value; }
        public int ID_cuenta_origen { get=>iD_cuenta_origen; set=>iD_cuenta_origen=value; }
        public int ID_cuenta_final { get=>iD_cuenta_final; set=>iD_cuenta_final=value; }
    
        
        public virtual Cuenta Cuentas { get; set; }
        public virtual Tipo_Movimientos Tipo_Movimientos { get; }
    }
}
