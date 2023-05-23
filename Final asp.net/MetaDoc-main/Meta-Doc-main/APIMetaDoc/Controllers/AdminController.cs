using APIMetaDoc.Auth;
using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APIMetaDoc.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AdminController : ApiController
    {

        [AdminAccess]
        [Logged]
        [HttpGet]
        [Route("api/admins")]
        public HttpResponseMessage Admins()
        {
            try
            {
                var data = AdminService.Get();

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [AdminAccess]
        [Logged]
        [HttpGet]
        [Route("api/admins/{id}")]
        public HttpResponseMessage admins(int Id)
        {
            try
            {
                var data = AdminService.Get(Id);
                if (data.Username == AuthService.Check())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else return Request.CreateResponse(HttpStatusCode.OK, "Invalid Search");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        
        [HttpPost]
        [Route("api/admins/create")]
        public HttpResponseMessage Create(AdminDTO data)
        {
            try
            {
                var res = AdminService.Create(data);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
            }
        }

        [AdminAccess]
        [Logged]
        [HttpPost]
        [Route("api/admins/update")]
        public HttpResponseMessage Update(AdminDTO data)
        {
            var exmp = AdminService.Get(data.Id);

            if (exmp != null)
            {
                try
                {
                    var res = AdminService.Update(data);

                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Admin Updated" });

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Admin not found" });
        }

        [Logged]
        [AdminAccess]
        [HttpPost]
        [Route("api/admins/delete/{id}")]
        public HttpResponseMessage Delete(int Id)
        {
            var exmp = AdminService.Get(Id);

            if (exmp != null)
            {
                try
                {
                    var res = AdminService.Delete(Id);
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Admin Deleted" });

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Admin not found" });
        }
    }
}
