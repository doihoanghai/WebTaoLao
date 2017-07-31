using AutoMapper;
using Bionet.Data.Infrastructure;
using Bionet.Data.Repositories;
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
    [RoutePrefix("api/thongsoxetnghiem")]
    [Authorize]
    public class DanhMucThongSoXNController : ApiControllerBase
    {
        private IDanhMucThongSoXNService danhMucThongSoXNService;
        private INhomService nhomService;

        public DanhMucThongSoXNController(IErrorService errorService, IDanhMucThongSoXNService _danhMucThongSoXNService, INhomService _nhomService)
            : base(errorService)
        {
            this.nhomService = _nhomService;
            this.danhMucThongSoXNService = _danhMucThongSoXNService;
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        [Authorize(Roles = "ThongSoXNEdit")]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = danhMucThongSoXNService.GetById(id);

                var responseData = Mapper.Map<DanhMucThongSoXN, DanhMucThongSoXNViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getbyMa/{ma}")]
        public HttpResponseMessage GetByMa(HttpRequestMessage request, string ma)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = danhMucThongSoXNService.GetByMa(ma);

                var responseData = Mapper.Map<DanhMucThongSoXN, DanhMucThongSoXNViewModel>(model);

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
                var model = danhMucThongSoXNService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.RowIDThongSo).Skip(page * pageSize).Take(pageSize);
                var nhom = nhomService.GetAll();
                var responseData = Mapper.Map<IEnumerable<DanhMucThongSoXN>, IEnumerable<DanhMucThongSoXNViewModel>>(query).Select(x => { x.TenNhom = nhom.First(n => n.RowIDNhom == x.MaNhom).TenNhom; return x; }).ToList();

                var paginationSet = new PaginationSet<DanhMucThongSoXNViewModel>()
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

        [Route("checkauthencreate")]
        [HttpGet]
        [Authorize(Roles = "ThongSoXNCreate")]
        public HttpResponseMessage CheckAuthenCreate(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var response = request.CreateResponse(HttpStatusCode.OK);
                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        [Authorize(Roles = "ThongSoXNCreate")]
        public HttpResponseMessage Create(HttpRequestMessage request, DanhMucThongSoXNViewModel thongsoxetnghiemVm)
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
                    if (thongsoxetnghiemVm.isLocked == null)
                        thongsoxetnghiemVm.isLocked = false;
                    var newThongSo = new DanhMucThongSoXN();
                    newThongSo.UpdateThongSoXN(thongsoxetnghiemVm);
                    danhMucThongSoXNService.Add(newThongSo);
                    danhMucThongSoXNService.Save();

                    var responseData = Mapper.Map<DanhMucThongSoXN, DanhMucThongSoXNViewModel>(newThongSo);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("update")]
        [Authorize(Roles = "ThongSoXNEdit")]
        public HttpResponseMessage Put(HttpRequestMessage request, DanhMucThongSoXNViewModel thongsoxetnghiemVm)
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
                    var thongsoxetnghiemDb = danhMucThongSoXNService.GetById(thongsoxetnghiemVm.RowIDThongSo);
                    thongsoxetnghiemDb.UpdateThongSoXN(thongsoxetnghiemVm);
                    danhMucThongSoXNService.Update(thongsoxetnghiemDb);
                    danhMucThongSoXNService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }

        [Route("delete")]
        [Authorize(Roles = "ThongSoXNDelete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
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
                    danhMucThongSoXNService.Delete(id);
                    danhMucThongSoXNService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}
