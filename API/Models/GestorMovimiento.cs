using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.Models
{
  public class GestorMovimiento
  {
    string conection = ConfigurationManager.ConnectionStrings["PilWalletEntities"].ToString();

    public List<Movimiento> Obtener10MovimientoPorCuenta (int ID_Cuenta)
    {
      var listaMovimiento = new List<Movimiento>();

      SqlConnection cx = new SqlConnection(conection);
      cx.Open();

      SqlCommand cm = cx.CreateCommand();
      cm.CommandText = "SELECT TOP 10 FROM Movimientos WHERE ID_Cuenta = @iD_Cuenta";
      cm.Parameters.Add(new SqlParameter("@iD_Cuenta", ID_Cuenta));

      SqlDataReader dr = cm.ExecuteReader();

      while (dr.Read())
      {
        int ID_movimiento = dr.GetInt32(0);
        string ID_tipo_Movimiento = dr.GetString(1).Trim();
        string Descripcion = dr.GetString(2).Trim();
        DateTime Fecha_Hora = dr.GetDateTime(3);
        decimal Monto = dr.GetInt32(4);
        int ID_cuenta_origen = dr.GetInt32(5);
        int ID_cuenta_final = dr.GetInt32(6);
        

        Movimiento mov = new Movimiento(ID_movimiento, ID_tipo_Movimiento, Descripcion, Fecha_Hora,Monto, ID_cuenta_origen, ID_cuenta_final, ID_Cuenta);
        listaMovimiento.Add(mov);
      }

      dr.Close();
      cx.Close();

      return listaMovimiento;
    }

    public List<Movimiento> ObtenerMovimientoPorCuenta(int ID_Cuenta)
    {
      var listaMovimiento = new List<Movimiento>();

      SqlConnection cx = new SqlConnection(conection);
      cx.Open();

      SqlCommand cm = cx.CreateCommand();
      cm.CommandText = "SELECT * FROM Movimientos WHERE ID_Cuenta = @iD_Cuenta";
      cm.Parameters.Add(new SqlParameter("@iD_Cuenta", ID_Cuenta));

      SqlDataReader dr = cm.ExecuteReader();

      while (dr.Read())
      {
        int ID_movimiento = dr.GetInt32(0);
        string ID_tipo_Movimiento = dr.GetString(1).Trim();
        string Descripcion = dr.GetString(2).Trim();
        DateTime Fecha_Hora = dr.GetDateTime(3);
        decimal Monto = dr.GetInt32(4);
        int ID_cuenta_origen = dr.GetInt32(5);
        int ID_cuenta_final = dr.GetInt32(6);


        Movimiento mov = new Movimiento(ID_movimiento, ID_tipo_Movimiento, Descripcion, Fecha_Hora, Monto, ID_cuenta_origen, ID_cuenta_final, ID_Cuenta);
        listaMovimiento.Add(mov);
      }

      dr.Close();
      cx.Close();

      return listaMovimiento;
    }

  }
}
