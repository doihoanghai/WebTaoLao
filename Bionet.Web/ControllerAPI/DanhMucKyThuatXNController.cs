using AutoMapper;
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
    [RoutePrefix("api/dmkythuatxn")]
    [Authorize]
    public class DanhMucKyThuatXNController : ApiControllerBase
    {
        private IDanhMucKyThuatXNService dmKyThuatXNService;

        public DanhMucKyThuatXNController(IDanhMucKyThuatXNService _dmKyThuatXNService, IErrorService errorService) : base(errorService)
        {
            this.dmKyThuatXNService = _dmKyThuatXNService;
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        [Authorize(Roles = "DanhMucKyThuatXNEdit")]
        public HttpResponseMessage GetById(HttpRequestMessage request, string id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = dmKyThuatXNService.GetById(id);

                var responseData = Mapper.Map<DanhMucKyThuatXN, DanhMucKyThuatXNViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getall")]
      [Authorize(Roles = "ThongSoXNList")]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = dmKyThuatXNService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.STT).Skip(page * pageSize).Take(pageSize);
                var responseData = Mapper.Map<IEnumerable<DanhMucKyThuatXN>, IEnumerable<DanhMucKyThuatXNViewModel>>(query);
                var paginationSet = new PaginationSet<DanhMucKyThuatXNViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }
        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        [Authorize(Roles = "KyThuatXNCreate")]
        public HttpResponseMessage Create(HttpRequestMessage request, DanhMucKyThuatXNViewModel dmKyThuatXNVM)
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
                    var newKyThuat = new DanhMucKyThuatXN();
                    newKyThuat.UpdateKyThuatXN(dmKyThuatXNVM);
                    dmKyThuatXNService.Create(newKyThuat);
                    dmKyThuatXNService.Save();

                    var responseData = Mapper.Map<DanhMucKyThuatXN, DanhMucKyThuatXNViewModel>(newKyThuat);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("update")]
        [Authorize(Roles = "KyThuatXNEdit")]
        public HttpResponseMessage Put(HttpRequestMessage request, DanhMucKyThuatXNViewModel dmKyThuatXNVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                //    var kythuatXNDb = dmKyThuatXNService.GetById(dmKyThuatXNVM.IDKyThuatXN);
                //    kythuatXNDb.UpdateThongSoXN(dmKyThuatXNVM);
                // //   danhMucThongSoXNService.Update(dmKyThuatXNVM);
                //    danhMucThongSoXNService.Save();

                //    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }

    }
}
