using APIMetaDoc.Auth;
using APIMetaDoc.Models;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Services.Description;

namespace APIMetaDoc.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login (LoginModel login)
        {
            try
            {
                var res = AuthService.Authenticate(login.Username, login.Password);
                if (res != null)
                {
                    var data = UserService.Get(res.Username);
                    if (data.Role == "Doctor")
                    {
                        
                        return Request.CreateResponse(HttpStatusCode.OK, data);
                    }
                    else if (data.Role == "Patient")
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, res);
                    }
                    else if (data.Role == "Pharmacy")
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, res);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "User Not Found!" });
                    }
                } else 
                        return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "User Not Found!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [Logged]
        [HttpGet]
        [Route("api/logout")]
        public HttpResponseMessage Logout()
        {
            var token = Request.Headers.Authorization.ToString();
            try
            {
                var res = AuthService.Logout(token);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
    }
}
