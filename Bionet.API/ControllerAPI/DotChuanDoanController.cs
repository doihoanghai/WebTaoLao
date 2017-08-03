using Bionet.API.Models;
using Bionet.Service.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bionet.Web.Models;
using Newtonsoft.Json;
using System.Web;
using Bionet.API.Infrastructure;

namespace Bionet.API.ControllerAPI
{
    [RoutePrefix("api/dotchuandoan")]
    [Authorize]
    public class DotChuanDoanController : ApiControllerBase
    {
        private IDotChuanDoanService dotChuanDoanService;
        private ApplicationUserManager userManager;

        public DotChuanDoanController(IErrorService errorService, IDotChuanDoanService _dotChuanDoanService, ApplicationUserManager _userManager) : base(errorService)
        {
            this.dotChuanDoanService = _dotChuanDoanService;
            this.userManager = _userManager;
        }

        [Route("AddUppFromApp")]
        [HttpPost]
        public HttpResponseMessage AddUp(HttpRequestMessage request, XN_KetQua_ChiTietViewModel _xN_KetQua_ChiTietViewModel)
        {
            HttpContent requestContent = Request.Content;
            string jsonContent = requestContent.ReadAsStringAsync().Result;
            DotChuanDoan dotchuandoan = JsonConvert.DeserializeObject<DotChuanDoan>(jsonContent);

            var userName = HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name;
            var user = userManager.FindByNameAsync(userName).Result;

            if (dotchuandoan.MaDVCS.Contains(user.LevelCode) && dotchuandoan.MaTrungTam == user.LevelCode)
            {
                DotChuanDoan dcd = this.dotChuanDoanService.GetByMa(dotchuandoan.MaDotChuanDoan);
                if (dcd == null)
                {
                    this.dotChuanDoanService.Add(dotchuandoan);
                }
                else
                {
                    this.dotChuanDoanService.Update(dotchuandoan);
                }
                this.dotChuanDoanService.Save();
                return request.CreateResponse(HttpStatusCode.OK);
            }
            else
                return request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [Route("getall")]
        public IEnumerable<DotChuanDoan> GetAll()
        {
            return this.dotChuanDoanService.GetAll();
        }
    }
}
