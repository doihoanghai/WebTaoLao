using AutoMapper;
using Bionet.API.Models;
using Bionet.Service.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bionet.API.Infrastructure;
using Bionet.API.Infrastructure.Extensions;
using Bionet.Web.Models;

namespace Bionet.API.ControllerAPI
{
    [RoutePrefix("api/chidinhdv")]
    [Authorize]
    public class ChiDinhDichVuController : ApiControllerBase
    {
        private IChiDinhDichVuService chidinhservice;
        private ApplicationUserManager userManager;
        
        public ChiDinhDichVuController(IErrorService errorService, IChiDinhDichVuService _chiDinhService, ApplicationUserManager _userManager) : base(errorService)
        {
            this.chidinhservice = _chiDinhService;
            this.userManager = _userManager;
        }

        [Route("Add")]
        [HttpGet]
        [Authorize(Roles = "ChiDinhCreate")]
        public HttpResponseMessage createChiDinh(HttpRequestMessage request,ChiDinhDichVuViewModel cddvVM)
        {
            ChiDinhDichVu cddv= new ChiDinhDichVu();
            cddv.UpdateChiDinh(cddvVM);
            var listcddvct = cddvVM.listCDDVCTVM;
            List<ChiDinhDichVuChiTiet> listCDDVCT = Mapper.Map<List<ChiDinhDichVuChiTietViewModel>, List<ChiDinhDichVuChiTiet>>(listcddvct);

            if (chidinhservice.getChiDinhTheoId(cddv.MaChiDinh) == null)
            {
                chidinhservice.UpdateCDDV(cddv);
                foreach (var cd in listCDDVCT)
                {
                    chidinhservice.UpdateCDDVCT(cd);
                }      
            }
            else
            {
                chidinhservice.Add(cddv, listCDDVCT);
            }
                chidinhservice.Save();


            return request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("getchidinh")]
        [HttpGet]
        [Authorize(Roles = "ChiDinhList")]
        public HttpResponseMessage getChiDinh(HttpRequestMessage request)
        {
            var user = User.Identity.Name;
            var lvCode = userManager.FindByNameAsync(user).Result.LevelCode;
            var dataresponse = chidinhservice.GetAllDichVu(lvCode);
            return request.CreateResponse(HttpStatusCode.OK, dataresponse);
        }

        [Route("updatechidinh")]
        [HttpPut]
        [Authorize(Roles = "ChiDinhUpdate")]
        public HttpResponseMessage updateChiDinh(HttpRequestMessage request)
        {
            return request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("delete")]
        [HttpDelete]
        [Authorize(Roles = "ChiDinhDelete")]
        public HttpResponseMessage deleteChiDinh(HttpRequestMessage request,string maChiDinh)
        {
            this.chidinhservice.Delete(maChiDinh);

            return request.CreateResponse(HttpStatusCode.OK);
        }
        


    }

}