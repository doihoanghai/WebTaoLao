using Bionet.Service.Services;
using Bionet.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bionet.Web.ControllerAPI
{
    [RoutePrefix("api/dichvutheodv")]
    public class DichVuTheoDonViController : ApiControllerBase
    {
        private IDanhMucDichVuTheoDonViTheoDonViService dichVuService;

        public DichVuTheoDonViController(IErrorService errorService, IDanhMucDichVuTheoDonViTheoDonViService _dichVuService)
            : base(errorService)
        {
            this.dichVuService = _dichVuService;

        }


        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string levelCode)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = this.dichVuService.GetAll();
                var responseData = model;
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }


    }
}
