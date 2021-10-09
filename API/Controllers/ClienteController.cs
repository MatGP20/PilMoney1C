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
  [RoutePrefix("api/cliente")]
  [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
  public class ClienteController : ApiController
    {

    // GET: api/Cuenta/5
    public Cliente Get(int cuit)
    {
      GestorCliente cliente = new GestorCliente();
      return cliente.BuscarCliente(cuit);

    }
    public HttpResponseMessage Post(Cliente c)
    {
      if (ModelState.IsValid)
      {
        GestorCliente cliente = new GestorCliente();
        cliente.RegistrarCliente(c);
        return new HttpResponseMessage(HttpStatusCode.OK);
      }

      else
      {
        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
      }
      
    }

  }


}
