namespace API.Models
{
    using System;
    using System.Collections.Generic;
    
    public class Provincia
    {
        
        public Provincia()
        {
            
        }

        public Provincia(int iD_Provincia, string provincia1)
        {
          ID_Provincia = iD_Provincia;
          Provincia1 = provincia1;
        }

        public int ID_Provincia { get; }
        public string Provincia1 { get; }
    
        
        public virtual ICollection<Localidad> Localidads { get; }
    }
}
