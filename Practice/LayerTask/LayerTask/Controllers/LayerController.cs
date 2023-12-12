using BLLL.DTOs;
using BLLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LayerTask.Controllers
{
    public class LayerController : ApiController
    {
        [HttpGet]
        [Route("api/news/{id}")]
        public HttpResponseMessage GetNews(int id)
        {
            try
            {
                var data = NewsService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);

            }
        }
        [HttpPost]
        [Route("api/news/create")]
        public HttpResponseMessage Create(NewsDTO data)
        {
            try
            {
                NewsService.Create(data);
                return Request.CreateResponse(HttpStatusCode.OK, "Created News");

            }
            catch(Exception ex) 
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);

            }
        }
        [HttpGet]
        [Route("api/category/{id}")]
        public HttpResponseMessage GetCategory(int id)
        {
            try
            {
                var data = CategoryService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex);

            }
        }

        [HttpPost]
        [Route("api/category/create")]
        public HttpResponseMessage CreateCategory(CategoryDTO data)
        {
            try
            {
                CategoryService.Create(data);
                return Request.CreateResponse(HttpStatusCode.OK, "Created Category");

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);

            }
        }


    }
}
