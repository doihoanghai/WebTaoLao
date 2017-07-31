using AutoMapper;
using Bionet.API.Models;
using Bionet.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bionet.API.Infrastructure;
using Bionet.API.Models;
using Bionet.API.Infrastructure.Core;
using Bionet.API.Infrastructure.Extensions;
using Bionet.Web.Models;

namespace Bionet.API.ControllerAPI
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

        [Route("getbyMa/{ma}")]
        public HttpResponseMessage GetByMa(HttpRequestMessage request, string ma)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = this.dmKyThuatXNService.GetByMa(ma);

                var responseData = Mapper.Map<DanhMucKyThuatXN, DanhMucKyThuatXNViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("checkauthencreate")]
        [HttpGet]
        public HttpResponseMessage CheckAuthenCreate(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var response = request.CreateResponse(HttpStatusCode.OK);
                return response;
            });
        }

        [Route("getall")]

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
                    var kythuatXNDb = dmKyThuatXNService.GetById(dmKyThuatXNVM.RowIDKyThuatXn.ToString());
                    kythuatXNDb.UpdateKyThuatXN(dmKyThuatXNVM);
                    this.dmKyThuatXNService.Update(kythuatXNDb);
                    this.dmKyThuatXNService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }

        [Route("delete")]
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
                    dmKyThuatXNService.Delete(id);
                    dmKyThuatXNService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }

    }
}
