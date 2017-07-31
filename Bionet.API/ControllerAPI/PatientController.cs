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

namespace Bionet.API.ControllerAPI
{
    [RoutePrefix("api/patient")]
    public class PatientController : ApiControllerBase
    {
        
        public PatientController(IErrorService errorService) : base(errorService)
        {
        }


        
        [Route("pushFileKQ")]
        [HttpPost]
        public HttpResponseMessage saveFile(HttpRequestMessage request,string mabenhnhan)
        {
            List<string> savedFilePath = new List<string>();
            string rootPath = HttpContext.Current.Server.MapPath("~/KetQuaXetNghiem");
            var provider = new MultipartFileStreamProvider(rootPath);
            var task = Request.Content.ReadAsMultipartAsync(provider).ContinueWith(t =>
            {
                if (t.IsCanceled || t.IsFaulted)
                {
                    Request.CreateErrorResponse(HttpStatusCode.InternalServerError, t.Exception);
                }
                foreach (MultipartFileData item in provider.FileData)
                {
                    try
                    {
                        string Name = mabenhnhan.Trim('/');
                        File.Move(item.LocalFileName, Path.Combine(rootPath, Name));

                        Uri BaseUri = new Uri(Request.RequestUri.AbsoluteUri.Replace(Request.RequestUri.PathAndQuery, string.Empty));
                        string fileRelativePath = "~/KetQuaXetNghiem/" + Name;
                        Uri FileFullFath = new Uri(BaseUri, VirtualPathUtility.ToAbsolute(fileRelativePath));
                        savedFilePath.Add(FileFullFath.ToString());
                    }
                    catch (Exception ex)
                    {
                        string mes = ex.Message;
                    }
                }

            });
            return Request.CreateResponse(HttpStatusCode.Created, savedFilePath); ;
        }
    }
}
