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
  }
}
