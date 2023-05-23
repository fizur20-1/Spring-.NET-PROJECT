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
        [PharmacyAccess]
        //[PatientAccess] copy kore controler boshiye dibo
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

        [PharmacyAccess]
        [Logged]
        [HttpGet]
        [Route("api/products/{id}")]
        public HttpResponseMessage Products(int Id) //pharmacy id
        {
            try
            {
                var data1 = PharProductService.Get();
                var status = data1.FirstOrDefault(x => x.Pharmacy_Id == Id);
                if (status != null)
                {
                    var data = ProductService.Get(status.Product_Id);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Product Not Accessible" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [PharmacyAccess]
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

        [PharmacyAccess]
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
                    var data1 = PharProductService.Get();
                    var status = data1.FirstOrDefault(x => x.Product_Id == exmp.Id);
                    if (status != null)
                    {
                        var res = ProductService.Update(exmp);
                        return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Updated" });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "You Can't Update Others Product" });
                    }

                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Product not found" });
        }

        [PharmacyAccess]
        [Logged]
        [HttpPost]
        [Route("api/products/delete/{id}")] 
        public HttpResponseMessage Delete(int Id) 
        {
            var exmp = ProductService.Get(Id);

            if (exmp != null)
            {
                try
                {
                    var data = PharProductService.Get();
                    var status = data.FirstOrDefault(x => x.Product_Id == exmp.Id);
                    if (status != null)
                    {
                        var res = ProductService.Delete(Id);
                        return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Deleted" });
                    } else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "You Can't Delete Others Product" });
                    }

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
