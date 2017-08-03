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
using Newtonsoft.Json;
using System.Web;

namespace Bionet.API.ControllerAPI
{
    [RoutePrefix("api/xnketqua")]
    [Authorize]
    public class XNKetQuaController : ApiControllerBase
    {
        private IXN_KetQuaService xN_KetQuaService;
        private IXN_KetQua_ChiTietService xN_KetQuaChiTietService;
        private ApplicationUserManager userManager;


        public XNKetQuaController(IErrorService errorService, IXN_KetQuaService _xN_KetQuaService, IXN_KetQua_ChiTietService _xN_KetQuaChiTietService,ApplicationUserManager _userManager) : base(errorService)
        {
            this.xN_KetQuaService = _xN_KetQuaService;
            this.xN_KetQuaChiTietService = _xN_KetQuaChiTietService;
            this.userManager = _userManager;
        }

        [Route("getall")]
        public IEnumerable<XN_KetQua> GetAll()
        {
            return this.xN_KetQuaService.GetAll();
        }

        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, XN_KetQuaViewModel ketQuaVm)
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
                    var ketQua = new XN_KetQua();
                    ketQua.UpdateXN_KetQua(ketQuaVm);

                    this.xN_KetQuaService.AddUpd(ketQua);
                    foreach(var chitietVm in ketQuaVm.lstKetQuaChiTiet)
                    {
                        var ketQuaChiTiet = new XN_KetQua_ChiTiet();
                        ketQuaChiTiet.UpdateXN_KetQuaChiTiet(chitietVm);
                        this.xN_KetQuaChiTietService.AddUpd(ketQuaChiTiet);
                    }
                    this.xN_KetQuaService.Save();
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
            XN_KetQuaViewModel ketQuaVm = JsonConvert.DeserializeObject<XN_KetQuaViewModel>(jsonContent);

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
