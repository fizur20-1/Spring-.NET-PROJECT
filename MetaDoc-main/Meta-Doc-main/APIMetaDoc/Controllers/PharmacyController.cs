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
    public class PharmacyController : ApiController
    {
        [Logged]
        [HttpGet]
        [Route("api/pharmacies")]
        public HttpResponseMessage Pharmacies()
        {
            try
            {
                var data = PharmacyService.Get();

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [Logged]
        [HttpGet]
        [Route("api/pharmacies/{id}")]
        public HttpResponseMessage Pharmacies(int Id)
        {
            try
            {
                var data = PharmacyService.Get(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [Logged]
        [HttpPost]
        [Route("api/pharmacies/create")]
        public HttpResponseMessage Create(PharmacyDTO data)
        {
            try
            {
                var res = PharmacyService.Create(data);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
            }
        }

        [Logged]
        [HttpPost]
        [Route("api/pharmacies/update")]
        public HttpResponseMessage Update(PharmacyDTO data)
        {

            var exmp = PharmacyService.Get(data.Id);

            if (exmp != null)
            {
                try
                {
                    var res = PharmacyService.Update(data);

                    return Request.CreateResponse(HttpStatusCode.OK, "Updated");

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Pharmacy not found");
        }

        [Logged]
        [PharmacyAccess]
        [HttpPost]
        [Route("api/pharmacies/delete/{id}")]
        public HttpResponseMessage Delete(int Id)
        {
            var exmp = PharmacyService.Get(Id);

            if (exmp != null)
            {
                try
                {
                    var res = PharmacyService.Delete(Id);
                    return Request.CreateResponse(HttpStatusCode.OK, "Deleted");

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Pharmacy not found");
        }
    }
}

