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
    [RoutePrefix("api/trungtamsangloc")]
//    [Authorize]
    public class TrungTamController : ApiControllerBase
    {
        private ITrungTamService trungTamService;

        public TrungTamController(IErrorService errorService, ITrungTamService _trungTamService) : base(errorService)
        {
            this.trungTamService = _trungTamService;
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        [Authorize(Roles = "TrungTamEdit")]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = trungTamService.GetById(id);

                var responseData = Mapper.Map<DanhMucTrungTamSangLoc, DanhMucTrungTamSangLocViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getbyMa/{ma}")]
        public HttpResponseMessage GetByMa(HttpRequestMessage request, string ma)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = trungTamService.GetByMa(ma);

                var responseData = Mapper.Map<DanhMucTrungTamSangLoc, DanhMucTrungTamSangLocViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getallTrungTam")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = this.trungTamService.GetAll();
                var responseData = model;
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("getall")]
        [Authorize(Roles = "TrungTamList")]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = trungTamService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderBy(x => x.Stt).Skip(page * pageSize).Take(pageSize);
                var responseData = Mapper.Map<IEnumerable<DanhMucTrungTamSangLoc>, IEnumerable<DanhMucTrungTamSangLocViewModel>>(query);
                var paginationSet = new PaginationSet<DanhMucTrungTamSangLocViewModel>()
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
//        [Authorize(Roles = "TrungTamCreate")]
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
        [Authorize(Roles = "TrungTamCreate")]
        public HttpResponseMessage Create(HttpRequestMessage request, DanhMucTrungTamSangLocViewModel trungTamSangLocVm)
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
                    if (trungTamSangLocVm.isLocked == null)
                        trungTamSangLocVm.isLocked = false;
                    trungTamSangLocVm.MaTongCuc = 1;
                    var newTrungTam = new DanhMucTrungTamSangLoc();
                    newTrungTam.UpdateTrungTamSL(trungTamSangLocVm);
                    trungTamService.Add(newTrungTam);
                    trungTamService.Save();

                    var responseData = Mapper.Map<DanhMucTrungTamSangLoc, DanhMucTrungTamSangLocViewModel>(newTrungTam);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("update")]
        [Authorize(Roles = "TrungTamEdit")]
        public HttpResponseMessage Put(HttpRequestMessage request, DanhMucTrungTamSangLocViewModel trungTamSangLocVm)
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
                    var trungtamDb = trungTamService.GetById(trungTamSangLocVm.RowIDTTSL);
                    trungtamDb.UpdateTrungTamSL(trungTamSangLocVm);
                    trungTamService.Update(trungtamDb);
                    trungTamService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }

        [Route("delete")]
        [Authorize(Roles = "TrungTamDelete")]
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
                    trungTamService.Delete(id);
                    trungTamService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }

    }
}
