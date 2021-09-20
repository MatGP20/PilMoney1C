using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
  [RoutePrefix("api/provincia")]
  [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
  public class ProvinciaController : ApiController
  {
    
      //public ProvinciaController(){}
    
      // GET: api/Provincia
      
      public List<Provincia> Get()
      {
        GestorCliente provincia = new GestorCliente();
        return provincia.ObtenerProvincia();
      }

    
  }
}
