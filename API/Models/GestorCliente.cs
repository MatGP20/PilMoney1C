using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.Models
{
  public class GestorCliente
  {
    string conection = ConfigurationManager.ConnectionStrings["PilWalletEntities"].ToString();

    public void RegistrarCliente(Cliente nuevo)
    {
      SqlConnection cx = new SqlConnection(conection);
      cx.Open();

      SqlCommand cm = cx.CreateCommand();
      cm.CommandText = "INSERT INTO Cliente (cuit_Cuil, nombre, apellido, password, mail, iD_Localidad, foto_Frontal, dNI_delante, dNI_detras, domicilio) VALUES (@Cuit_Cuil, @Nombre, @Apellido, @Password, @Mail, @ID_Localidad, @Foto_Frontal, @DNI_delante, @DNI_detras, @Domicilio)";
      cm.Parameters.Add(new SqlParameter("@Cuit_Cuil", nuevo.Cuit_Cuil));
      cm.Parameters.Add(new SqlParameter("@Nombre", nuevo.Nombre));
      cm.Parameters.Add(new SqlParameter("@Apellido", nuevo.Apellido));
      cm.Parameters.Add(new SqlParameter("@Password", nuevo.Password));
      cm.Parameters.Add(new SqlParameter("@Mail", nuevo.Mail));
      cm.Parameters.Add(new SqlParameter("@ID_Localidad", nuevo.ID_Localidad));
      cm.Parameters.Add(new SqlParameter("@Foto_Frontal", nuevo.Foto_Frontal));
      cm.Parameters.Add(new SqlParameter("@DNI_delante", nuevo.DNI_delante));
      cm.Parameters.Add(new SqlParameter("@DNI_detras", nuevo.DNI_detras));
      cm.Parameters.Add(new SqlParameter("@Domicilio", nuevo.Domicilio));

      cm.ExecuteNonQuery();

      cx.Close();
    }

    public void ModificarCliente(Cliente c)
    {
      SqlConnection cx = new SqlConnection(conection);
      cx.Open();

      SqlCommand cm = cx.CreateCommand();
      cm.CommandText = "UPDATE Cliente SET domicilio=@Domicilio, nombre=@Nombre, apellido=@Apellido, password=@Password, mail=@Mail WHERE cuit_Cuil = @Cuit_Cuil";
      cm.Parameters.Add(new SqlParameter("@Domicilio", c.Domicilio));
      cm.Parameters.Add(new SqlParameter("@Nombre", c.Nombre));
      cm.Parameters.Add(new SqlParameter("@Apellido", c.Apellido));
      cm.Parameters.Add(new SqlParameter("@Password", c.Password));
      cm.Parameters.Add(new SqlParameter("@Mail", c.Mail));
      cm.Parameters.Add(new SqlParameter("@Cuit_Cuil", c.Cuit_Cuil));

      cm.ExecuteNonQuery();

      cx.Close();
    }
  }
}
