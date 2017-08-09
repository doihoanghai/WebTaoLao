using AutoMapper;
using System.Collections.Generic;
using Bionet.API.Models;
using Bionet.Service.Services;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using System.Linq;
using System;
using Bionet.API.Infrastructure;
using Bionet.API.Models;
using Bionet.API.Infrastructure.Core;
using Bionet.API.Infrastructure.Extensions;
using Bionet.Web.Models;
using System.Web;

namespace Bionet.API.ControllerAPI
{
    [RoutePrefix("api/dichvu")]
    [Authorize]
    public class DichVuController : ApiControllerBase
    {
        private IDanhMucDichVuService dichVuService;
        private INhomService nhomService;
        private ApplicationUserManager userManager;
        

        public DichVuController(IErrorService errorService, IDanhMucDichVuService _dichVuService, INhomService _nhomService, ApplicationUserManager _userManager)
            : base(errorService)
        {
            this.dichVuService = _dichVuService;
            this.nhomService = _nhomService;
            this.userManager = _userManager;
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
                var user = HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name;
                var lvCode = userManager.FindByNameAsync(user).Result.LevelCode;
                var model = this.dichVuService.GetAll();
                var responseData = model;
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("getall")]
        [Authorize(Roles = "DichVuList")]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var user = HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name;
                var lvCode = userManager.FindByNameAsync(user).Result.LevelCode;
                var model = this.dichVuService.GetAll();

                if(keyword != null)
                {
                    model = model.Where(x => (x.IDDichVu.Contains(keyword)) ||
                            (x.TenDichVu != null && x.TenDichVu.ToLower().Contains(keyword.ToLower())) ||
                            (x.TenHienThiDichVu != null && x.TenHienThiDichVu.ToLower().Contains(keyword.ToLower())));
                }

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
