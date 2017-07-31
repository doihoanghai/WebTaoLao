using Bionet.Data.Infrastructure;
using Bionet.Data.Repositories;
using Bionet.Web.Models;
using Bionet.Service.Services;
using Bionet.Web.Infrastructure;
using Bionet.Web.Infrastructure.Extensions;
using Bionet.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bionet.Web.ControllerAPI
{
    [RoutePrefix("api/tiepnhan")]
    [Authorize]
    public class TiepNhanController : ApiControllerBase
    {
        private ITiepNhanService tiepNhanService;


        public TiepNhanController(IErrorService errorService, ITiepNhanService _tiepNhanService) : base(errorService)
        {
            this.tiepNhanService = _tiepNhanService;
        }

        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, TiepNhanViewModel TiepNhanVM)
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
                    var tiepNhan = new TiepNhan();
                    tiepNhan.UpdateTiepNhan(TiepNhanVM);

                    this.tiepNhanService.AddUpd(tiepNhan);
                    foreach (var chitietVm in TiepNhanVM.lstTiepNhanVM)
                    {
                        var tiepnhan = new TiepNhan();
                        tiepNhan.UpdateTiepNhan(TiepNhanVM);
                        this.tiepNhanService.AddUpd(tiepnhan);
                    }
                    this.tiepNhanService.Save();
                    response = request.CreateResponse(HttpStatusCode.Created);
                }

                return response;
            });
        }


        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = tiepNhanService.GetAll();
                var responseData = model;
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
    }
}
