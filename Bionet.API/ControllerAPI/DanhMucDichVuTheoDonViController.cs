using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bionet.Service.Services;
using Bionet.API.Infrastructure;

namespace Bionet.API.ControllerAPI
{
    [RoutePrefix("api/dichvutheodv")]
//    [Authorize]
    public class DichVuTheoDonViController : ApiControllerBase
    {
        private IDanhMucDichVuTheoDonViService dichVuService;

        public DichVuTheoDonViController(IErrorService errorService, IDanhMucDichVuTheoDonViService _dichVuService)
            : base(errorService)
        {
            this.dichVuService = _dichVuService;
            
        }


        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request,string levelCode)
        {
            return CreateHttpResponse(request, () =>
            {
                
                var model = this.dichVuService.GetAllTheoDonVi(levelCode);
                var responseData = model;
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

      
    }
}
