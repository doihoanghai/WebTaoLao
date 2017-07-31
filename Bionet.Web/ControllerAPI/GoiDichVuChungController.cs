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
    [RoutePrefix("api/goidichvuchung")]
    [Authorize]
    public class GoiDichVuChungController : ApiControllerBase
    {
        private IGoiDichVuChungService goiDichVuChungService;

        public GoiDichVuChungController(IErrorService errorService, IGoiDichVuChungService _goiDichVuChungService) : base(errorService)
        {
            this.goiDichVuChungService = _goiDichVuChungService;
        }


        [Route("getallGoiDichVuChung")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = this.goiDichVuChungService.GetAll();
                var responseData = model;
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
    }
}
