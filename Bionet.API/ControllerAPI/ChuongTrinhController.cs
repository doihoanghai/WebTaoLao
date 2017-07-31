using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bionet.Service.Services;
using AutoMapper;
using Bionet.API.Models;
using Bionet.API.Infrastructure;
using Bionet.API.Infrastructure.Core;
using Bionet.API.Models;
using Bionet.API.Infrastructure.Extensions;
using Bionet.Web.Models;

namespace Bionet.API.ControllerAPI
{
    [RoutePrefix("api/chuongtrinh")]
//    [Authorize]
    public class ChuongTrinhController : ApiControllerBase
    {
        private IDanhMucChuongTrinhService danhMucChuongTrinhService;
        public ChuongTrinhController(IErrorService errorService, IDanhMucChuongTrinhService _danhMucChuongTrinhService) : base(errorService)
        {
            this.danhMucChuongTrinhService = _danhMucChuongTrinhService;
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        [Authorize(Roles = "ChuongTrinhEdit")]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = danhMucChuongTrinhService.GetById(id);

                //DanhMucChuongTrinhViewModel chuongtrinhVm = new DanhMucChuongTrinhViewModel();
                //chuongtrinhVm.RowIDChuongTrinh = model.RowIDChuongTrinh;
                //chuongtrinhVm.IDChuongTrinh = model.TenChuongTrinh;
                //chuongtrinhVm.TenChuongTrinh = model.TenChuongTrinh;
                //chuongtrinhVm.Ngaytao = model.Ngaytao != null ? Convert.ToDateTime(model.Ngaytao).ToString("dd/MM/yyyy"): string.Empty;
                //chuongtrinhVm.NgayHetHieuLuc = model.NgayHetHieuLuc != null ? Convert.ToDateTime(model.NgayHetHieuLuc).ToString("dd/MM/yyyy") : string.Empty;
                //chuongtrinhVm.isLocked = model.isLocked;
                var responseData = model;

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

      
        [Route("getallChuongTrinh")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = this.danhMucChuongTrinhService.GetAll();
                var responseData = model;
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("getall")]
        [Authorize(Roles = "ChuongTrinhList")]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = danhMucChuongTrinhService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.RowIDChuongTrinh).Skip(page * pageSize).Take(pageSize);
                var responseData = query;
                
                var paginationSet = new PaginationSet<DanhMucChuongTrinh>()
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
        [Authorize(Roles = "ChuongTrinhCreate")]
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
        [Authorize(Roles = "ChuongTrinhCreate")]
        public HttpResponseMessage Create(HttpRequestMessage request, DanhMucChuongTrinhViewModel chuongtrinh)
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
                    if (chuongtrinh.isLocked == null)
                        chuongtrinh.isLocked = false;
                    var newChuongTrinh = new DanhMucChuongTrinh();
                    newChuongTrinh.UpdateChuongTrinh(chuongtrinh);
                    danhMucChuongTrinhService.Add(newChuongTrinh);
                    danhMucChuongTrinhService.Save();

                    var responseData = Mapper.Map<DanhMucChuongTrinh, DanhMucChuongTrinhViewModel>(newChuongTrinh);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("update")]
        [Authorize(Roles = "ChuongTrinhEdit")]
        public HttpResponseMessage Put(HttpRequestMessage request, DanhMucChuongTrinhViewModel chuongTrinhVm)
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
                    var chuongtrinhDb = danhMucChuongTrinhService.GetById(chuongTrinhVm.RowIDChuongTrinh);
                    chuongtrinhDb.UpdateChuongTrinh(chuongTrinhVm);
                    danhMucChuongTrinhService.Update(chuongtrinhDb);
                    danhMucChuongTrinhService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }

        [Route("delete")]
        [Authorize(Roles = "ChuongTrinhDelete")]
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
                    danhMucChuongTrinhService.Delete(id);
                    danhMucChuongTrinhService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}
