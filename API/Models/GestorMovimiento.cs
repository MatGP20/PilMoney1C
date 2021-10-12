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

    public int Transferencia(Movimiento transferencia)
    {

      decimal balance = 0;
      decimal monto = transferencia.Monto;
      decimal nuevobalance = balance - monto;
      int transferenciaExito;

      if (nuevobalance >= 0)
      {
        SqlConnection cx = new SqlConnection(conection);
        cx.Open();

        SqlCommand cm = cx.CreateCommand();
        cm.CommandText = "INSERT TO Movimientos (iD_tipo_Movimiento, descripcion, fecha_Hora,monto, iD_cuenta_final, iD_cuenta_origen) VALUES (@ID_tipo_Movimiento, @Descripcion, @Fecha_Hora, @Monto, @ID_cuenta_final, @ID_cuenta_origen)";
        cm.Parameters.Add(new SqlParameter("@ID_Cuenta", transferencia.ID_Cuenta));
        cm.Parameters.Add(new SqlParameter("@Descripcion", transferencia.Descripcion));
        cm.Parameters.Add(new SqlParameter("@Fecha_Hora", transferencia.Fecha_Hora));
        cm.Parameters.Add(new SqlParameter("@Monto", transferencia.Monto));
        cm.Parameters.Add(new SqlParameter("@ID_cuenta_final", transferencia.ID_cuenta_final));
        cm.Parameters.Add(new SqlParameter("@ID_cuenta_origen", transferencia.ID_cuenta_origen));
        cm.ExecuteNonQuery();
        cx.Close();
        transferenciaExito = 1;
      }

      else
      {
        transferenciaExito = 0;
      }


      return transferenciaExito;
    }
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
