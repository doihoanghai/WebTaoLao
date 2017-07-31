using Bionet.Data.Infrastructure;
using Bionet.Data.Repositories;
using Bionet.Web.Models;
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
    [RoutePrefix("api/benhnhannguycocao")]
//    [Authorize]
    public class BenhNhanNguyCoCaoController : ApiControllerBase
    {
        private IBenhNhanNguyCoCaoService benhNhanNguyCoCaoService;

        public BenhNhanNguyCoCaoController(IErrorService errorService, IBenhNhanNguyCoCaoService _benhNhanNguyCoCaoService) : base(errorService)
        {
            this.benhNhanNguyCoCaoService = _benhNhanNguyCoCaoService;
        }

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = benhNhanNguyCoCaoService.GetAll();
                var responseData = model;
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
    }
}
