namespace API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cuenta
    {
        public Cuenta()
        {
        }

        public Cuenta(int iD_Cuenta, int cuit_Cuil, int iD_Tipo_Cuenta, int iD_movimiento)
        {
          ID_Cuenta = iD_Cuenta;
          Cuit_Cuil = cuit_Cuil;
          ID_Tipo_Cuenta = iD_Tipo_Cuenta;
          ID_movimiento = iD_movimiento;
        }

        public int ID_Cuenta { get; set;}
        public int Cuit_Cuil { get; }
        public int ID_Tipo_Cuenta { get; }
        public int ID_movimiento { get; }
    
        public virtual Cliente Cliente { get; }
        public virtual Tipo_Cuenta Tipo_Cuenta { get; }
        public virtual Movimiento Movimiento { get; set; }
    }
}
