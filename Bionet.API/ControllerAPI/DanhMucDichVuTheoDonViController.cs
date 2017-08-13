using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bionet.Service.Services;
using Bionet.API.Infrastructure;
using System.Web;
using System.Collections.Generic;
using Bionet.Web.Models;

namespace Bionet.API.ControllerAPI
{
    [RoutePrefix("api/dichvutheodv")]
//    [Authorize]
    public class DichVuTheoDonViController : ApiControllerBase
    {
        private IDanhMucDichVuTheoDonViService dichVuService;
        private ApplicationUserManager userManager;

        public DichVuTheoDonViController(IErrorService errorService, IDanhMucDichVuTheoDonViService _dichVuService,ApplicationUserManager _userManager)
            : base(errorService)
        {
            this.dichVuService = _dichVuService;
            userManager = _userManager;
            
        }


        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request,string levelCode)
        {
            return CreateHttpResponse(request, () =>
            {
                var user = HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name;
                var lvCode = userManager.FindByNameAsync(user).Result.LevelCode;
                var model = this.dichVuService.GetAllTheoDonVi(lvCode);
                var responseData = model;
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("addup")]
        public HttpResponseMessage AddUpp(HttpRequestMessage request,List<DanhMucDichVuTheoDonVi> listDichVu)
        {
            foreach(var dv in listDichVu)
            {
                this.dichVuService.AddUp(dv);
            }
            this.dichVuService.Save();

            return request.CreateResponse(HttpStatusCode.OK);
        }

      
    }
}
