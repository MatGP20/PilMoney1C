using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.Models
{
  public class GestorProvincia
  {

    string StrConn = ConfigurationManager.ConnectionStrings["PilMoneyEntities"].ToString();

    public void RegistrarCliente(Provincia nuevo)
    {
      SqlConnection cx = new SqlConnection(StrConn);
      cx.Open();

      SqlCommand cm = cx.CreateCommand();
      cm.CommandText = "INSERT INTO Provincia(Provincia1) VALUES (@Provincia1)";
      cm.Parameters.Add(new SqlParameter("@Provincia1", nuevo.Provincia1));
      
      cm.ExecuteNonQuery();

      cx.Close();
    }

    public void ModificarUsuario(Provincia Pr)
    {
      SqlConnection cx = new SqlConnection(StrConn);
      cx.Open();

      SqlCommand cm = cx.CreateCommand();
      cm.CommandText = "UPDATE Provincia SET provincia1=@Provincia1 WHERE ID_Provincia=@IDProvincia";
      cm.Parameters.Add(new SqlParameter("@IdTipoMoneda", tm.IdTipoMoneda));
      cm.Parameters.Add(new SqlParameter("@Nombre", tm.Nombre));

      cm.ExecuteNonQuery();

      cx.Close();
    }
    public void EliminarTipoMoneda(int idTipoMoneda)
    {
      SqlConnection cx = new SqlConnection(StrConn);
      cx.Open();

      SqlCommand cm = cx.CreateCommand();
      cm.CommandText = "DELETE FROM TipoMonedas WHERE idTipoMoneda=@IdTipoMoneda";
      cm.Parameters.Add(new SqlParameter("@IdTipoMoneda", idTipoMoneda));

      cm.ExecuteNonQuery();

      cx.Close();

    }

    public List<TipoMonedas> ObtenerTipoMoneda()
    {
      List<TipoMonedas> tiposDeMonedas = new List<TipoMonedas>();

      SqlConnection cx = new SqlConnection(StrConn);
      cx.Open();

      SqlCommand cm = cx.CreateCommand();
      cm.CommandText = "SELECT * FROM TipoMonedas";

      SqlDataReader dr = cm.ExecuteReader();
      while (dr.Read())
      {
        int idTipoMoneda = dr.GetInt32(0);
        string nombre = dr.GetString(1);

        TipoMonedas tm = new TipoMonedas(idTipoMoneda, nombre);
        tiposDeMonedas.Add(tm);
      }

      dr.Close();
      cx.Close();

      return tiposDeMonedas;
    }


  }
}
