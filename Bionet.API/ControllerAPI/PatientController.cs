using Bionet.API.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bionet.Service.Services;
using System.IO;
using System.Web;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace Bionet.API.ControllerAPI
{
    [RoutePrefix("api/patient")]
    public class PatientController : ApiControllerBase
    {
        private IPhieuSangLocService phieuSangLocService;

        public PatientController(IErrorService errorService, IPhieuSangLocService _phieuSangLocService) : base(errorService)
        {
            phieuSangLocService = _phieuSangLocService;
        }

        [Route("getThongTin")]
        [HttpGet]
        public HttpResponseMessage getThongTin(HttpRequestMessage request,string mabenhnhan)
        {
            return request.CreateResponse(HttpStatusCode.OK, phieuSangLocService.GetByMaBenhNhan(mabenhnhan));
        }
        
        [Route("pushFileKQ")]
        [HttpPost]
        public HttpResponseMessage saveFile(HttpRequestMessage request,string mabenhnhan)
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                foreach (string fileName in httpRequest.Files.Keys)
                {
                    var file = httpRequest.Files[fileName];
                    string path = HttpContext.Current.Server.MapPath("~/KetQuaXetNghiem/");
                    path += mabenhnhan;
                    Directory.CreateDirectory(path);
                    file.SaveAs(path + file.FileName);
                }

                return Request.CreateResponse(HttpStatusCode.Created);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [Route("getFileKQ")]
        [HttpGet]
        public HttpResponseMessage getFile(HttpRequestMessage request,string mabenhnhan)
        {
          
            List<String> files = new List<String>();
            string path = HttpContext.Current.Server.MapPath("~/KetQuaXetNghiem/");
            path += mabenhnhan;

            DirectoryInfo dirInfo = new DirectoryInfo(path);
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);

            foreach (FileInfo fInfo in dirInfo.GetFiles())
            {
               
                var pathfile = path+"\\" + fInfo.Name;
                var stream = new FileStream(pathfile, FileMode.Open);
                result.Content = new StreamContent(stream);
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                result.Content.Headers.ContentDisposition.FileName = Path.GetFileName(path)+".pdf";
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                result.Content.Headers.ContentLength = stream.Length;
            }
           
            return result;

        }
    }
    
}
