using Bionet.Data.Infrastructure;
using Bionet.Data.Repositories;
using Bionet.API.Models;
using Bionet.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bionet.API.Models;
using Bionet.API.Infrastructure;
using Bionet.API.Infrastructure.Extensions;
using Bionet.Web.Models;

namespace Bionet.API.ControllerAPI
{
    [RoutePrefix("api/xntrakqchitiet")]
    [Authorize]
    public class XNTraKQChiTietController : ApiControllerBase
    {
        private IXN_TraKQ_ChiTietService xN_TraKQ_ChiTietService;

        public XNTraKQChiTietController(IXN_TraKQ_ChiTietService _xN_TraKQ_ChiTietService, IErrorService errorService) : base(errorService)
        {
            this.xN_TraKQ_ChiTietService = _xN_TraKQ_ChiTietService;
        }

        

        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request,XN_TraKQ_ChiTietViewModel  TraKetQuaVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var TraKetQuaChiTiet = new XN_TraKQ_ChiTiet();
                    TraKetQuaChiTiet.UpdateXN_TraKetQuaChiTiet(TraKetQuaVm);

                    this.xN_TraKQ_ChiTietService.AddUpd(TraKetQuaChiTiet);
                    
                    this.xN_TraKQ_ChiTietService.Save();
                    response = request.CreateResponse(HttpStatusCode.Created);
                }

                return response;
            });
        }

        [Route("getall")]
        public IEnumerable<XN_TraKQ_ChiTiet> GetAll()
        {
            return this.xN_TraKQ_ChiTietService.GetAll();
        }
    }
}
