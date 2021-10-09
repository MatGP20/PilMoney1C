using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace API.Controllers
{
  [AllowAnonymous]
  [RoutePrefix("api/login")]
  public class LoginController : ApiController
  {
    [HttpGet]
    [Route("echoping")]
    public IHttpActionResult EchoPing()
    {
      return Ok(true);
    }

    [HttpGet]
    [Route("echouser")]
    public IHttpActionResult EchoUser()
    {
      var identity = Thread.CurrentPrincipal.Identity;
      return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
    }

    [HttpPost]
    [System.Web.Mvc.AllowAnonymous]
    [Route("authenticate")]
    public IHttpActionResult Authenticate(LoginRequest login)
    {
      if (login.Mail == null )
        throw new HttpResponseException(HttpStatusCode.BadRequest);

      //TODO: Validate credentials Correctly, this code is only for demo !!
      GestorLogin loginGestor = new GestorLogin();
      bool isCredentialValid = loginGestor.ValidarLogin(login);
      if (isCredentialValid)
      {
        var token = TokenGenerator.GenerateTokenJwt(login.Mail);
        return Ok(token);
      }
      else
      {
        return Unauthorized();
      }
    }
  }
}
