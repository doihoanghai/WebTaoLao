using AutoMapper;
using System.Collections.Generic;
using Bionet.Web.Models;
using Bionet.Service.Services;
using Bionet.Web.Infrastructure;
using Bionet.Web.Models;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using System.Linq;
using Bionet.Web.Infrastructure.Core;
using System;
using Bionet.Web.Infrastructure.Extensions;

namespace Bionet.Web.ControllerAPI
{
    [RoutePrefix("api/dichvu")]
//    [Authorize]
    public class DichVuController : ApiControllerBase
    {
        private IDanhMucDichVuService dichVuService;
        private INhomService nhomService;
        

        public DichVuController(IErrorService errorService, IDanhMucDichVuService _dichVuService, INhomService _nhomService)
            : base(errorService)
        {
            this.dichVuService = _dichVuService;
            this.nhomService = _nhomService;
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        [Authorize(Roles = "DichVuEdit")]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = dichVuService.GetById(id);

                var responseData = Mapper.Map<DanhMucDichVu, DanhMucDichVuViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getallDichVu")]
        public HttpResponseMessage getallDichVu(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = this.dichVuService.GetAll();
                var responseData = model;
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("getall")]
//        [Authorize(Roles = "DichVuList")]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = this.dichVuService.GetAll();

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.IDDichVu).Skip(page * pageSize).Take(pageSize);
                var nhom = nhomService.GetAll();
                
                var responseData = Mapper.Map<IEnumerable<DanhMucDichVu>, IEnumerable<DanhMucDichVuViewModel>>(query).Select(x => { x.TenNhom = nhom.First(n => n.RowIDNhom == x.MaNhom).TenNhom; return x; }).ToList();
                //var a = responseData.Select(x => { x.TenNhom = ""; return x; }).ToList();

                var paginationSet = new PaginationSet<DanhMucDichVu>()
                {
                    Items = model,
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
        [Authorize(Roles = "DichVuCreate")]
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
        [Authorize(Roles = "DichVuCreate")]
        public HttpResponseMessage Create(HttpRequestMessage request, DanhMucDichVuViewModel dichvuVm)
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
                    var newDichVu = new DanhMucDichVu();
                    newDichVu.UpdateDichVu(dichvuVm);

                    dichVuService.Add(newDichVu);
                    dichVuService.Save();

                    var responseData = Mapper.Map<DanhMucDichVu, DanhMucDichVuViewModel>(newDichVu);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("update")]
        [Authorize(Roles = "DichVuEdit")]
        public HttpResponseMessage Put(HttpRequestMessage request, DanhMucDichVuViewModel dichvuVm)
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
                    var dichvuDb = dichVuService.GetById(dichvuVm.RowIDDichVu);
                    dichvuDb.UpdateDichVu(dichvuVm);
                    dichVuService.Update(dichvuDb);
                    dichVuService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }

        [Route("delete")]
        [Authorize(Roles = "DichVuDelete")]
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
                    dichVuService.Delete(id);
                    dichVuService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}
