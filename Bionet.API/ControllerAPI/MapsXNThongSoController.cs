using Bionet.API.Infrastructure;
using Bionet.Service.Services;
using Bionet.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Bionet.API.ControllerAPI
{
    [RoutePrefix("api/mapxnts")]
    [Authorize]
    public class MapsXNThongSoController : ApiControllerBase
    {
        private IMapsXNThongSoService _mapsXNTSService;
 

        public MapsXNThongSoController(IErrorService errorService, IMapsXNThongSoService mapsXNTSService)
            : base(errorService)
        {
            this._mapsXNTSService = mapsXNTSService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return request.CreateResponse(HttpStatusCode.OK, this._mapsXNTSService.getall());
        }

        [Route("getallthongsoxn")]
        [HttpGet]
        public HttpResponseMessage getallthongsoxn(HttpRequestMessage request,string makythuat)
        {
            return request.CreateResponse(HttpStatusCode.OK, this._mapsXNTSService.getall(makythuat));
        }

        [Route("update")]
        [HttpGet]
        public HttpResponseMessage update(HttpRequestMessage request,List<MapsXN_ThongSo> mapxnts)
        {
            foreach(var x in mapxnts)
            {
                _mapsXNTSService.Update(x);
            }
            _mapsXNTSService.Save();
            return request.CreateResponse(HttpStatusCode.OK);
        }
    }
}