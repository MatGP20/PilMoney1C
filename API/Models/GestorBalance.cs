using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.Models
{
  public class GestorBalance
  {
    string conection = ConfigurationManager.ConnectionStrings["PilWalletEntities"].ToString();

    public void CrearBalance(Balance nuevoBalance)
    {
      SqlConnection cx = new SqlConnection(conection);
      cx.Open();

      SqlCommand cm = cx.CreateCommand();
      cm.CommandText = "INSERT INTO Balance (iD_Cuenta, iD_Tipo_Cuenta, balance1) VALUES (@ID_Cuenta, @ID_Tipo_Cuenta, @Balance1)";
      cm.Parameters.Add(new SqlParameter("@ID_Cuenta", nuevoBalance.ID_Cuenta));
      cm.Parameters.Add(new SqlParameter("@ID_Tipo_Cuenta", nuevoBalance.ID_Tipo_Cuenta));
      cm.Parameters.Add(new SqlParameter("@Balance1", nuevoBalance.Balance1));
      

      cm.ExecuteNonQuery();

      cx.Close();
    }

    public int obtenerBalanceID(int iD_Cuenta, int iD_Tipo_Cuenta)
    {
      int iDBuscado = 0;
      SqlConnection cx = new SqlConnection(conection);
      cx.Open();

      SqlCommand cm = cx.CreateCommand();
      cm.CommandText = "SELECT ID_Balance FROM Balance WHERE ID_Cuenta = @iD_Cuenta AND ID_Tipo_Cuenta = @iD_Tipo_Cuenta";
      cm.Parameters.Add(new SqlParameter("@iD_Cliente", iD_Cuenta));
      cm.Parameters.Add(new SqlParameter("@iD_Tipo_Cuenta", iD_Tipo_Cuenta));

      SqlDataReader dr = cm.ExecuteReader();
      if (dr.Read())
      {
        int iD_Balance = dr.GetInt32(0);

        iDBuscado = iD_Balance;
      }
      dr.Close();
      cx.Close();

      return iDBuscado;
    }


    public List<Balance> ObtenerBalancesPorId(int iD_Cuenta)
    {
      List<Balance> listaBalancesPorCuenta = new List<Balance>();

      SqlConnection cx = new SqlConnection(conection);
      cx.Open();

      SqlCommand cm = cx.CreateCommand();
      cm.CommandText = "SELECT * FROM Balance WHERE iD_Cuenta = @ID_Cuenta";
      cm.Parameters.Add(new SqlParameter("@ID_Cuenta", iD_Cuenta));

      SqlDataReader dr = cm.ExecuteReader();

      while (dr.Read())
      {
        int ID_Tipo_Cuenta = dr.GetInt32(1);
        int Balance = dr.GetInt32(2);


        Balance cBalance = new Balance(ID_Tipo_Cuenta, Balance, iD_Cuenta);
        listaBalancesPorCuenta.Add(cBalance);
      }

      dr.Close();
      cx.Close();

      return listaBalancesPorCuenta;
    }

  }
}
