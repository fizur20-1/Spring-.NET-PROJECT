using APIMetaDoc.Auth;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIMetaDoc.Controllers
{
    public class PharProductController : ApiController
    {
        [Logged]
        [HttpGet]
        [Route("api/pharproducts")]
        public HttpResponseMessage PharmaciesProducts()
        {
            try
            {
                var data = PharProductService.Get();

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [PharmacyAccess]
        [Logged]
        [HttpGet]
        [Route("api/pharproducts/{id}")]
        public HttpResponseMessage PharmacyProducts(int Id)
        {
            try
            {
                var data = PharProductService.Get(Id);
                var pharmacy = PharmacyService.Get(data.Pharmacy_Id);
                if (pharmacy.Username == AuthService.Check())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else return Request.CreateResponse(HttpStatusCode.OK, "Invalid Pharmacy");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
