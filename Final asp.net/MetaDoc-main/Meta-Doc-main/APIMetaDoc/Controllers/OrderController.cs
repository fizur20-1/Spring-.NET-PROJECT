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
        //[Logged]
        [AdminAccess]
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
        
        [PatientAccess]
        [Logged]
        [HttpGet]
        [Route("api/patients/orders/{id}")] //patient id
        public HttpResponseMessage Orders(int Id)
        {
            try
            {
                var data1 = OrderDetailService.Get();
                var status = data1.FirstOrDefault(x => x.Patient_Id == Id);
                if (status != null)
                {
                    var data = OrderService.Get(status.Order_Id);
                    var patient = PatientService.Get(Id);

                    if (patient.Username == AuthService.Check())
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, data);
                    }
                    else return Request.CreateResponse(HttpStatusCode.OK, "Invalid Search");
                }
                else return Request.CreateResponse(HttpStatusCode.OK, "Order Doesn't Exist");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [PatientAccess]
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

        //[PatientAccess]
        //[Logged]
        //[HttpPost]
        //[Route("api/orders/update")]
        //public HttpResponseMessage Update(OrderDTO data)
        //{

        //    var exmp = OrderService.Get(data.Id);

        //    if (exmp != null)
        //    {
        //        try
        //        {
        //            var res = OrderService.Update(data);
        //            var patient = PatientService.Get(data.Patient_Id);

        //            if (patient.Username == AuthService.Check())
        //            {
        //                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Updated" });
        //            }
        //            else return Request.CreateResponse(HttpStatusCode.OK, "Invalid Search");
        //        }
        //        catch (Exception ex)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
        //        }
        //    }
        //    else
        //        return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Order not found" });
        //}

        //[PatientAccess]
        //[Logged]
        //[HttpPost]
        //[Route("api/orders/delete/{id}")] //{id}
        //public HttpResponseMessage Delete(int Id) //int id
        //{
        //    var exmp = OrderService.Get(Id);

        //    if (exmp != null)
        //    {
        //        try
        //        {
        //            var res = OrderService.Delete(Id);

        //            var patient = PatientService.Get(res.Patient_Id);

        //            if (patient.Username == AuthService.Check())
        //            {
        //                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Deleted" });
        //            }
        //            else return Request.CreateResponse(HttpStatusCode.OK, "Invalid Search");
        //        }
        //        catch (Exception ex)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
        //        }
        //    }
        //    else
        //        return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Order not found" });
        //}

        [PatientAccess]
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
                    var data1 = OrderDetailService.Get();
                    var status = data1.FirstOrDefault(x => x.Order_Id == exmp.Id);
                    if (status != null)
                    {
                        var res = OrderService.Update(exmp);
                        return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Updated" });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "You Can't Update Others Order" });
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Order not found" });
        }

        [PatientAccess]
        [Logged]
        [HttpPost]
        [Route("api/orders/delete/{id}")]
        public HttpResponseMessage Delete(int Id)
        {
            var exmp = OrderService.Get(Id);

            if (exmp != null)
            {
                try
                {
                    var data = OrderDetailService.Get();
                    var status = data.FirstOrDefault(x => x.Order_Id == exmp.Id);
                    if (status != null)
                    {
                        var res = OrderService.Delete(Id);
                        return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Deleted" });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "You Can't Delete Others Order" });
                    }

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
