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
using Bionet.Model.Models;

namespace Bionet.API.ControllerAPI
{
    [RoutePrefix("api/mapsxnthongso")]
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
            var rs = this._mapsXNTSService.getall(makythuat);
            var response = Mapper.Map<IEnumerable<MapsXN_ThongSo>, IEnumerable<ThongSoKyThuatViewModel>>(rs);
            return request.CreateResponse(HttpStatusCode.OK,response);
        }


        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, MapsXetNghiem_ThongSoViewModel mapxnts)
        {
            foreach (var x in mapxnts.mapxnts)
            {
                MapsXN_ThongSo maps = new MapsXN_ThongSo();
                maps.RowIDMaps = 1;
                maps.TenThongSo = x.TenThongSo;
                maps.IDThongSoXN = x.IDThongSoXN;
                maps.IDKyThuatXN = mapxnts.idKyThuat;
                maps.RowIDMaps = 0;
                _mapsXNTSService.DeleteMulti(maps.IDKyThuatXN);
                _mapsXNTSService.Add(maps);
            }
            _mapsXNTSService.Save();
            return request.CreateResponse(HttpStatusCode.OK);
        }
    }
}