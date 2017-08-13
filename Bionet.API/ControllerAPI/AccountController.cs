using AutoMapper;
using Bionet.Service.Services;
using Bionet.API.Infrastructure;
using Microsoft.AspNet.Identity.Owin;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Bionet.API.Models;
using Bionet.Web.Models;

namespace Bionet.API.ControllerAPI
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiControllerBase
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, IErrorService errorService) : base(errorService)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [Route("detail/{userName}")] 
        [HttpGet]
        public HttpResponseMessage Details(HttpRequestMessage request, string userName,string password)
        {
            if (string.IsNullOrEmpty(userName))
            {

                return request.CreateErrorResponse(HttpStatusCode.BadRequest, nameof(userName) + " không có giá trị.");
            }
            var user = _userManager.FindAsync(userName,password);
            
            if (user == null)
            {
                return request.CreateErrorResponse(HttpStatusCode.NoContent, "Không có dữ liệu");
            }
            else
            {
                var applicationUserViewModel = Mapper.Map<ApplicationUser, ApplicationUserViewModel>(user.Result);
                return request.CreateResponse(HttpStatusCode.OK, applicationUserViewModel);
            }

        }

        

        //[HttpGet]
        //[AllowAnonymous]
        //[Route("getall")]
        //public async Task<HttpResponseMessage> GetAll(HttpRequestMessage request)
        //{
        //    var result = await SignInManager.PasswordSignInAsync("admin", "123456$", true, shouldLockout: false);
        //    return request.CreateResponse(HttpStatusCode.OK, result);
        //}

        [HttpGet]
        [Route("login")]
        public async Task<HttpResponseMessage> Login(HttpRequestMessage request, string userName, string password)
        {
            if (!ModelState.IsValid)
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            var result = await SignInManager.UserManager.FindAsync(userName, password);
            return request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("logout")]
        public HttpResponseMessage Logout(HttpRequestMessage request)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            
            return request.CreateResponse(HttpStatusCode.OK, new { success = true });
        }


    }
}
