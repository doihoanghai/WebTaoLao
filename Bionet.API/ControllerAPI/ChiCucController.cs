﻿using AutoMapper;
using Bionet.Common.Exceptions;
using Bionet.API.Models;
using Bionet.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bionet.API.Infrastructure;
using Bionet.API.Infrastructure.Core;
using Bionet.API.Infrastructure.Extensions;
using Bionet.Web.Models;
using System.Web;
using Newtonsoft.Json;

namespace Bionet.API.ControllerAPI
{
    [RoutePrefix("api/chicuc")]
    [Authorize]
    public class ChiCucController : ApiControllerBase
    {
        private IDanhMucChiCucService chiCucService;
        private ITrungTamService trungTamService;
        private ApplicationUserManager userManager;

        public ChiCucController(IErrorService errorService, IDanhMucChiCucService _chiCucService, ITrungTamService _trungTamService, ApplicationUserManager _userManager)
            : base(errorService)
        {
            this.chiCucService = _chiCucService;
            this.trungTamService = _trungTamService;
            this.userManager = _userManager;
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        [Authorize(Roles = "ChiCucEdit")]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = chiCucService.GetById(id);

                var trungtam = this.trungTamService.GetAll();
                var responseData = Mapper.Map<DanhMucChiCuc , DanhMucChiCucViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getallChiCuc")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var user = HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name;
                var lvCode = userManager.FindByNameAsync(user).Result.LevelCode;

                var model = this.chiCucService.GetAll(lvCode);
                var responseData = model;
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("getallChiCucTheoTrungTam")]
        public HttpResponseMessage GetAllTheoTrungTam(HttpRequestMessage request,string maTrumTam)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = this.chiCucService.GetAllByMaTT(maTrumTam);
                var responseData = model;
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("getall")]
        [Authorize(Roles = "ChiCucList")]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20, string MaTT = "")
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var userName = HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name;
                var user = userManager.FindByNameAsync(userName).Result;
                
            
                var model = chiCucService.GetAll(user.LevelCode);
                if(keyword != null)
                {
                    model = model.Where(x => x.MaChiCuc.ToLower().Contains(keyword.ToLower()) ||
                        (x.TenChiCuc != null && x.TenChiCuc.ToLower().Contains(keyword.ToLower())) ||
                        (x.SdtChiCuc != null && x.SdtChiCuc.Contains(keyword)) ); 
                }
                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.Stt).Skip(page * pageSize).Take(pageSize);
                var trungtam = this.trungTamService.GetAll();
                var responseData = Mapper.Map<IEnumerable<DanhMucChiCuc>, IEnumerable<DanhMucChiCucViewModel>>(query).Select(x => { x.TenTTSL = trungtam.First(n => n.MaTTSL == x.MaTrungTam).TenTTSL; return x; }).ToList();

                var paginationSet = new PaginationSet<DanhMucChiCucViewModel>()
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
        [Authorize(Roles = "ChiCucCreate")]
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
            DanhMucChiCucViewModel chicucVm = JsonConvert.DeserializeObject<DanhMucChiCucViewModel>(jsonContent);

            var userName = HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name;
            var user = userManager.FindByNameAsync(userName).Result;

            if(chicucVm.MaChiCuc.Contains(user.LevelCode) && chicucVm.MaChiCuc == user.LevelCode)
            {
                var chiCucDb = chiCucService.GetByMa(chicucVm.MaChiCuc);
                if(chiCucDb != null)
                {
                    return Create(request, chicucVm);
                }
                else
                {
                    return Put(request, chicucVm);

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
        [Authorize(Roles = "ChiCucCreate")]
        public HttpResponseMessage Create(HttpRequestMessage request, DanhMucChiCucViewModel chicucVm)
        { 
            if (ModelState.IsValid)
            {
                try
                {
                    if (chicucVm.isLocked == null)
                        chicucVm.isLocked = false;
                    var newChiCuc = new DanhMucChiCuc();
                    newChiCuc.UpdateChiCuc(chicucVm);
                    chiCucService.Add(newChiCuc);
                    chiCucService.Save();

                    var responseData = Mapper.Map<DanhMucChiCuc, DanhMucChiCucViewModel>(newChiCuc);
                    return request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                catch (NameDuplicatedException dex)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, dex.Message);
                }
                catch (Exception ex)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

        }

        [Route("update")]
        [HttpPost]
        [Authorize(Roles = "ChiCucEdit")]

        public HttpResponseMessage Put(HttpRequestMessage request, DanhMucChiCucViewModel chicucVm)
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
                    var chiCucDb = chiCucService.GetById(chicucVm.RowIDChiCuc);
                    chiCucDb.UpdateChiCuc(chicucVm);
                    chiCucService.Update(chiCucDb);
                    chiCucService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }

        [Route("delete")]
        [Authorize(Roles = "ChiCucDelete")]
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
                    chiCucService.Delete(id);
                    chiCucService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }

    }
}
