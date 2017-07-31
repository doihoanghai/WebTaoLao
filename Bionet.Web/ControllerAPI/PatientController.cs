using Bionet.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bionet.Service.Services;
using System.IO;

namespace Bionet.Web.ControllerAPI
{
    [RoutePrefix("api/patient")]
    [Authorize]
    public class PatientController : ApiControllerBase
    {
        
        public PatientController(IErrorService errorService) : base(errorService)
        {
        }

        [Route("pushFileKQ")]
        [HttpPost]
        [Authorize]
        public HttpResponseMessage saveFile(HttpRequestMessage request,string mabenhnhan)
        {
            string rootpath = System.Web.Hosting.HostingEnvironment.MapPath("/File/");
            System.Web.HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            System.Web.HttpPostedFile file = files[0];


            string filename = new FileInfo(file.FileName).Name;
            //Định dạng tên file : kqxn1 - kqxn2 - ...
            if (file.ContentLength > 0)
            {
                string pathname = rootpath + mabenhnhan + filename;
                file.SaveAs(pathname);

                return request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest,"File is not exist ! ");
            }


        }
    }
}
