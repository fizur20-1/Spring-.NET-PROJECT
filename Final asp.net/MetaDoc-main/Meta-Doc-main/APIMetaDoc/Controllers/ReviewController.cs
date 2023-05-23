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
    public class ReviewController : ApiController
    {
        [PatientAccess]
        //[DoctorAccess]
        [Logged]
        [HttpGet]
        [Route("api/reviews")]
        public HttpResponseMessage Reviews()
        {
            try
            {
                var data = ReviewService.Get();

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        //[PatientAccess]
        //[DoctorAccess]
        [Logged]
        [HttpGet]
        [Route("api/reviews/{id}")]
        public HttpResponseMessage Reviews(int Id)
        {
            try
            {
                var data = ReviewService.Get(Id);
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
        [Route("api/reviews/create")]
        public HttpResponseMessage Create(ReviewDTO data)
        {
            try
            {
                var res = ReviewService.Create(data);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
            }
        }

        [Logged]
        [HttpPost]
        [Route("api/reviews/update")]
        public HttpResponseMessage Update(ReviewDTO data)
        {

            var exmp = ReviewService.Get(data.Id);

            if (exmp != null)
            {
                try
                {
                    var res = ReviewService.Update(data);

                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Updated" });

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Review not found" });
        }

        [AdminAccess]
        [Logged]
        [HttpPost]
        [Route("api/reviews/delete/{id}")] //{id}
        public HttpResponseMessage Delete(int Id) //int id
        {
            var exmp = ReviewService.Get(Id);

            if (exmp != null)
            {
                try
                {
                    var res = ReviewService.Delete(Id);
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Deleted" });

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Review not found" });
        }
    }
}