using Bionet.Service.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bionet.API.Infrastructure;
using System.Web;
using Newtonsoft.Json;
using Bionet.API.Models;
using Bionet.Web.Models;

namespace Bionet.API.ControllerAPI
{
    [RoutePrefix("api/benhnhannguycocao")]
    [Authorize]
    public class BenhNhanNguyCoCaoController : ApiControllerBase
    {
        private IBenhNhanNguyCoCaoService benhNhanNguyCoCaoService;
        private ApplicationUserManager userManager;

        public BenhNhanNguyCoCaoController(IErrorService errorService, IBenhNhanNguyCoCaoService _benhNhanNguyCoCaoService, ApplicationUserManager _userManager) : base(errorService)
        {
            this.benhNhanNguyCoCaoService = _benhNhanNguyCoCaoService;
            this.userManager = _userManager;
        }

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var userName = HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name;
                var lvCode = userManager.FindByNameAsync(userName).Result.LevelCode;


                var model = benhNhanNguyCoCaoService.GetAll(lvCode);
                var responseData = model;
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("AddUpFromApp")]
        public HttpResponseMessage addupp(HttpRequestMessage request)
        {
            HttpContent requestContent = Request.Content;
            string jsonContent = requestContent.ReadAsStringAsync().Result;
            BenhNhanNguyCoCao benhnhan = JsonConvert.DeserializeObject<BenhNhanNguyCoCao>(jsonContent);

            var userName = HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name;
            var user = userManager.FindByNameAsync(userName).Result;

            if (benhnhan.MaDVCS.Contains(user.LevelCode) && benhnhan.MaTrungTam == user.LevelCode)
            {
                this.benhNhanNguyCoCaoService.AddUp(benhnhan);
                this.benhNhanNguyCoCaoService.Save();
                return request.CreateResponse(HttpStatusCode.OK);
            }
            else
                return request.CreateResponse(HttpStatusCode.BadRequest);
            
        }
    }
}
