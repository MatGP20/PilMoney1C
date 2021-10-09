namespace API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cuenta
    {
        public Cuenta()
        {
        }

        public Cuenta(int iD_Cuenta, string cBU, string cuit_Cuil, int iD_Tipo_Cuenta, int iD_Balance )
        {
          this.ID_Cuenta = iD_Cuenta;
          this.CBU = cBU;
          this.Cuit_Cuil = cuit_Cuil;
          this.ID_Tipo_Cuenta = iD_Tipo_Cuenta;
          this.ID_Balance = iD_Balance;
          
        }

        public int ID_Cuenta { get; set;}
        public string CBU { get; set; }
        public string Cuit_Cuil { get; }
        public int ID_Tipo_Cuenta { get; }
        public int ID_Balance { get; set; }
        
    
        //public virtual Cliente Cliente { get; }
        //public virtual Tipo_Cuenta Tipo_Cuenta { get; }
        //public virtual Movimiento Movimiento { get; set; }
    }
}
