using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
  public class ProvinciaController : ApiController
  {
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public ProvinciaController()
    {



    }
  }
}
