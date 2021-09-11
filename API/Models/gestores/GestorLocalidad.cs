using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.Models
{
  public class GestorLocalidad
  {
    string conection = ConfigurationManager.ConnectionStrings["PilWalletEntities"].ToString();

    public List<Localidad> ObtenerLocalidad()
    {
      List<Localidad> listaLocalidades = new List<Localidad>();

      SqlConnection cx = new SqlConnection(conection);
      cx.Open();

      SqlCommand cm = cx.CreateCommand();
      cm.CommandText = "SELECT * FROM Localidad";

      SqlDataReader dr = cm.ExecuteReader();

      while (dr.Read())
      {
        int ID_Localidad = dr.GetInt16(0);
        string Localidad1 = dr.GetString(1).Trim();
        int Codigo_Postal = dr.GetInt16(2);
        int ID_Provincia = dr.GetInt16(3);

        Localidad Local = new Localidad(ID_Localidad, Localidad1, Codigo_Postal, ID_Provincia);
        listaLocalidades.Add(Local);
      }

      dr.Close();
      cx.Close();

      return listaLocalidades;
    }
  }
}
