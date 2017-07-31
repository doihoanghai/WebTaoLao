using Bionet.API.Infrastructure;
using Bionet.API.Models;
using Bionet.Service.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bionet.API.ControllerAPI
{
    [RoutePrefix("api/chitietgoidichvu")]
    [Authorize]
    public class ChiTietGoiDichVuController : ApiControllerBase
    {
        private IChiTietGoiDichVuService chiTietGoiDichVuService;

        public ChiTietGoiDichVuController(IErrorService errorService, IChiTietGoiDichVuService _chiTietGoiDichVuService) : base(errorService)
        {
            this.chiTietGoiDichVuService = _chiTietGoiDichVuService;
        }

        [Route("checkauthencreate")]
        [HttpGet]
        [Authorize(Roles = "ChiTietGoiDichVuUpdate")]
        public HttpResponseMessage CheckAuthenCreate(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var response = request.CreateResponse(HttpStatusCode.OK);
                return response;
            });
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage getAll(HttpRequestMessage request)
        {
            return request.CreateResponse(HttpStatusCode.OK, this.chiTietGoiDichVuService.getAll());
        }

        [Route("getServiceByServicePackage/{servicePackageCode}")]
        [HttpGet]
        [Authorize(Roles = "ChiTietGoiDichVuUpdate")]
        public HttpResponseMessage GetById(HttpRequestMessage request, string servicePackageCode)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = this.chiTietGoiDichVuService.GetServiceByServicePackage(servicePackageCode);
                var responseData = model;

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [HttpPost]
        [Route("update")]
        [Authorize(Roles = "ChiTietGoiDichVuUpdate")]
        public HttpResponseMessage Put(HttpRequestMessage request, ChiTietGoiDichVuViewModel chiTietDichVuVm)
        {
            return CreateHttpResponse(request, () =>
            {
                this.chiTietGoiDichVuService.DeleteServicePackage(chiTietDichVuVm.IDGoiDichVuChung);
                this.chiTietGoiDichVuService.AddServicePackageAndService(chiTietDichVuVm.IDGoiDichVuChung, chiTietDichVuVm.lstDanhMucDichVu);
                this.chiTietGoiDichVuService.Save();
                return request.CreateResponse(HttpStatusCode.OK);
            });
        }

    }
}
