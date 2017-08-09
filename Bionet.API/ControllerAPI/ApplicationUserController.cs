using AutoMapper;
using Bionet.Common.Exceptions;
using Bionet.API.Models;
using Bionet.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Bionet.API.Infrastructure;
using Bionet.API.Models;
using Bionet.API.Infrastructure.Core;
using Bionet.Web.Models;
using Bionet.API.Infrastructure.Extensions;
using Microsoft.AspNet.Identity;
using System.Web;

namespace Bionet.API.ControllerAPI
{
    [Authorize]
    [RoutePrefix("api/applicationUser")]
    public class ApplicationUserController : ApiControllerBase
    {
        private ApplicationUserManager _userManager;
        private IApplicationGroupService _appGroupService;
        private IApplicationRoleService _appRoleService;
        private IApplicationUserRoleService _applicationUserRoleService;
        private IDonViCoSoService _donViCoSoService;
        public ApplicationUserController(
            IApplicationGroupService appGroupService,
            IApplicationRoleService appRoleService,
            ApplicationUserManager userManager,
            IDonViCoSoService donViCoSoService,
            IApplicationUserRoleService applicationUserRoleService,
            IErrorService errorService)
            : base(errorService)
        {
            _appRoleService = appRoleService;
            _appGroupService = appGroupService;
            _userManager = userManager;
            _donViCoSoService = donViCoSoService;
            _applicationUserRoleService = applicationUserRoleService;
        }
        [Route("getlistpaging")]
        [HttpGet]
        [Authorize(Roles = "UserList")]
        public HttpResponseMessage GetListPaging(HttpRequestMessage request, int page, int pageSize, string keyword = null)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                int totalRow = 0;
                var model = _userManager.Users;
                
                IEnumerable<ApplicationUserViewModel> modelVm = Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<ApplicationUserViewModel>>(model.Where(p => p.UserLevel<4));
                if(keyword != null)
                {
                    modelVm = modelVm.Where(x => (x.UserName.ToLower().Contains(keyword.ToLower())) ||
                                    (x.FullName != null && x.FullName.ToLower().Contains(keyword.ToLower())) ||
                                    (x.Email != null && x.Email.Contains(keyword)) ||
                                    (x.PhoneNumber != null && x.PhoneNumber.Contains(keyword)));
                }

                PaginationSet<ApplicationUserViewModel> pagedSet = new PaginationSet<ApplicationUserViewModel>()
                {
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize),
                    Items = modelVm
                };

                response = request.CreateResponse(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }

        [Route("detail/{id}")]
        [HttpGet]
        [Authorize(Roles = "UserEdit")]
        public HttpResponseMessage Details(HttpRequestMessage request, string id)
        {
            if (string.IsNullOrEmpty(id))
            {

                return request.CreateErrorResponse(HttpStatusCode.BadRequest, nameof(id) + " không có giá trị.");
            }
            var user = _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return request.CreateErrorResponse(HttpStatusCode.NoContent, "Không có dữ liệu");
            }
            else
            {
                var applicationUserViewModel = Mapper.Map<ApplicationUser, ApplicationUserViewModel>(user.Result);
                var listGroup = _appGroupService.GetListGroupByUserId(applicationUserViewModel.Id);
                applicationUserViewModel.Groups = Mapper.Map<IEnumerable<ApplicationGroup>, IEnumerable<ApplicationGroupViewModel>>(listGroup);
                applicationUserViewModel.BirthDay = Convert.ToDateTime(applicationUserViewModel.BirthDay).ToString("dd/MM/yyyy");
                return request.CreateResponse(HttpStatusCode.OK, applicationUserViewModel);
            }

        }

        [Route("checkauthencreate")]
        [HttpGet]
        [Authorize(Roles = "UserCreate")]
        public HttpResponseMessage CheckAuthenCreate(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var response = request.CreateResponse(HttpStatusCode.OK);
                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        [Authorize(Roles = "UserCreate")]
        public async Task<HttpResponseMessage> Create(HttpRequestMessage request, ApplicationUserViewModel applicationUserViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var newAppUser = new ApplicationUser();
                    newAppUser.UpdateUser(applicationUserViewModel);
                    newAppUser.Id = Guid.NewGuid().ToString();
                    var result = await _userManager.CreateAsync(newAppUser, applicationUserViewModel.Password);
                    _appGroupService.Save();
                    return request.CreateResponse(HttpStatusCode.OK, applicationUserViewModel);
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

        [HttpPut]
        [Route("update")]
        [Authorize(Roles = "UserEdit")]
        public async Task<HttpResponseMessage> Update(HttpRequestMessage request, ApplicationUserViewModel applicationUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var appUser = await _userManager.FindByIdAsync(applicationUserViewModel.Id);
                try
                {
                    if(applicationUserViewModel.Password != null)
                        applicationUserViewModel.Password = _userManager.PasswordHasher.HashPassword(applicationUserViewModel.Password);
                    appUser.UpdateUser(applicationUserViewModel);
                    await _userManager.UpdateAsync(appUser);
                    _appGroupService.Save();
                    return request.CreateResponse(HttpStatusCode.OK, applicationUserViewModel);
                }
                catch (NameDuplicatedException dex)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, dex.Message);
                }
            }
            else
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpDelete]
        [Route("delete")]
        [Authorize(Roles = "UserDelete")]
        public async Task<HttpResponseMessage> Delete(HttpRequestMessage request, string id)
        {
            var appUser = await _userManager.FindByIdAsync(id);
            var result = await _userManager.DeleteAsync(appUser);
            if (result.Succeeded)
                return request.CreateResponse(HttpStatusCode.OK, id);
            else
                return request.CreateErrorResponse(HttpStatusCode.OK, string.Join(",", result.Errors));
        }

        [Route("getRoleByUser/{id}")]
        [HttpGet]
        [Authorize(Roles = "RoleUser")]
        public HttpResponseMessage GetRoleByUser(HttpRequestMessage request, string id)
        {
            if (string.IsNullOrEmpty(id))
            {

                return request.CreateErrorResponse(HttpStatusCode.BadRequest, nameof(id) + " không có giá trị.");
            }
            var user = _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return request.CreateErrorResponse(HttpStatusCode.NoContent, "Không có dữ liệu");
            }
            else
            {
                var applicationUserViewModel = Mapper.Map<ApplicationUser, ApplicationUserViewModel>(user.Result);

                var listRole = _appRoleService.GetListRoleByUser(id);

                applicationUserViewModel.Roles = Mapper.Map<IEnumerable<ApplicationRole>, IEnumerable<ApplicationRoleViewModel>>(listRole);
                return request.CreateResponse(HttpStatusCode.OK, applicationUserViewModel);
            }

        }

        [HttpPut]
        [Route("updateUserRole")]
        public async Task<HttpResponseMessage> UpdateUserRole(HttpRequestMessage request, ApplicationUserViewModel applicationUserViewModel)
        {
            if (ModelState.IsValid && applicationUserViewModel.UserLevel>0)
            {
                try
                {
                    this._applicationUserRoleService.Delete(applicationUserViewModel.Id);

                    IList<string> listRoleByUser = await _userManager.GetRolesAsync(applicationUserViewModel.Id);
                    foreach(var role in listRoleByUser)
                    {
                        await _userManager.RemoveFromRoleAsync(applicationUserViewModel.Id, role.ToString());
                    }
                    var listRole = applicationUserViewModel.Roles;
                    foreach (var role in listRole)
                    {
                        ApplicationUserRole userRole = new ApplicationUserRole();
                        userRole.UserId = applicationUserViewModel.Id;
                        userRole.RoleId = role.Id;
                        this._applicationUserRoleService.Add(userRole);
                        await _userManager.AddToRoleAsync(applicationUserViewModel.Id, role.Name);
                    }
                    this._applicationUserRoleService.Save();
                    return request.CreateResponse(HttpStatusCode.OK, applicationUserViewModel);
                }
                catch (NameDuplicatedException dex)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, dex.Message);
                }
            }
            else
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpPut]
        [Route("changepassword")]
        public async Task<HttpResponseMessage> UpdatePassword(HttpRequestMessage request, AccountViewModel account)
        {
            if (ModelState.IsValid)
            {
                var appUser = await _userManager.FindAsync(account.Username, account.PasswordOld);
                try
                {
                    if (appUser != null)
                    {
                        await _userManager.ChangePasswordAsync(appUser.Id, account.PasswordOld, account.PasswordNew);
                        return request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        throw new NameDuplicatedException("Mật khẩu không đúng");
                    }
                }
                catch (NameDuplicatedException dex)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, dex.Message);
                }
            }
            else
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

       

    }
}
