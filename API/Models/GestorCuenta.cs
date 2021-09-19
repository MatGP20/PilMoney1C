using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.Models
{
  public class GestorCuenta
  {
    string conection = ConfigurationManager.ConnectionStrings["PilWalletEntities"].ToString();

    public void CrearCuenta(Cuenta nueva)
    {
      SqlConnection cx = new SqlConnection(conection);
      cx.Open();

      SqlCommand cm = cx.CreateCommand();
      cm.CommandText = "INSERT INTO Cuenta(iD_Cuenta, cuit_Cuil, iD_Tipo_Cuenta, iD_movimiento) VALUES (@ID_Cuenta, @Cuit_Cuil, @ID_Tipo_Cuenta, @ID_movimiento)";
      cm.Parameters.Add(new SqlParameter("@ID_Cuenta", nueva.ID_Cuenta));
      cm.Parameters.Add(new SqlParameter("@Cuit_Cuil", nueva.Cuit_Cuil));
      cm.Parameters.Add(new SqlParameter("@ID_Tipo_Cuenta", nueva.ID_Tipo_Cuenta));
      cm.Parameters.Add(new SqlParameter("@ID_movimiento", nueva.ID_movimiento));
      

      cm.ExecuteNonQuery();

      cx.Close();
    }

    public List<Cuenta> ListarCuenta(int Cuil_Cuit)
    {
      List<Cuenta> listaCuenta = new List<Cuenta>();

      SqlConnection cx = new SqlConnection(conection);
      cx.Open();

      SqlCommand cm = cx.CreateCommand();
      cm.CommandText = "SELECT * FROM Cuenta WHERE Cuit_Cuil = @cuit_Cuil";
      cm.Parameters.Add(new SqlParameter("@cuit_Cuil", Cuil_Cuit));

      SqlDataReader dr = cm.ExecuteReader();
      while (dr.Read())
      {
        int ID_Cuenta = dr.GetInt32(0);
        int Cuit_Cuil = dr.GetInt32(1);
        int ID_Tipo_Cuenta = dr.GetInt32(2);
        int ID_movimiento = dr.GetInt32(3);


        Cuenta c = new Cuenta(ID_Cuenta, Cuit_Cuil, ID_Tipo_Cuenta, ID_movimiento);
        listaCuenta.Add(c);
      }

      dr.Close();
      cx.Close();

      return listaCuenta;
    }
  }
}
