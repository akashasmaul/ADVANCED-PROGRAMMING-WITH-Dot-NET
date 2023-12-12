using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DemoController : ApiController
    {
        [HttpGet]
        [Route("api/names")]
        public HttpResponseMessage Get()
        {
            var names = new string[] { "Akash", "Avro" };
            return Request.CreateResponse(HttpStatusCode.OK, names);
        }

        [HttpGet]
        [Route("api/name/{st_id}")]

        public HttpResponseMessage GetName(int st_id)
        {
            string name = st_id == 1 ? "Avro" : "Not Found";
            return Request.CreateResponse(HttpStatusCode.OK, name);
        }
        [HttpPost]
        [Route("api/test/post")]
        public HttpResponseMessage TestPost(test n)
        {
            return Request.CreateResponse(HttpStatusCode.OK,n.Uname);
        }
    }
}
