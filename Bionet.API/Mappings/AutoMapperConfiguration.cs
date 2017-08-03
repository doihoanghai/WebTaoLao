using AutoMapper;
using Bionet.Web.Models;
using Bionet.Web.ControllerAPI;
using Bionet.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bionet.API.Models;

namespace Bionet.API.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            //Mapper.CreateMap<DanhMucDichVu, DanhMucDichVuViewModel>();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<DanhMucDichVu, DanhMucDichVuViewModel>();
                cfg.CreateMap<DanhMucThongSoXN, DanhMucThongSoXNViewModel>();
                cfg.CreateMap<DanhMucTrungTamSangLoc, DanhMucTrungTamSangLocViewModel>();
                cfg.CreateMap<DanhMucChiCuc, DanhMucChiCucViewModel>();
                cfg.CreateMap<DanhMucDonViCoSo, DanhMucDonViCoSoViewModel>();
                cfg.CreateMap<PhieuSangLoc, PhieuSangLocViewModel>();
                cfg.CreateMap<Patient, PhieuSangLocViewModel>();
                cfg.CreateMap<DanhMucChuongTrinh, DanhMucChuongTrinhViewModel>();
                cfg.CreateMap<ApplicationGroup, ApplicationGroupViewModel>();
                cfg.CreateMap<ApplicationGroupViewModel, ApplicationGroup>();

                cfg.CreateMap<ApplicationRole, ApplicationRoleViewModel>();
                cfg.CreateMap<ApplicationUser, ApplicationUserViewModel>();
                cfg.CreateMap<PhieuSangLoc, PhieuSangLocViewModel>();
                cfg.CreateMap<Patient, PhieuSangLocViewModel>();
                cfg.CreateMap<DanhMucDanhGiaChatLuongMau, DanhMucDanhGiaChatLuongViewModel>();
                cfg.CreateMap<DanhMucKyThuatXN, DanhMucKyThuatXNViewModel>();
                cfg.CreateMap<ChiDinhDichVuChiTietViewModel, ChiDinhDichVuChiTiet>();
                cfg.CreateMap<DanhMucGoiDichVuChung, DanhMucGoiDichVuChungViewModel>();
                cfg.CreateMap<DanhMucGoiDichVuChungViewModel, DanhMucGoiDichVuChung>();
                cfg.CreateMap<DanhMucThongSoXN, MapsXN_ThongSo>();
                cfg.CreateMap<MapsXN_ThongSo, ThongSoKyThuatViewModel>();
                cfg.CreateMap<DanhMucThongSoXN, ThongSoKyThuatViewModel>();
                
            });
        }

    }
}