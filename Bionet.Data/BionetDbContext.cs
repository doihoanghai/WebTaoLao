using Bionet.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Data
{
    public class BionetDbContext : IdentityDbContext<ApplicationUser>
    {
        public BionetDbContext() : base("BionetConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public static BionetDbContext Create()
        {
            return new BionetDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId }).ToTable("ApplicationUserRoles");
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId).ToTable("ApplicationUserLogins");
            builder.Entity<IdentityRole>().ToTable("ApplicationRoles");
            builder.Entity<IdentityUserClaim>().HasKey(i => i.UserId).ToTable("ApplicationUserClaims");
        }

        public DbSet<ApplicationGroup> ApplicationGroups { set; get; }
        public DbSet<ApplicationRole> ApplicationRoles { set; get; }
        public DbSet<ApplicationRoleGroup> ApplicationRoleGroups { set; get; }
        public DbSet<ApplicationUserGroup> ApplicationUserGroups { set; get; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { set; get; }

        public DbSet<Employee> Employee { set; get; }
        public DbSet<BenhNhanNguyCoCao> BenhNhanNguyCoCao { set; get; }
        public DbSet<ChiDinhDichVu> ChiDinhDichVu { set; get; }
        public DbSet<ChiDinhDichVuChiTiet> ChiDinhDichVuChiTiet { set; get; }
        public DbSet<ChiTietDanhGiaChatLuong> ChiTietDanhGiaChatLuong { set; get; }
        public DbSet<ChiTietGoiDichVuChung> ChiTietGoiDichVuChung { set; get; }
        public DbSet<DanhMucChauLuc> DanhMucChauLuc { set; get; }
        public DbSet<DanhMucChiCuc> DanhMucChiCuc { set; get; }
        public DbSet<DanhMucChuongTrinh> DanhMucChuongTrinh { set; get; }
        public DbSet<DanhMucDanhGiaChatLuongMau> DanhMucDanhGiaChatLuongMau { set; get; }
        public DbSet<DanhMucDanToc> DanhMucDanToc { set; get; }
        public DbSet<DanhMucDichVu> DanhMucDichVu { set; get; }
        public DbSet<DanhMucDichVuTheoDonVi> DanhMucDichVuTheoDonVi { set; get; }
        public DbSet<DanhMucDonViCoSo> DanhMucDonViCoSo { set; get; }
        public DbSet<DanhMucGoiDichVuChung> DanhMucGoiDichVuChung { set; get; }
        public DbSet<DanhMucGoiDichVuTrungTam> DanhMucGoiDichVuTrungTam { set; get; }
        public DbSet<DanhMucKyThuatXN> DanhMucKyThuatXN { set; get; }
        public DbSet<DanhMucNhom> DanhMucNhom { set; get; }
        public DbSet<DanhMucQuocGia> DanhMucQuocGia { set; get; }
        public DbSet<DanhMucThongSoXN> DanhMucThongSoXN { set; get; }
        public DbSet<DanhMucTrungTamSangLoc> DanhMucTrungTamSangLoc { set; get; }
        public DbSet<MapsXN_DichVu> MapsXN_DichVu { set; get; }
        public DbSet<MapsXN_ThongSo> MapsXN_ThongSo { set; get; }
        public DbSet<MauXetNghiem> MauXetNghiem { set; get; }
        public DbSet<NhanVien> NhanVien { set; get; }
        public DbSet<Patient> Patients { set; get; }
        public DbSet<Person> Persons { set; get; }
        public DbSet<PhieuSangLoc> PhieuSangLoc { set; get; }
        public DbSet<ThongTinTrungTam> ThongTinTrungTam { set; get; }
        public DbSet<TiepNhan> TiepNhan { set; get; }
        public DbSet<XN_KetQua> XN_KetQua { set; get; }
        public DbSet<XN_KetQua_ChiTiet> XN_KetQua_ChiTiet { set; get; }
        public DbSet<XN_TraKetQua> XN_TraKetQua { set; get; }
        public DbSet<XN_TraKQ_ChiTiet> XN_TraKQ_ChiTiet { set; get; }
        public DbSet<Error> Errors { set; get; }

        public DbSet<DanhMucGoiDichVuDVCS> DanhMucGoiDichVuDVCS { get; set; }
    }
}
