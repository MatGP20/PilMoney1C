using API.Models;
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

    string conection = ConfigurationManager.ConnectionStrings["PilWalletEntities"].ToString();

    /*
    public List<Provincia> ObtenerProvincia()
    {
      List<Provincia> listaProvincias = new List<Provincia>();

      SqlConnection cx = new SqlConnection(conection);
      cx.Open();

      SqlCommand cm = cx.CreateCommand();
      cm.CommandText = "SELECT * FROM Provincia";

      SqlDataReader dr = cm.ExecuteReader();
      
      while (dr.Read())
      {
        int ID_Provincia = dr.GetInt32(0);
        string Provincia1 = dr.GetString(1).Trim();

        Provincia prov = new Provincia(ID_Provincia, Provincia1);
        listaProvincias.Add(prov);
      }

      dr.Close();
      cx.Close();

      return listaProvincias;
    }
    */

  }
}
