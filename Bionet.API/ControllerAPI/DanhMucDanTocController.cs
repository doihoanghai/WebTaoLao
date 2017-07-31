using Bionet.API.Infrastructure;
using Bionet.Service.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bionet.API.ControllerAPI
{
    [RoutePrefix("api/dantoc")]
    [Authorize]
    public class DanhMucDanTocController : ApiControllerBase
    {
        private IDanhMucDanTocService danhMucDanTocService;

        public DanhMucDanTocController(IErrorService errorService, IDanhMucDanTocService _danhMucDanTocService) : base(errorService)
        {
            this.danhMucDanTocService = _danhMucDanTocService;
        }



        [Route("getallDanToc")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = this.danhMucDanTocService.GetAll();
                var responseData = model;
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
    }
}
