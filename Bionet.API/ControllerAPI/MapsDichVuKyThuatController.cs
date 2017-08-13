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
    [RoutePrefix("api/mapsdichvukythuat")]
    [Authorize]
    public class MapsDichVuKyThuatController : ApiControllerBase
    {
        private IMapDichVuKyThuatService _mapsDVKTService;


        public MapsDichVuKyThuatController(IErrorService errorService, IMapDichVuKyThuatService mapsDVKTService)
            : base(errorService)
        {
            this._mapsDVKTService = mapsDVKTService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return request.CreateResponse(HttpStatusCode.OK, this._mapsDVKTService.getall());
        }

        [Route("getallthongsoxn")]
        [HttpGet]
        public HttpResponseMessage getallthongsoxn(HttpRequestMessage request, string maDichVu)
        {
            var rs = this._mapsDVKTService.getall(maDichVu);
            var response = Mapper.Map<IEnumerable<MapsXN_DichVu>, IEnumerable<KyThuatXNMapViewModel>>(rs);
            return request.CreateResponse(HttpStatusCode.OK, response);
        }


        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, MapsDichVu_KyThuatViewModel mapsdvkt)
        {
            _mapsDVKTService.DeleteMulti(mapsdvkt.idDichVu);
            foreach (var x in mapsdvkt.mapdvkt)
            {
                MapsXN_DichVu maps = new MapsXN_DichVu();
                maps.RowIDDichVuMaps = 1;
                maps.IDDichVu = mapsdvkt.idDichVu;
                maps.IDKyThuatXN = x.IDKyThuatXN;
                maps.TenKyThuat = x.TenKyThuat;
                _mapsDVKTService.Add(maps);
            }
            if(mapsdvkt.mapdvkt != null)
                _mapsDVKTService.Save();
            return request.CreateResponse(HttpStatusCode.OK);
        }
    }
}