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

    public int RegistrarCliente(Cliente nuevo)
    {
      Cliente clienteBuscado = new Cliente();

      int mensaje;

      SqlConnection cx = new SqlConnection(conection);
      cx.Open();

      SqlCommand cm = cx.CreateCommand();
      cm.CommandText = "SELECT Cuit_Cuil FROM Cliente WHERE cuit_Cuil = @Cuit_Cuil";
      cm.Parameters.Add(new SqlParameter("@Cuit_Cuil", nuevo.Cuit_Cuil));

      SqlDataReader dr = cm.ExecuteReader();

      if (dr.Read())
      {
        Int64 Cuil_Cuit = dr.GetInt64(0);

        Cliente cliente = new Cliente(Cuil_Cuit);
        clienteBuscado = cliente;
      }

      dr.Close();
      cx.Close();

      cx.Close();

      if (clienteBuscado.Cuit_Cuil == 0) {
        
        cx.Open();
        cm = cx.CreateCommand();
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

        mensaje = 0;

        return mensaje;

      }
      else
      {

        mensaje = 1;

        return mensaje;
      }

    }

    public Cliente BuscarCliente(Int64 cuit_Cuil)
    {
      Cliente clienteBuscado = new Cliente();

      SqlConnection cx = new SqlConnection(conection);
      cx.Open();

      SqlCommand cm = cx.CreateCommand();
      cm.CommandText = "SELECT * FROM Cliente WHERE cuit_Cuil = @Cuit_Cuil";
      cm.Parameters.Add(new SqlParameter("@Cuit_Cuil", cuit_Cuil));

      SqlDataReader dr = cm.ExecuteReader();

      if(dr.Read())
      {
        Int64 Cuil_Cuit = dr.GetInt64(0);
        string Nombre = dr.GetString(1).Trim();
        string Apellido = dr.GetString(2).Trim();
        string Password = dr.GetString(3).Trim();
        string Mail = dr.GetString(4).Trim();
        int ID_Localidad = dr.GetInt32(5);
        string Foto_Frontal = dr.GetString(6).Trim();
        string DNI_Delante = dr.GetString(7).Trim();
        string DNI_Detras = dr.GetString(8).Trim();
        string Domicilio = dr.GetString(9).Trim();

        Cliente cliente = new Cliente(Cuil_Cuit, Nombre, Apellido, Password, Mail, ID_Localidad, Foto_Frontal, DNI_Delante, DNI_Detras, Domicilio);
        clienteBuscado = cliente;
      }

      dr.Close();
      cx.Close();

      cx.Close();

      return clienteBuscado;
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

    public List<Localidad> ObtenerLocalidadPorPr(int iD_Provincia)
    {
      var listaLocalidades = new List<Localidad>();

      SqlConnection cx = new SqlConnection(conection);
      cx.Open();

      SqlCommand cm = cx.CreateCommand();
      cm.CommandText = "SELECT * FROM Localidad WHERE ID_Provincia = @iD_Provincia";
      cm.Parameters.Add(new SqlParameter("@iD_Provincia", iD_Provincia));

      SqlDataReader dr = cm.ExecuteReader();

      while (dr.Read())
      {
        int ID_Localidad = dr.GetInt32(0);
        string Localidad1 = dr.GetString(1).Trim();
        string Codigo_Postal = dr.GetString(2);
        int ID_Provincia = dr.GetInt32(3);

        Localidad Local = new Localidad(ID_Localidad, Localidad1, Codigo_Postal, ID_Provincia);
        listaLocalidades.Add(Local);
      }

      dr.Close();
      cx.Close();

      return listaLocalidades;
    }

    public List<Provincia> ObtenerProvincia()
    {
      var listaProvincias = new List<Provincia>();

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
  }
}
