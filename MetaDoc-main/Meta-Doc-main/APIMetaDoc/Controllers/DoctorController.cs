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
    public class DoctorController : ApiController
    {
        [Logged]
        [HttpGet]
        [Route("api/doctors")]
        public HttpResponseMessage Doctors()
        {
            try
            {
                var data = DoctorService.Get();

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [Logged]
        [HttpGet]
        [Route("api/doctors/{id}")]
        public HttpResponseMessage Doctors(int Id)
        {
            try
            {
                var data = DoctorService.Get(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [Logged]
        [HttpPost]
        [Route("api/doctors/create")]
        public HttpResponseMessage Create(DoctorDTO data)
        {
            try
            {
                var res = DoctorService.Create(data);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
            }
        }

        [Logged]
        [HttpPost]
        [Route("api/doctors/update")]
        public HttpResponseMessage Update(DoctorDTO data)
        {

            var exmp = DoctorService.Get(data.Id);

            if (exmp != null)
            {
                try
                {
                    var res = DoctorService.Update(data);

                    return Request.CreateResponse(HttpStatusCode.OK, new {Message= "Updated"});

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new {Message = "Doctor not found"});
        }
        
        [Logged]
        [DoctorAccess]
        [HttpPost]
        [Route("api/doctors/delete/{id}")] //{id}
        public HttpResponseMessage Delete(int Id) //int id
        {
            var exmp = DoctorService.Get(Id);

            if (exmp != null)
            {
                try
                {
                    var res = DoctorService.Delete(Id);
                    return Request.CreateResponse(HttpStatusCode.OK, new {Message= "Deleted"} );

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new {Message= "Doctor not found" });
        }
    }
}

