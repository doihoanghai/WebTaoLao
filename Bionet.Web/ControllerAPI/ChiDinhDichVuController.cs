using AutoMapper;
using Bionet.Common.Exceptions;
using Bionet.Web.Models;
using Bionet.Service.Services;
using Bionet.Web.Infrastructure;
using Bionet.Web.Infrastructure.Core;
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
    [RoutePrefix("api/chidinhdv")]
    [Authorize]
    public class ChiDinhDichVuController : ApiControllerBase
    {
        private IChiDinhDichVuService chidinhservice;
        private IEmployeeService employeeService;
        
        public ChiDinhDichVuController(IErrorService errorService, IChiDinhDichVuService _chiDinhService,IEmployeeService _employeeService) : base(errorService)
        {
            this.chidinhservice = _chiDinhService;
            this.employeeService = _employeeService;
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
            var lvCode = employeeService.getLvCodeByUserName(user);
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