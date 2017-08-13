using Bionet.Service.Services;
using Bionet.API.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using Bionet.Web.Models;
using Bionet.API.Infrastructure.Core;
using AutoMapper;
using Bionet.API.Infrastructure.Extensions;
using Bionet.API.Models;
using Newtonsoft.Json;

namespace Bionet.API.ControllerAPI
{
    [RoutePrefix("api/goidichvuchung")]
    [Authorize]
    public class GoiDichVuChungController : ApiControllerBase
    {
        private IGoiDichVuChungService goiDichVuChungService;
        private IGoiDichVuDVCSService goiDichVuDVCSService;
        private IGoiDichVuTheoTrungTamService goiDichVuTrungTamService;
        private ApplicationUserManager userManager;

        public GoiDichVuChungController(IErrorService errorService, IGoiDichVuChungService _goiDichVuChungService, ApplicationUserManager _userManager, IGoiDichVuDVCSService _goiDichVuDVCSService, IGoiDichVuTheoTrungTamService _goiDichVuTheoTT) : base(errorService)
        {
            this.goiDichVuChungService = _goiDichVuChungService;
            userManager = _userManager;
            goiDichVuDVCSService = _goiDichVuDVCSService;
            goiDichVuTrungTamService = _goiDichVuTheoTT;
        }
        //get list gói dịch vụ đơn vị cơ sở
        [Route("getallGoiDVCS")]
        public HttpResponseMessage getlistGoiDVCS(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var user = HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name;
                var lvCode = userManager.FindByNameAsync(user).Result.LevelCode;
                var model = this.goiDichVuDVCSService.GetAllTheoMaDonVi(lvCode);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.RowIDGoiDichVuTrungTam).Skip(page * pageSize).Take(pageSize);

                //var a = responseData.Select(x => { x.TenNhom = ""; return x; }).ToList();

                var paginationSet = new PaginationSet<DanhMucGoiDichVuDVCS>()
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

        //Update list gói dịch vụ dvcs
        [Route("updateMultiGoiDVCS")]
        public HttpResponseMessage updateListDVCS(HttpRequestMessage request,List<DanhMucGoiDichVuDVCS> lst)
        {
            foreach(var a in lst)
                this.goiDichVuDVCSService.addup(a);

            return request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("getallGoiDichVuTT")]
        public HttpResponseMessage GetGoiDVTT(HttpRequestMessage request, string maTT)
        {
            var goitt = goiDichVuTrungTamService.getAllTheoMaTT(maTT);
            List<string> ma = new List<string>();
            foreach (var a in goitt.ToList())
            {
                ma.Add(a.IDGoiDichVuChung);
            }

            return request.CreateResponse(HttpStatusCode.OK, goiDichVuChungService.GetAll(ma));
        }

        [Route("getallGoiDichVuDVCS")]
        public HttpResponseMessage GetGoiDVDVCS(HttpRequestMessage request, string maDVCS)
        {
            var goitt = goiDichVuDVCSService.GetAllTheoMaDonVi(maDVCS);
            List<string> ma = new List<string>();
            foreach (var a in goitt.ToList())
            {
                ma.Add(a.IDGoiDichVuChung);
            }

            return request.CreateResponse(HttpStatusCode.OK, goiDichVuChungService.GetAll(ma));
        }




        [Route("getallGoiDichVu")]
        public HttpResponseMessage GetGoiDV(HttpRequestMessage request)
        {

            var userName = HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name;
            var lvCode = userManager.FindByNameAsync(userName).Result.LevelCode;
            if (lvCode == "0" || lvCode== "1")
            {
                return request.CreateResponse(HttpStatusCode.OK, this.goiDichVuChungService.GetAll());
            }
            else
            if (lvCode.Length > 3)
            {
                var model = this.goiDichVuDVCSService.GetAllTheoMaDonVi(lvCode);
                var responseData = model;
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            }
            else
            {
                var model = this.goiDichVuTrungTamService.getAllTheoMaTT(lvCode);
                var responseData = model;
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            }
        }

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var user = HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name;
                var lvCode = userManager.FindByNameAsync(user).Result.LevelCode;
                
                 var    model = this.goiDichVuChungService.GetAll();
                
                if(keyword != null)
                {
                    model = model.Where(x => (x.IDGoiDichVuChung.Contains(keyword)) ||
                            (x.TenGoiDichVuChung != null && x.TenGoiDichVuChung.ToLower().Contains(keyword)));
                }

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.RowIDGoiDichVuChung).Skip(page * pageSize).Take(pageSize);

                //var a = responseData.Select(x => { x.TenNhom = ""; return x; }).ToList();

                var paginationSet = new PaginationSet<DanhMucGoiDichVuChung>()
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

        [Route("getbyMa/{ma}")]
        public HttpResponseMessage GetByMa(HttpRequestMessage request, string ma)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = goiDichVuChungService.getByMa(ma);

                var response = request.CreateResponse(HttpStatusCode.OK, model);

                return response;
            });
        }
        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, DanhMucGoiDichVuChungViewModel dichvuVm)
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

                    DanhMucGoiDichVuChung gdv = Mapper.Map<DanhMucGoiDichVuChungViewModel, DanhMucGoiDichVuChung>(dichvuVm);
                    this.goiDichVuChungService.Add(gdv);
                    goiDichVuChungService.Save();
                    response = request.CreateResponse(HttpStatusCode.Created, dichvuVm);
                }

                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, DanhMucGoiDichVuChungViewModel goiDVChung)
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
                    var goidichvudb = this.goiDichVuChungService.getByMa(goiDVChung.IDGoiDichVuChung);
                    goidichvudb.UpdateGoiDichVu(goiDVChung);
                    this.goiDichVuChungService.Update(goidichvudb);
                    this.goiDichVuChungService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }

        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, string ma)
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
                    goiDichVuChungService.Delete(ma);
                    goiDichVuChungService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });

        }

        [Route("AddUpFromApp")]
        [HttpPost]
        public HttpResponseMessage AddUppFromApp(HttpRequestMessage request)
        {
            HttpContent requestContent = Request.Content;
            string jsonContent = requestContent.ReadAsStringAsync().Result;
            DanhMucGoiDichVuDVCS goidvdvcsVm = JsonConvert.DeserializeObject<DanhMucGoiDichVuDVCS>(jsonContent);

            var userName = HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name;
            var user = userManager.FindByNameAsync(userName).Result;

            if (goidvdvcsVm.MaDVCS.Contains(user.LevelCode))
            {
                var term =  goiDichVuDVCSService.GetSingle(goidvdvcsVm.MaDVCS, goidvdvcsVm.IDGoiDichVuChung);
                if(term == null)
                {
                    goiDichVuDVCSService.Add(goidvdvcsVm);
                }
                else
                {
                    var rowId = term.RowIDGoiDichVuTrungTam;
                    term = goidvdvcsVm;
                    term.RowIDGoiDichVuTrungTam = rowId;

                    goiDichVuDVCSService.Update(term);
                }
                goiDichVuDVCSService.Save();
                return request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return request.CreateResponse(HttpStatusCode.NotAcceptable, "Không có quyền sửa hoặc update "+ goidvdvcsVm.MaDVCS);
            }
        }

        [Route("UpdateGoiDVTT")]
        public HttpResponseMessage updateGoiDVTT(HttpRequestMessage request, GoiDichVuTheoDonViViewModel goidvTrungTam)
        {
            goiDichVuTrungTamService.delete(goidvTrungTam.Ma);
            this.goiDichVuTrungTamService.Add(goidvTrungTam.Ma, goidvTrungTam.lstGoiDichVu);
            this.goiDichVuTrungTamService.Save();
            return request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("UpdateGoiDVDVCS")]
        public HttpResponseMessage updateGoiDVDVCS(HttpRequestMessage request, GoiDichVuTheoDonViViewModel goidvTrungTam)
        {
            goiDichVuDVCSService.delete(goidvTrungTam.Ma);
            this.goiDichVuDVCSService.Save();
            this.goiDichVuDVCSService.Add(goidvTrungTam.Ma, goidvTrungTam.lstGoiDichVu);
            this.goiDichVuDVCSService.Save();
            return request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
