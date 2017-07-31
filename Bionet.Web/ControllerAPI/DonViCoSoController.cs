using Bionet.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bionet.Service.Services;
using AutoMapper;
using Bionet.Web.Models;
using Bionet.Web.Models;
using Bionet.Web.Infrastructure.Core;
using Bionet.Web.Infrastructure.Extensions;

namespace Bionet.Web.ControllerAPI
{
    [RoutePrefix("api/donvicoso")]
    [Authorize]
    public class DonViCoSoController : ApiControllerBase
    {
        private IDonViCoSoService donViCoSoService;
        private IDanhMucChiCucService chiCucService;

        public DonViCoSoController(IErrorService errorService, IDonViCoSoService _donViCoSoService, IDanhMucChiCucService _chiCucService) : base(errorService)
        {
            this.donViCoSoService = _donViCoSoService;
            this.chiCucService = _chiCucService;
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        [Authorize(Roles = "DonViCoSoEdit")]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = donViCoSoService.GetById(id);

                var chicuc = this.chiCucService.GetAll();
                var responseData = Mapper.Map<DanhMucDonViCoSo, DanhMucDonViCoSoViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getallDonVi")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = this.donViCoSoService.GetAll();
                var responseData = model;
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("getall")]
        [Authorize(Roles = "DonViCoSoList")]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20, string MaTT = "")
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                IEnumerable<DanhMucDonViCoSo> model = new List<DanhMucDonViCoSo>();
                if(!string.IsNullOrEmpty(MaTT))
                    model = donViCoSoService.GetAllByMaTT(MaTT);
                else
                    model = donViCoSoService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.Stt).Skip(page * pageSize).Take(pageSize);
                var chicuc = this.chiCucService.GetAll();
                var responseData = Mapper.Map<IEnumerable<DanhMucDonViCoSo>, IEnumerable<DanhMucDonViCoSoViewModel>>(query).Select(x => { x.TenChiCuc = chicuc.First(n => n.MaChiCuc == x.MaChiCuc).TenChiCuc; return x; }).ToList();

                var paginationSet = new PaginationSet<DanhMucDonViCoSoViewModel>()
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
        [Authorize(Roles = "DonViCoSoCreate")]
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
        [Authorize(Roles = "DonViCoSoCreate")]
        public HttpResponseMessage Create(HttpRequestMessage request, DanhMucDonViCoSoViewModel donviVm)
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
                    if (donviVm.isLocked == null)
                        donviVm.isLocked = false;
                    var newDonVi= new DanhMucDonViCoSo();
                    newDonVi.UpdateDonViCoSo(donviVm);
                    donViCoSoService.Add(newDonVi);
                    donViCoSoService.Save();

                    var responseData = Mapper.Map<DanhMucDonViCoSo, DanhMucDonViCoSoViewModel>(newDonVi);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("update")]
        [Authorize(Roles = "DonViCoSoEdit")]
        public HttpResponseMessage Put(HttpRequestMessage request, DanhMucDonViCoSoViewModel donviVm)
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
                    var donViDb = donViCoSoService.GetById(donviVm.RowIDDVCS);
                    donViDb.UpdateDonViCoSo(donviVm);
                    donViCoSoService.Update(donViDb);
                    donViCoSoService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }

        [Route("delete")]
        [Authorize(Roles = "DonViCoSoDelete")]
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
                    donViCoSoService.Delete(id);
                    donViCoSoService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}
