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

        [DoctorAccess]
        [Logged]
        [HttpGet]
        [Route("api/doctors/{id}")]
        public HttpResponseMessage Doctors(int Id)
        {
            try
            {
                var data = DoctorService.Get(Id);
                if (data.Username == AuthService.Check())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else return Request.CreateResponse(HttpStatusCode.OK, "Invalid Doctor");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

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

        [DoctorAccess]
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

                    if (res.Username == AuthService.Check())
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Doctor Updated" });
                    }
                    else return Request.CreateResponse(HttpStatusCode.OK, "Invalid Search");

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
        [Route("api/doctors/delete/{id}")]
        public HttpResponseMessage Delete(int Id)
        {
            var exmp = DoctorService.Get(Id);

            if (exmp != null)
            {
                try
                {
                    var res = DoctorService.Delete(Id);

                    if (exmp.Username == AuthService.Check())
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Doctor Deleted" });
                    }
                    else return Request.CreateResponse(HttpStatusCode.OK, "Invalid Search");
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new {Message= "Doctor not found" });
        }

        [DoctorAccess]
        [Logged]
        [HttpGet]
        [Route("api/doctors/{id}/reviews")]
        public HttpResponseMessage DoctorReviews(int id)
        {
            try
            {
                var data = DoctorService.GetwithReviews(id);
                if (data.Username == AuthService.Check())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else return Request.CreateResponse(HttpStatusCode.OK, "Invalid Doctor");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [DoctorAccess]
        [Logged]
        [HttpGet]
        [Route("api/doctors/{id}/appointments")]
        public HttpResponseMessage DoctorAppointments(int id)
        {
            try
            {
                var data = DoctorService.GetwithAppointment(id);
                if (data.Username == AuthService.Check())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else return Request.CreateResponse(HttpStatusCode.OK, "Invalid Doctor");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [DoctorAccess]
        [Logged]
        [HttpGet]
        [Route("api/doctors/{id}/diseasesymptoms")]
        public HttpResponseMessage DoctorDiseaseSymptoms(int id)
        {
            try
            {
                var data = DoctorService.GetwithDiseaseSymptoms(id);
                if (data.Username == AuthService.Check())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else return Request.CreateResponse(HttpStatusCode.OK, "Invalid Doctor");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}

