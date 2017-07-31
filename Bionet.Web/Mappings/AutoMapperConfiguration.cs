using AutoMapper;
using Bionet.Web.Models;

namespace Bionet.Web.Mappings
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
            });
        }

    }
}