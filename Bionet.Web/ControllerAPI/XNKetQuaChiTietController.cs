using Bionet.Data.Infrastructure;
using Bionet.Data.Repositories;
using Bionet.Web.Models;
using Bionet.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Bionet.Web.Models;
using System.Web.Http;
using Bionet.Web.Infrastructure.Extensions;

namespace Bionet.Web.ControllerAPI
{
    [RoutePrefix("api/xnketquachitiet")]
    [Authorize]
    public class XNKetQuaChiTietController : ApiController
    {
        private IXN_KetQua_ChiTietService xN_KetQua_ChiTietService;
        public XNKetQuaChiTietController()
        {
            var dbFactory = new DbFactory();
            var objRepository = new XN_KetQua_ChiTietRepository(dbFactory);
            var unitOfWork = new UnitOfWork(dbFactory);
            this.xN_KetQua_ChiTietService = new XN_KetQua_ChiTietService(objRepository, unitOfWork);
        }

        [Route("Create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request,XN_KetQua_ChiTietViewModel _xN_KetQua_ChiTietViewModel)
        {
            HttpResponseMessage response = null;
            if (!ModelState.IsValid)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                var ketQua = new XN_KetQua_ChiTiet();
                ketQua.UpdateKChiTietKQXN(_xN_KetQua_ChiTietViewModel);

                this.xN_KetQua_ChiTietService.AddUpd(ketQua);
                foreach (var chitietVm in _xN_KetQua_ChiTietViewModel.lstKetQuaChiTiet)
                {
                    var ketQuaChiTiet = new XN_KetQua_ChiTiet();
                    ketQuaChiTiet.UpdateXN_KetQuaChiTiet(chitietVm);
                    this.xN_KetQua_ChiTietService.AddUpd(ketQuaChiTiet);
                }
                this.xN_KetQua_ChiTietService.Save();
                response = request.CreateResponse(HttpStatusCode.Created);
            }

            return response;
        }

        [Route("getall")]
        public IEnumerable<XN_KetQua_ChiTiet> GetAll()
        {
            return this.xN_KetQua_ChiTietService.GetAll();
        }
    }
}
