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
    public class ProductController : ApiController
    {
        [Logged]
        [HttpGet]
        [Route("api/products")]
        public HttpResponseMessage Products()
        {
            try
            {
                var data = ProductService.Get();

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [Logged]
        [HttpGet]
        [Route("api/products/{id}")]
        public HttpResponseMessage Products(int Id)
        {
            try
            {
                var data = ProductService.Get(Id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [Logged]
        [HttpPost]
        [Route("api/products/create")]
        public HttpResponseMessage Create(ProductDTO data)
        {
            try
            {
                var res = ProductService.Create(data);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
            }
        }

        [Logged]
        [HttpPost]
        [Route("api/products/update")]
        public HttpResponseMessage Update(ProductDTO data)
        {

            var exmp = ProductService.Get(data.Id);

            if (exmp != null)
            {
                try
                {
                    var res = ProductService.Update(data);

                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Updated" });

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Product not found" });
        }

        [Logged]
        [HttpPost]
        [Route("api/products/delete/{id}")] //{id}
        public HttpResponseMessage Delete(int Id) //int id
        {
            var exmp = ProductService.Get(Id);

            if (exmp != null)
            {
                try
                {
                    var res = ProductService.Delete(Id);
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Deleted" });

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Product not found" });
        }
    }
}
