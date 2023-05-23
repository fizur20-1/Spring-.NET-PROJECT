using APIMetaDoc.Auth;
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
    public class OrderDetailController : ApiController
    {
        [PharmacyAccess]
        [Logged]
        [HttpGet]
        [Route("api/orderdetails")]
        public HttpResponseMessage OrderDetails()
        {
            try
            {
                var data = OrderDetailService.Get();

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
        [Route("api/orderdetails/{id}")]
        public HttpResponseMessage OrderDetails(int Id)
        {
            try
            {
                var data = OrderDetailService.Get(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
    }
}
