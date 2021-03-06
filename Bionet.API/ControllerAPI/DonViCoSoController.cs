﻿using Bionet.API.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bionet.Service.Services;
using AutoMapper;
using Bionet.API.Models;
using Bionet.API.Infrastructure.Core;
using Bionet.API.Infrastructure.Extensions;
using Bionet.Web.Models;
using System.Web;
using Newtonsoft.Json;

namespace Bionet.API.ControllerAPI
{
    [RoutePrefix("api/donvicoso")]
    [Authorize]
    public class DonViCoSoController : ApiControllerBase
    {
        private IDonViCoSoService donViCoSoService;
        private IDanhMucChiCucService chiCucService;
        private ApplicationUserManager userManager;
        private IGoiDichVuTheoTrungTamService goidvtheotrungtamService;
        private IGoiDichVuDVCSService goidvtheodvcsService;

        public DonViCoSoController(IErrorService errorService, IDonViCoSoService _donViCoSoService, IDanhMucChiCucService _chiCucService, ApplicationUserManager _userManager, IGoiDichVuDVCSService _goidvtheodvcsService,IGoiDichVuTheoTrungTamService _goidctheotrungtamService) : base(errorService)
        {
            this.donViCoSoService = _donViCoSoService;
            this.chiCucService = _chiCucService;
            this.userManager = _userManager;
            this.goidvtheodvcsService = _goidvtheodvcsService;
            this.goidvtheotrungtamService = _goidctheotrungtamService;
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        [Authorize(Roles = "DonViCoSoEdit")]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = donViCoSoService.GetById(id);

                var responseData = Mapper.Map<DanhMucDonViCoSo, DanhMucDonViCoSoViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getallDonVi")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            var user = HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name;
            

            return CreateHttpResponse(request, () =>
            {
                var lvCode = userManager.FindByNameAsync(user).Result.LevelCode;
                var model = this.donViCoSoService.GetAll(lvCode);
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
       
                var user = HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name;

                var lvCode = userManager.FindByNameAsync(user).Result.LevelCode;
                var model = this.donViCoSoService.GetAll(lvCode);

                if(keyword != null)
                {
                    model = model.Where(x => (x.MaDVCS.Contains(keyword)) ||
                            (x.TenDVCS != null && x.TenDVCS.ToLower().Contains(keyword)) ||
                            (x.TenBacSiDaiDien != null && x.TenBacSiDaiDien.ToLower().Contains(keyword)) ||
                            (x.SDTCS != null && x.SDTCS.Contains(keyword)));
                }

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.Stt).Skip(page * pageSize).Take(pageSize);
                var chicuc = this.chiCucService.GetAll("0");
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

        [Route("AddUpFromApp")]
        [HttpPost]
        public HttpResponseMessage AddUppFromApp(HttpRequestMessage request)
        {
            HttpContent requestContent = Request.Content;
            string jsonContent = requestContent.ReadAsStringAsync().Result;
            DanhMucDonViCoSoViewModel donviVm = JsonConvert.DeserializeObject<DanhMucDonViCoSoViewModel>(jsonContent);

            var userName = HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name;
            var user = userManager.FindByNameAsync(userName).Result;

            if (donviVm.MaChiCuc.Contains(user.LevelCode) && donviVm.MaDVCS == user.LevelCode)
            {
                var chiCucDb = chiCucService.GetByMa(donviVm.MaChiCuc);
                if (chiCucDb != null)
                {
                    return Create(request, donviVm);
                }
                else
                {
                    return Put(request, donviVm);

                }
            }
            else
            {
                return request.CreateResponse(HttpStatusCode.BadRequest, "Sai mã trung tâm tại mã chi cục hoặc mã trung tâm");
            }
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

                    
                    var gdv = goidvtheotrungtamService.getAllTheoMaTT(newDonVi.MaDVCS.Substring(0, 3));
                    var gdvdvcs = Mapper.Map<IEnumerable<DanhMucGoiDichVuTrungTam>, IEnumerable<DanhMucGoiDichVuChung>>(gdv);

                    goidvtheodvcsService.Add(newDonVi.MaDVCS, gdvdvcs.ToList());
                    goidvtheodvcsService.Save();
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
