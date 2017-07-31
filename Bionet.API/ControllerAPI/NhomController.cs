using Bionet.API.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bionet.Service.Services;

namespace Bionet.API.ControllerAPI
{
    [RoutePrefix("api/nhom")]
    [Authorize]
    public class NhomController : ApiControllerBase
    {
        private INhomService nhomService;

        public NhomController(IErrorService errorService, INhomService _nhomService) : base(errorService)
        {
            this.nhomService = _nhomService;
        }

       

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = this.nhomService.GetAll();
                var responseData = model;
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
    }
}
