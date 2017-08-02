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
using Bionet.API.Models;
using AutoMapper;
using Bionet.Web.Models;

namespace Bionet.API.ControllerAPI
{
    [RoutePrefix("api/patient")]
    public class PatientController : ApiControllerBase
    {
        private IPhieuSangLocService phieuSangLocService;
        private IPatientService patientService;


        public PatientController(IErrorService errorService, IPhieuSangLocService _phieuSangLocService,IPatientService _patientService) : base(errorService)
        {
            phieuSangLocService = _phieuSangLocService;
            patientService = _patientService;
        }

        [Route("getThongTin")]
        [HttpGet]
        public HttpResponseMessage getThongTin(HttpRequestMessage request,string mabenhnhan)
        {
            mabenhnhan = "B1275d22b2-a557-4692-9b60-54c037e93dba";
            return CreateHttpResponse(request, () =>
            {
                var model = phieuSangLocService.GetByMaBenhNhan(mabenhnhan);
                var responseData = Mapper.Map<PhieuSangLoc, PhieuSangLocViewModel>(model);
                var modelPatient = patientService.GetByMaBN(model.MaBenhNhan);
                responseData = Mapper.Map<Patient, PhieuSangLocViewModel>(modelPatient, responseData);

                IFormatProvider mFomatter = new System.Globalization.CultureInfo("en-CA");
                if (!string.IsNullOrEmpty(responseData.NgayGioLayMau))
                {
                    string NgayGioLayMau = responseData.NgayGioLayMau.Substring(0, 10);
                    DateTime NgayGioLayMauTime = DateTime.Parse(responseData.NgayGioLayMau.ToString(), mFomatter);
                    responseData.NgayGioLayMau = NgayGioLayMau;
                    responseData.NgayGioLayMauTime = NgayGioLayMauTime;
                }
                if (!string.IsNullOrEmpty(responseData.NgayGioSinh))
                {
                    string NgayGioSinh = responseData.NgayGioSinh.Substring(0, 10);
                    DateTime NgayGioSinhTime = DateTime.Parse(responseData.NgayGioSinh, mFomatter);
                    responseData.NgayGioSinh = NgayGioSinh;
                    responseData.NgayGioSinhTime = NgayGioSinhTime;
                }
                if (!string.IsNullOrEmpty(responseData.MotherBirthday))
                    responseData.MotherBirthday = responseData.MotherBirthday.Substring(0, 10);
                if (!string.IsNullOrEmpty(responseData.FatherBirthday))
                    responseData.FatherBirthday = responseData.FatherBirthday.Substring(0, 10);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
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
