using Bionet.API.Models;
using Bionet.Service.Services;
using Bionet.API.Infrastructure;
using Bionet.API.Infrastructure.Extensions;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bionet.Web.Models;
using Newtonsoft.Json;
using System.Web;

namespace Bionet.API.ControllerAPI
{
    [RoutePrefix("api/xntraTraKetQua")]
    [Authorize]
    public class XNTraKetQuaController : ApiControllerBase
    {
        private IXN_TraKetQuaService xN_TraKetQuaService;
        private IXN_TraKQ_ChiTietService xN_TraKetQuaChiTietService;
        private ApplicationUserManager userManager;


        public XNTraKetQuaController(IErrorService errorService, IXN_TraKetQuaService _xN_TraKetQuaService, IXN_TraKQ_ChiTietService _xN_TraKetQuaChiTietService, ApplicationUserManager _userManager) : base(errorService)
        {
            this.xN_TraKetQuaService = _xN_TraKetQuaService;
            this.xN_TraKetQuaChiTietService = _xN_TraKetQuaChiTietService;
            this.userManager = _userManager;
        }

        [Route("getall")]
        public IEnumerable<XN_TraKetQua> GetAll()
        {
            return this.xN_TraKetQuaService.GetAll();
        }

        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, XN_TraKetQuaViewModel TraKetQuaVm)
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
                    var TraKetQua = new XN_TraKetQua();
                    TraKetQua.UpdateXN_TraKetQua(TraKetQuaVm);

                    this.xN_TraKetQuaService.AddUpd(TraKetQua);
                    foreach (var chitietVm in TraKetQuaVm.lstTraKetQuaChiTiet)
                    {
                        var TraKetQuaChiTiet = new XN_TraKQ_ChiTiet();
                        TraKetQuaChiTiet.UpdateXN_TraKetQuaChiTiet(chitietVm);
                        this.xN_TraKetQuaChiTietService.AddUpd(TraKetQuaChiTiet);
                    }
                    this.xN_TraKetQuaService.Save();
                    response = request.CreateResponse(HttpStatusCode.Created);
                }

                return response;
            });
        }

        [Route("AddUpFromApp")]
        public HttpResponseMessage addupp(HttpRequestMessage request)
        {
            HttpContent requestContent = Request.Content;
            string jsonContent = requestContent.ReadAsStringAsync().Result;
            XN_TraKetQuaViewModel ketQuaVm = JsonConvert.DeserializeObject<XN_TraKetQuaViewModel>(jsonContent);

            var userName = HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name;
            var user = userManager.FindByNameAsync(userName).Result;

            if (ketQuaVm.MaDVCS.Contains(user.LevelCode) && ketQuaVm.MaTrungTam == user.LevelCode)
            {
                return Create(request, ketQuaVm);
            }
            else
                return request.CreateResponse(HttpStatusCode.BadRequest);

        }
    }
}
