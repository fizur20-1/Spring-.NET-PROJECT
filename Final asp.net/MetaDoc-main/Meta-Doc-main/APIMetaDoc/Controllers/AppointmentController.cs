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
    [EnableCors("*","*","*")]
    public class AppointmentController : ApiController
    {
        [Logged]
        [HttpGet]
        [Route("api/appoinments")]
        public HttpResponseMessage Appoinments()
        {
            try
            {
                var data = PatientAppointmentService.Get();

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        
        [Logged]
        [HttpGet]
        [Route("api/appoinments/{id}")]
        public HttpResponseMessage Appointments(int Id)
        {
            try
            {
                var data = PatientAppointmentService.Get(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [PatientAccess]
        [Logged]
        [HttpPost]
        [Route("api/appoinments/create")]
        public HttpResponseMessage Create(PatientAppoinmentDTO data)
        {
            try
            {
                var res = PatientAppointmentService.Create(data);
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
        [Route("api/appoinments/update")]
        public HttpResponseMessage Update(PatientAppoinmentDTO data)
        {
            var exmp = PatientAppointmentService.Get(data.Id);

            if (exmp != null)
            {
                try
                {
                    var res = PatientAppointmentService.Update(data);

                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Updated" });

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Appoinment not found" });
        }

        [PatientAccess]
        [Logged]
        [HttpPost]
        [Route("api/appoinments/delete/{id}")]
        public HttpResponseMessage Delete(int Id) 
        {
            var exmp = PatientAppointmentService.Get(Id);

            if (exmp != null)
            {
                try
                {
                    var res = PatientAppointmentService.Delete(Id);
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Deleted" });
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Appoinment not found" });
        }
    }
}
