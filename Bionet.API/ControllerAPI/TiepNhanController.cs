using Bionet.Data.Infrastructure;
using Bionet.Data.Repositories;
using Bionet.API.Models;
using Bionet.Service.Services;
using Bionet.API.Infrastructure;
using Bionet.API.Infrastructure.Extensions;
using Bionet.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bionet.Web.Models;
using System.Web;

namespace Bionet.API.ControllerAPI
{
    [RoutePrefix("api/tiepnhan")]
    [Authorize]
    public class TiepNhanController : ApiControllerBase
    {
        private ITiepNhanService tiepNhanService;
        private ApplicationUserManager userManager;

        public TiepNhanController(IErrorService errorService, ITiepNhanService _tiepNhanService,ApplicationUserManager _userManager) : base(errorService)
        {
            this.tiepNhanService = _tiepNhanService;
            this.userManager = _userManager;
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
                var userName = HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name;
                var lvCode = userManager.FindByNameAsync(userName).Result.LevelCode;
                var model = tiepNhanService.GetAll(lvCode);
                var responseData = model;
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
    }
}
