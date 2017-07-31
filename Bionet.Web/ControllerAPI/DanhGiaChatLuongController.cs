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
    [RoutePrefix("api/danhgiachatluong")]
    [Authorize]
    public class DanhGiaChatLuongController : ApiControllerBase
    {
        private IDanhGiaChatLuongService danhGiaChatLuongService;
        public DanhGiaChatLuongController(IErrorService errorService, IDanhGiaChatLuongService _danhGiaChatLuongService) : base(errorService)
        {
            this.danhGiaChatLuongService = _danhGiaChatLuongService;
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        [Authorize(Roles = "DanhGiaChatLuongEdit")]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = danhGiaChatLuongService.GetById(id);
                var responseData = model;

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getallDanhGiaChatLuong")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = this.danhGiaChatLuongService.GetAll();
                var responseData = model;
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("getall")]
        [Authorize(Roles = "DanhGiaChatLuongList")]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = danhGiaChatLuongService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.RowIDChatLuongMau).Skip(page * pageSize).Take(pageSize);
                var responseData = query;

                var paginationSet = new PaginationSet<DanhMucDanhGiaChatLuongMau>()
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
        [Authorize(Roles = "DanhGiaChatLuongCreate")]
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
        [Authorize(Roles = "DanhGiaChatLuongCreate")]
        public HttpResponseMessage Create(HttpRequestMessage request, DanhMucDanhGiaChatLuongViewModel DanhGiaChatLuongVm)
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
                    if (DanhGiaChatLuongVm.isLocked == null)
                        DanhGiaChatLuongVm.isLocked = false;
                    var newDanhGiaChatLuong = new DanhMucDanhGiaChatLuongMau();
                    newDanhGiaChatLuong.UpdateDanhGiaChatLuong(DanhGiaChatLuongVm);
                    danhGiaChatLuongService.Add(newDanhGiaChatLuong);
                    danhGiaChatLuongService.Save();

                    var responseData = Mapper.Map<DanhMucDanhGiaChatLuongMau, DanhMucDanhGiaChatLuongViewModel>(newDanhGiaChatLuong);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("update")]
        [Authorize(Roles = "DanhGiaChatLuongEdit")]
        public HttpResponseMessage Put(HttpRequestMessage request, DanhMucDanhGiaChatLuongViewModel DanhGiaChatLuongVm)
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
                    var DanhGiaChatLuongDb = danhGiaChatLuongService.GetById(DanhGiaChatLuongVm.RowIDChatLuongMau);
                    DanhGiaChatLuongDb.UpdateDanhGiaChatLuong(DanhGiaChatLuongVm);
                    danhGiaChatLuongService.Update(DanhGiaChatLuongDb);
                    danhGiaChatLuongService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }

        [Route("delete")]
        [Authorize(Roles = "DanhGiaChatLuongDelete")]
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
                    danhGiaChatLuongService.Delete(id);
                    danhGiaChatLuongService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}
