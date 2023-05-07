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
    public class OrderController : ApiController
    {
        [Logged]
        [HttpGet]
        [Route("api/orders")]
        public HttpResponseMessage Orders()
        {
            try
            {
                var data = OrderService.Get();

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [Logged]
        [HttpGet]
        [Route("api/orders/{id}")]
        public HttpResponseMessage Orders(int Id)
        {
            try
            {
                var data = OrderService.Get(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [Logged]
        [HttpPost]
        [Route("api/orders/create")]
        public HttpResponseMessage Create(OrderDTO data)
        {
            try
            {
                var res = OrderService.Create(data);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
            }
        }

        [Logged]
        [HttpPost]
        [Route("api/orders/update")]
        public HttpResponseMessage Update(OrderDTO data)
        {

            var exmp = OrderService.Get(data.Id);

            if (exmp != null)
            {
                try
                {
                    var res = OrderService.Update(data);

                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Updated" });

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Order not found" });
        }

        [Logged]
        [HttpPost]
        [Route("api/orders/delete/{id}")] //{id}
        public HttpResponseMessage Delete(int Id) //int id
        {
            var exmp = OrderService.Get(Id);

            if (exmp != null)
            {
                try
                {
                    var res = OrderService.Delete(Id);
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Deleted" });

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Order not found" });
        }
    }
}
