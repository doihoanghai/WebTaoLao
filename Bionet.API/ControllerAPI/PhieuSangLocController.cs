using AutoMapper;
using Bionet.Data.Infrastructure;
using Bionet.Data.Repositories;
using Bionet.API.Models;
using Bionet.Service.Services;
using Bionet.API.Infrastructure;
using Bionet.API.Infrastructure.Core;
using Bionet.API.Infrastructure.Extensions;
using Bionet.API.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bionet.Web.Models;
using System.Web;
using Newtonsoft.Json;

namespace Bionet.API.ControllerAPI
{
    [Authorize]
    [RoutePrefix("api/phieusangloc")]
    public class PhieuSangLocController : ApiControllerBase
    {
        private IPhieuSangLocService phieuSangLocService;
        private IPatientService patientService;
        private IDonViCoSoService donViCoSoService;
        private ApplicationUserManager userManager;

        public PhieuSangLocController(IErrorService errorService, IPhieuSangLocService _phieuSangLocService, IPatientService _patientService, IDonViCoSoService _donViCoSoService, ApplicationUserManager _userManager) : base(errorService)
        {
            this.phieuSangLocService = _phieuSangLocService;
            this.donViCoSoService = _donViCoSoService;
            this.patientService = _patientService;
            this.userManager = _userManager;
        }

        [Route("getphieusangloc")]
        public HttpResponseMessage GetPhieuSangLoc(HttpRequestMessage request,string maKhachHang)
        {
            Patient patient = patientService.GetByMaKH(maKhachHang);
            PhieuSangLoc psl = phieuSangLocService.GetByMaBenhNhan(patient.MaBenhNhan);

            var responseData = Mapper.Map<PhieuSangLoc, PhieuSangLocViewModel>(psl);
            responseData = Mapper.Map<Patient, PhieuSangLocViewModel>(patient, responseData);

            IFormatProvider mFomatter = new System.Globalization.CultureInfo("en-US", true);
            if (!string.IsNullOrEmpty(responseData.NgayGioLayMau))
            {
                string NgayGioLayMau = responseData.NgayGioLayMau.Substring(0, 10);
                DateTime NgayGioLayMauTime = DateTime.ParseExact(responseData.NgayGioLayMau, "dd/MM/yyyy HH:mm:ss", mFomatter);
                responseData.NgayGioLayMau = NgayGioLayMau;
                responseData.NgayGioLayMauTime = NgayGioLayMauTime;
            }
            if (!string.IsNullOrEmpty(responseData.NgayGioSinh))
            {
                string NgayGioSinh = responseData.NgayGioSinh.Substring(0, 10);
                DateTime NgayGioSinhTime = DateTime.ParseExact(responseData.NgayGioSinh, "dd/MM/yyyy HH:mm:ss", mFomatter);
                responseData.NgayGioSinh = NgayGioSinh;
                responseData.NgayGioSinhTime = NgayGioSinhTime;
            }
            if (!string.IsNullOrEmpty(responseData.MotherBirthday))
                responseData.MotherBirthday = responseData.MotherBirthday.Substring(0, 10);
            if (!string.IsNullOrEmpty(responseData.FatherBirthday))
                responseData.FatherBirthday = responseData.FatherBirthday.Substring(0, 10);
            var response = request.CreateResponse(HttpStatusCode.OK, responseData);

            return response;


        }
        
        [Route("getalldonvicoso")]
        public HttpResponseMessage GetAllDonViCoSo(HttpRequestMessage request)
        {
            
            return CreateHttpResponse(request, () =>
            {
                var userName = HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name;
                var lvCode = userManager.FindByNameAsync(userName).Result.LevelCode;
                var model = this.donViCoSoService.GetAll(lvCode);
                var responseData = model;
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("getallphieusangloc")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {

            return CreateHttpResponse(request, () =>
            {
                var userName = HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name;
                var lvCode = userManager.FindByNameAsync(userName).Result.LevelCode;
                var model = phieuSangLocService.GetAll(lvCode);
                var responseData = model;
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("getall")]
        [Authorize(Roles = "PhieuSangLocList")]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = phieuSangLocService.GetAllHasCondition(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.RowIDPhieu).Skip(page * pageSize).Take(pageSize);
                var chicuc = this.phieuSangLocService.GetAll();
                var responseData = Mapper.Map<IEnumerable<PhieuSangLoc>, IEnumerable<PhieuSangLocViewModel>>(query);

                var paginationSet = new PaginationSet<PhieuSangLocViewModel>()
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

        [Route("getbyid/{id}")]
        [HttpGet]
        [Authorize(Roles = "PhieuSangLocEdit")]
        public HttpResponseMessage GetById(HttpRequestMessage request, string id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = phieuSangLocService.GetById(id);
                var responseData = Mapper.Map<PhieuSangLoc, PhieuSangLocViewModel>(model);
                var modelPatient = patientService.GetByMaBN(model.MaBenhNhan);
                responseData = Mapper.Map<Patient, PhieuSangLocViewModel>(modelPatient, responseData);

                IFormatProvider mFomatter = new System.Globalization.CultureInfo("en-CA");
                if(!string.IsNullOrEmpty(responseData.NgayGioLayMau))
                {
                    string NgayGioLayMau = responseData.NgayGioLayMau.Substring(0, 10);
                    DateTime NgayGioLayMauTime = DateTime.Parse(responseData.NgayGioLayMau.ToString(), mFomatter);
                    responseData.NgayGioLayMau = NgayGioLayMau;
                    responseData.NgayGioLayMauTime = NgayGioLayMauTime;
                }
                if(!string.IsNullOrEmpty(responseData.NgayGioSinh))
                {
                    string NgayGioSinh = responseData.NgayGioSinh.Substring(0, 10);
                    DateTime NgayGioSinhTime = DateTime.Parse(responseData.NgayGioSinh, mFomatter);
                    responseData.NgayGioSinh = NgayGioSinh;
                    responseData.NgayGioSinhTime = NgayGioSinhTime;
                }
                if (!string.IsNullOrEmpty(responseData.MotherBirthday))
                    responseData.MotherBirthday = responseData.MotherBirthday.Substring(0, 10);
                if (!string.IsNullOrEmpty(responseData.FatherBirthday))
                    responseData.FatherBirthday = responseData.FatherBirthday.Substring(0, 10);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("AddUpFromApp")]
        [HttpPost]
        [Authorize(Roles = "PhieuSangLocEdit"]
        public HttpResponseMessage addupFromApp(HttpRequestMessage request)
        {
            HttpContent requestContent = Request.Content;
            string jsonContent = requestContent.ReadAsStringAsync().Result;
            PhieuSangLocViewModel phieuSangLocVm = JsonConvert.DeserializeObject<PhieuSangLocViewModel>(jsonContent);

            var userName = HttpContext.Current.GetOwinContext().Authentication.User.Identity.Name;
            var lvCode = userManager.FindByNameAsync(userName).Result.LevelCode;

            if (phieuSangLocVm.MaTrungTam != lvCode && !phieuSangLocVm.IDPhieu.Contains(lvCode))
            {
                return request.CreateResponse(HttpStatusCode.ExpectationFailed,"Phiếu " + phieuSangLocVm.IDPhieu + "không thuộc trung tâm " + lvCode);
            }

            HttpResponseMessage response = null;

            var phieuDB = phieuSangLocService.GetById(phieuSangLocVm.IDPhieu);
            if(phieuDB == null)
            {
                var newPhieu = new PhieuSangLoc();
                newPhieu.UpdatePhieuSangLoc(phieuSangLocVm);
                ApplicationUser user = this.userManager.FindByNameAsync(phieuSangLocVm.Username).Result;
                var lvcode = user.LevelCode;
                newPhieu.IDNhanVienTaoPhieu = user.Id;
                var newPatient = new Patient();
                newPatient.UpdatePatient(phieuSangLocVm);
                newPhieu.MaBenhNhan = lvcode[1] + lvcode[2] + Guid.NewGuid().ToString();
                newPatient.MaBenhNhan = newPhieu.MaBenhNhan;
                phieuSangLocService.Add(newPhieu);
                patientService.Add(newPatient);
                phieuSangLocService.Save();
                response = request.CreateResponse(HttpStatusCode.Created, phieuSangLocVm);
            }
            else
            {
                phieuDB.UpdatePhieuSangLoc(phieuSangLocVm);
                var patientDB = patientService.GetByMaBN(phieuSangLocVm.MaBenhNhan);
                patientDB.UpdatePatient(phieuSangLocVm);

                this.phieuSangLocService.Update(phieuDB);
                this.patientService.Update(patientDB);
                donViCoSoService.Save();

                response = request.CreateResponse(HttpStatusCode.OK);
            }
            return response;

        }

        [Route("create")]
        [HttpPost]
        [Authorize(Roles = "PhieuSangLocCreate")]
        public HttpResponseMessage Create(HttpRequestMessage request, PhieuSangLocViewModel phieuSangLocVm)
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
                   
                    var phieuDB = phieuSangLocService.GetById(phieuSangLocVm.IDPhieu);
                    if (phieuDB != null)
                    {
                        phieuDB.UpdatePhieuSangLoc(phieuSangLocVm);
                        var patientDB = patientService.GetByMaBN(phieuSangLocVm.MaBenhNhan);
                        patientDB.UpdatePatient(phieuSangLocVm);

                        this.phieuSangLocService.Update(phieuDB);
                        this.patientService.Update(patientDB);
                        donViCoSoService.Save();

                        response = request.CreateResponse(HttpStatusCode.OK);

                    }
                    else
                    {
                        var newPhieu = new PhieuSangLoc();
                        newPhieu.UpdatePhieuSangLoc(phieuSangLocVm);
                        ApplicationUser user = this.userManager.FindByNameAsync(phieuSangLocVm.Username).Result;
                        var lvcode = user.LevelCode;
                        newPhieu.IDNhanVienTaoPhieu = user.Id;
                        var newPatient = new Patient();
                        newPatient.UpdatePatient(phieuSangLocVm);
                        newPhieu.MaBenhNhan =lvcode[1]+lvcode[2]+ Guid.NewGuid().ToString();
                        newPatient.MaBenhNhan = newPhieu.MaBenhNhan;
                        phieuSangLocService.Add(newPhieu);
                        patientService.Add(newPatient);
                        phieuSangLocService.Save();
                        response = request.CreateResponse(HttpStatusCode.Created, phieuSangLocVm);
                    }
                }

                return response;
            });
        }

        [Route("update")]
        [Authorize(Roles = "PhieuSangLocEdit")]
        public HttpResponseMessage Put(HttpRequestMessage request, PhieuSangLocViewModel phieuSangLocVm)
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
                    var phieuDB = phieuSangLocService.GetById(phieuSangLocVm.IDPhieu);
                    phieuDB.UpdatePhieuSangLoc(phieuSangLocVm);
                    var patientDB = patientService.GetByMaBN(phieuSangLocVm.MaBenhNhan);
                    patientDB.UpdatePatient(phieuSangLocVm);

                    this.phieuSangLocService.Update(phieuDB);
                    this.patientService.Update(patientDB);
                    donViCoSoService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }

        [Route("checkauthencreate")]
        [HttpGet]
        [Authorize(Roles = "PhieuSangLocCreate")]
        public HttpResponseMessage CheckAuthenCreate(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var response = request.CreateResponse(HttpStatusCode.OK);
                return response;
            });
        }

    }
}
