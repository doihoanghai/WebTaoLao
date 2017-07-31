using Bionet.Data.Infrastructure;
using Bionet.Data.Repositories;
using Bionet.API.Models;
using Bionet.Service.Services;
using Bionet.API.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bionet.API.ControllerAPI
{
    [RoutePrefix("api/employee")]
    [Authorize]
    public class EmployeeController : ApiControllerBase
    {
        private IEmployeeService employeeService;

        public EmployeeController(IErrorService errorService, IEmployeeService _employeeService) : base(errorService)
        {
            this.employeeService = _employeeService;
        }

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = employeeService.GetAll();
                var responseData = model;
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
    }
}
