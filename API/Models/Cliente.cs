namespace API.Models
{
    using System;
    using System.Collections.Generic;
    
    public class Cliente
    {
        public Cliente()
        {            
        }

        public Cliente(string cuit_Cuil, string nombre, string apellido, string password, string mail, int iD_Localidad, string foto_Frontal, string dNI_delante, string dNI_detras, string domicilio)
        {
          Cuit_Cuil = cuit_Cuil;
          Nombre = nombre;
          Apellido = apellido;
          Password = password;
          Mail = mail;
          ID_Localidad = iD_Localidad;
          Foto_Frontal = foto_Frontal;
          DNI_delante = dNI_delante;
          DNI_detras = dNI_detras;
          Domicilio = domicilio;
        }

        public string Cuit_Cuil { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public int ID_Localidad { get; set; }
        public string Foto_Frontal { get; set; }
        public string DNI_delante { get; set; }
        public string DNI_detras { get; set; }
        public string Domicilio { get; set; }
    
        public virtual Localidad Localidad { get; }
        
        public virtual ICollection<Cuenta> Cuentas { get; set; }
    }
}
