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
    public class DiseaseController : ApiController
    {
        [DoctorAccess]
        [Logged]
        [HttpGet]
        [Route("api/diseases")]
        public HttpResponseMessage Symptoms()
        {
            try
            {
                var data = DiseaseSymptomService.Get();

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [PatientAccess]
        [Logged]
        [HttpGet]
        [Route("api/diseases/{id}")]
        public HttpResponseMessage Symptoms(int Id)
        {
            try
            {
                var data = DiseaseSymptomService.Get(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [DoctorAccess]
        [Logged]
        [HttpPost]
        [Route("api/diseases/create")]
        public HttpResponseMessage Create(DiseaseSymptomDTO data)
        {
            try
            {
                var res = DiseaseSymptomService.Create(data);
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
        [Route("api/diseases/update")]
        public HttpResponseMessage Update(DiseaseSymptomDTO data)
        {

            var exmp = DiseaseSymptomService.Get(data.Id);

            if (exmp != null)
            {
                try
                {
                    var res = DiseaseSymptomService.Update(data);

                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Updated" });

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Symptom not found" });
        }

        [DoctorAccess]
        [Logged]
        [HttpPost]
        [Route("api/diseases/delete/{id}")] //{id}
        public HttpResponseMessage Delete(int Id) //int id
        {
            var exmp = DiseaseSymptomService.Get(Id);

            if (exmp != null)
            {
                try
                {
                    var res = DiseaseSymptomService.Delete(Id);
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Deleted" });

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Disease  not found" });
        }
    }
}
