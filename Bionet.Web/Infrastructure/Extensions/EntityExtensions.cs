using Bionet.Web.Models;
using Bionet.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Bionet.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        private static IFormatProvider mFomatter = new System.Globalization.CultureInfo("en-US", true);
        public static void UpdateApplicationGroup(this ApplicationGroup appGroup, ApplicationGroupViewModel appGroupViewModel)
        {
            appGroup.ID = appGroupViewModel.ID;
            appGroup.Name = appGroupViewModel.Name;
        }

        public static void UpdateApplicationRole(this ApplicationRole appRole, ApplicationRoleViewModel appRoleViewModel, string action = "add")
        {
            if (action == "update")
                appRole.Id = appRoleViewModel.Id;
            else
                appRole.Id = Guid.NewGuid().ToString();
            appRole.Name = appRoleViewModel.Name;
            appRole.Description = appRoleViewModel.Description;
        }
        public static void UpdateUser(this ApplicationUser appUser, ApplicationUserViewModel appUserViewModel, string action = "add")
        {

            appUser.Id = appUserViewModel.Id;
            appUser.FullName = appUserViewModel.FullName;
            appUser.BirthDay = DateTime.ParseExact(appUserViewModel.BirthDay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            appUser.Email = appUserViewModel.Email;
            appUser.UserName = appUserViewModel.UserName;
            appUser.PhoneNumber = appUserViewModel.PhoneNumber;
            appUser.UserLevel = appUserViewModel.UserLevel;
            appUser.LevelCode = appUserViewModel.LevelCode;
        }
        public static void UpdateDichVu(this DanhMucDichVu dichvu, DanhMucDichVuViewModel dichvuVm)
        {
            dichvu.IDDichVu = dichvuVm.IDDichVu;
            dichvu.TenDichVu = dichvuVm.TenDichVu;
            dichvu.TenHienThiDichVu = dichvuVm.TenHienThiDichVu;
            dichvu.GiaDichVu = dichvuVm.GiaDichVu;
            dichvu.MaNhom = dichvuVm.MaNhom;
            dichvu.isLocked = dichvuVm.isLocked;
            dichvu.isGoiXn = dichvuVm.isGoiXn;
        }

        public static void UpdateThongSoXN(this DanhMucThongSoXN thongso, DanhMucThongSoXNViewModel thongsoVm)
        {
            thongso.RowIDThongSo = thongsoVm.RowIDThongSo;
            thongso.IDThongSoXN = thongsoVm.IDThongSoXN;
            thongso.TenThongSo = thongsoVm.TenThongSo;
            thongso.MaDonViTinh = thongsoVm.MaDonViTinh;
            thongso.GiaTriMinNu = thongsoVm.GiaTriMinNu;
            thongso.GiaTriMaxNu = thongsoVm.GiaTriMaxNu;
            thongso.GiaTriTrungBinhNu = thongsoVm.GiaTriTrungBinhNu;
            thongso.GiaTriMacDinh = thongsoVm.GiaTriMacDinh;
            thongso.GiaTriMinNam = thongsoVm.GiaTriMinNam;
            thongso.GiaTriMaxNam = thongsoVm.GiaTriMaxNam;
            thongso.GiaTriTrungBinhNam = thongsoVm.GiaTriTrungBinhNam;
            thongso.MaNhom = thongsoVm.MaNhom;
            thongso.Stt = thongsoVm.Stt;
            thongso.GiaTri = thongsoVm.GiaTri;
            thongso.isLocked = thongsoVm.isLocked;
            thongso.DonViTinh = thongsoVm.DonViTinh;
            thongso.MaDVCS = thongsoVm.MaDVCS;
            thongso.MaTrungTam = thongsoVm.MaTrungTam;
        }

        public static void UpdateTrungTamSL(this DanhMucTrungTamSangLoc trungtam, DanhMucTrungTamSangLocViewModel trungtamVm)
        {
            trungtam.RowIDTTSL = trungtamVm.RowIDTTSL;
            trungtam.MaTTSL = trungtamVm.MaTTSL;
            trungtam.TenTTSL = trungtamVm.TenTTSL;
            trungtam.SDTTTSL = trungtamVm.SDTTTSL;
            trungtam.DiaChiTTSL = trungtamVm.DiaChiTTSL;
            trungtam.isLocked = trungtamVm.isLocked;
            trungtam.Stt = trungtamVm.Stt;
        }

        public static void UpdateChiCuc(this DanhMucChiCuc chicuc, DanhMucChiCucViewModel chicucVm)
        {
            chicuc.RowIDChiCuc = chicucVm.RowIDChiCuc;
            chicuc.MaChiCuc = chicucVm.MaChiCuc;
            chicuc.TenChiCuc = chicucVm.TenChiCuc;
            chicuc.DiaChiChiCuc = chicucVm.DiaChiChiCuc;
            chicuc.SdtChiCuc = chicucVm.SdtChiCuc;
            chicuc.isLocked = chicucVm.isLocked;
            chicuc.Stt = chicucVm.Stt;
            chicuc.MaTrungTam = chicucVm.MaTrungTam;
        }

        public static void UpdateDonViCoSo(this DanhMucDonViCoSo donvicoso, DanhMucDonViCoSoViewModel donvicosoVm)
        {
            donvicoso.RowIDDVCS = donvicosoVm.RowIDDVCS;
            donvicoso.MaDVCS = donvicosoVm.MaDVCS;
            donvicoso.TenDVCS = donvicosoVm.TenDVCS;
            donvicoso.DiaChiDVCS = donvicosoVm.DiaChiDVCS;
            donvicoso.SDTCS = donvicosoVm.SDTCS;
            donvicoso.isLocked = donvicosoVm.isLocked;
            donvicoso.Stt = donvicosoVm.Stt;
            donvicoso.MaChiCuc = donvicosoVm.MaChiCuc;
        }
        

        public static void UpdateChuongTrinh(this DanhMucChuongTrinh chuongtrinh, DanhMucChuongTrinhViewModel chuongtrinhVm)
        {
            chuongtrinh.RowIDChuongTrinh = chuongtrinhVm.RowIDChuongTrinh;
            chuongtrinh.IDChuongTrinh = chuongtrinhVm.IDChuongTrinh;
            chuongtrinh.TenChuongTrinh = chuongtrinhVm.TenChuongTrinh;
            chuongtrinh.Ngaytao = DateTime.ParseExact(chuongtrinhVm.Ngaytao, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            chuongtrinh.NgayHetHieuLuc = DateTime.ParseExact(chuongtrinhVm.NgayHetHieuLuc, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            chuongtrinh.isLocked = chuongtrinhVm.isLocked;
        }

        public static void UpdatePhieuSangLoc(this PhieuSangLoc phieusangloc, PhieuSangLocViewModel phieusanglocVm)
        {
            phieusangloc.RowIDPhieu = phieusanglocVm.RowIDPhieu;
            phieusangloc.IDPhieu = phieusanglocVm.IDPhieu;
            phieusangloc.NgayTaoPhieu = phieusanglocVm.NgayTaoPhieu;
            phieusangloc.IDNhanVienTaoPhieu = phieusanglocVm.IDNhanVienTaoPhieu;
            phieusangloc.IDCoSo = phieusanglocVm.IDCoSo;
            if (phieusanglocVm.NgayGioLayMau != null && phieusanglocVm.NgayGioLayMauTime != null)
            {
                DateTime NgayGioLayMau = DateTime.ParseExact(phieusanglocVm.NgayGioLayMau, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime NgayGioLayMauTime = Convert.ToDateTime(phieusanglocVm.NgayGioLayMauTime);
                phieusangloc.NgayGioLayMau = new DateTime(NgayGioLayMau.Year, NgayGioLayMau.Month, NgayGioLayMau.Day, NgayGioLayMauTime.Hour, NgayGioLayMauTime.Minute, NgayGioLayMauTime.Second);
            }
            phieusangloc.IDViTriLayMau = phieusanglocVm.IDViTriLayMau;
            phieusangloc.IDNhanVienLayMau = phieusanglocVm.IDNhanVienLayMau;
            phieusangloc.isLayMauLan2 = phieusanglocVm.isLayMauLan2;
            phieusangloc.IDPhieuLan1 = phieusanglocVm.IDPhieuLan1;
            phieusangloc.TinhTrangLucLayMau = phieusanglocVm.TinhTrangLucLayMau;
            phieusangloc.SLTruyenMau = phieusanglocVm.SLTruyenMau;
            if (!string.IsNullOrEmpty(phieusanglocVm.NgayTruyenMau))
            {
                DateTime NgayTruyenMau = DateTime.ParseExact(phieusanglocVm.NgayTruyenMau.Substring(0, 16), "dd/MM/yyyy HH:mm", mFomatter);
                phieusangloc.NgayTruyenMau = NgayTruyenMau;
            }
            phieusangloc.CheDoDinhDuong = phieusanglocVm.CheDoDinhDuong;
            phieusangloc.TrangThaiPhieu = phieusanglocVm.TrangThaiPhieu;
            phieusangloc.TrangThaiMau = phieusanglocVm.TrangThaiMau;
            phieusangloc.isKhongDat = phieusanglocVm.isKhongDat;
            phieusangloc.NgayNhanMau = phieusanglocVm.NgayNhanMau;
            phieusangloc.MaXetNghiem = phieusanglocVm.MaXetNghiem;
            phieusangloc.Para = phieusanglocVm.Para;
            phieusangloc.isTruoc24h = phieusanglocVm.isTruoc24h;
            phieusangloc.isSinhNon = phieusanglocVm.isSinhNon;
            phieusangloc.isNheCan = phieusanglocVm.isNheCan;
            phieusangloc.isGuiMauTre = phieusanglocVm.isGuiMauTre;
            phieusangloc.IDChuongTrinh = phieusanglocVm.IDChuongTrinh;
            phieusangloc.MaGoiXN = phieusanglocVm.MaGoiXN;
            phieusangloc.TenNhanVienLayMau = phieusanglocVm.TenNhanVienLayMau;
            phieusangloc.SDTNhanVienLayMau = phieusanglocVm.SDTNhanVienLayMau;
            phieusangloc.NoiLayMau = phieusanglocVm.NoiLayMau;
            phieusangloc.isHuyMau = phieusanglocVm.isHuyMau;
            phieusangloc.LyDoKhongDat = phieusanglocVm.LyDoKhongDat;
            phieusangloc.isDongBo = phieusanglocVm.isDongBo;
            phieusangloc.isXoa = phieusanglocVm.isXoa;
            phieusangloc.DiaChiLayMau = phieusanglocVm.DiaChiLayMau;
            phieusangloc.isXNLan2 = phieusanglocVm.isXNLan2;
            phieusangloc.IDNhanVienXoa = phieusanglocVm.IDNhanVienXoa;
            phieusangloc.NgayGioXoa = phieusanglocVm.NgayGioXoa;
            phieusangloc.MaDVCS = phieusanglocVm.MaDVCS;
        }

        public static void UpdatePatient(this Patient patient, PhieuSangLocViewModel phieusanglocVm)
        {
            patient.FatherName = phieusanglocVm.FatherName;
            patient.MotherName = phieusanglocVm.MotherName;
            if (!string.IsNullOrEmpty(phieusanglocVm.FatherBirthday))
                patient.FatherBirthday = DateTime.ParseExact(phieusanglocVm.FatherBirthday.Substring(0, 10), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            if (!string.IsNullOrEmpty(phieusanglocVm.MotherBirthday))
                patient.MotherBirthday = DateTime.ParseExact(phieusanglocVm.MotherBirthday.Substring(0, 10), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            patient.FatherPhoneNumber = phieusanglocVm.FatherPhoneNumber;
            patient.MotherPhoneNumber = phieusanglocVm.MotherPhoneNumber;
            patient.MaKhachHang = phieusanglocVm.MaKhachHang;
            patient.DiaChi = phieusanglocVm.DiaChi;
            patient.Para = phieusanglocVm.Para;
            patient.TenBenhNhan = phieusanglocVm.TenBenhNhan;
            if (phieusanglocVm.NgayGioSinh != null && phieusanglocVm.NgayGioSinhTime != null)
            {
                DateTime NgayGioSinh = DateTime.ParseExact(phieusanglocVm.NgayGioSinh, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime NgayGioSinhTime = Convert.ToDateTime(phieusanglocVm.NgayGioSinhTime);
                patient.NgayGioSinh = new DateTime(NgayGioSinh.Year, NgayGioSinh.Month, NgayGioSinh.Day, NgayGioSinhTime.Hour, NgayGioSinhTime.Minute, NgayGioSinhTime.Second);
            }
            patient.CanNang = phieusanglocVm.CanNang;
            patient.TuanTuoiKhiSinh = phieusanglocVm.TuanTuoiKhiSinh;
            patient.NoiSinh = phieusanglocVm.NoiSinh;
            patient.QuocTichID = phieusanglocVm.QuocTichID;
            patient.DanTocID = phieusanglocVm.DanTocID;
            patient.PhuongPhapSinh = phieusanglocVm.PhuongPhapSinh;
            patient.GioiTinh = phieusanglocVm.GioiTinh;
            patient.isDongBo = phieusanglocVm.isDongBo;
            patient.isXoa = phieusanglocVm.isXoa;
            patient.IDThaiPhuTienSoSinh = phieusanglocVm.IDThaiPhuTienSoSinh;
            patient.IDNhanVienXoa = phieusanglocVm.IDNhanVienXoa;
            patient.NgayGioXoa = phieusanglocVm.NgayGioXoa;
        }

        public static void UpdateDanhGiaChatLuong(this DanhMucDanhGiaChatLuongMau danhGiaChatLuong, DanhMucDanhGiaChatLuongViewModel danhGiaChatLuongVm)
        {
            danhGiaChatLuong.RowIDChatLuongMau = danhGiaChatLuongVm.RowIDChatLuongMau;
            danhGiaChatLuong.ChatLuongMau = danhGiaChatLuongVm.ChatLuongMau;
            danhGiaChatLuong.isLocked = danhGiaChatLuongVm.isLocked;
            danhGiaChatLuong.IDDanhGiaChatLuongMau = danhGiaChatLuongVm.IDDanhGiaChatLuongMau;

        }

        public static void UpdateXN_KetQua(this XN_KetQua xnKetQua, XN_KetQuaViewModel xnKetQuaVm)
        {
            xnKetQua.RowIDKetQua = xnKetQuaVm.RowIDKetQua;
            xnKetQua.NgayTraKQ = xnKetQuaVm.NgayTraKQ;
            xnKetQua.UserTraKQ = xnKetQuaVm.UserTraKQ;
            xnKetQua.NgayLamXetNghiem = xnKetQuaVm.NgayLamXetNghiem;
            xnKetQua.MaPhieu = xnKetQuaVm.MaPhieu;
            xnKetQua.MaChiDinh = xnKetQuaVm.MaChiDinh;
            xnKetQua.MaDonVi = xnKetQuaVm.MaDonVi;
            xnKetQua.MaKetQua = xnKetQuaVm.MaKetQua;
            xnKetQua.MaXetNghiem = xnKetQuaVm.MaXetNghiem;
            xnKetQua.MaTiepNhan = xnKetQuaVm.MaTiepNhan;
            xnKetQua.isCoKQ = xnKetQuaVm.isCoKQ;
            xnKetQua.NgayChiDinh = xnKetQuaVm.NgayChiDinh;
            xnKetQua.NgayTiepNhan = xnKetQuaVm.NgayTiepNhan;
            xnKetQua.GhiChu = xnKetQuaVm.GhiChu;
            xnKetQua.isDongBo = xnKetQuaVm.isDongBo;
            xnKetQua.isXoa = xnKetQuaVm.isXoa;
            xnKetQua.MaGoiXN = xnKetQuaVm.MaGoiXN;
            xnKetQua.IDNhanVienXoa = xnKetQuaVm.IDNhanVienXoa;
            xnKetQua.NgayGioXoa = xnKetQuaVm.NgayGioXoa;
            xnKetQua.LyDoXoa = xnKetQuaVm.LyDoXoa;
            xnKetQua.MaDVCS = xnKetQuaVm.MaDVCS;
            xnKetQua.MaTrungTam = xnKetQuaVm.MaTrungTam;
        }

        public static void UpdateXN_KetQuaChiTiet(this XN_KetQua_ChiTiet xnKetQuaVmChiTiet, XN_KetQua_ChiTietViewModel xnKetQuaVmChiTietVm)
        {
            xnKetQuaVmChiTiet.RowIDKetQuaChiTiet = xnKetQuaVmChiTietVm.RowIDKetQuaChiTiet;
            xnKetQuaVmChiTiet.MaKQ = xnKetQuaVmChiTietVm.MaKQ;
            xnKetQuaVmChiTiet.MaDichVu = xnKetQuaVmChiTietVm.MaDichVu;
            xnKetQuaVmChiTiet.MaThongSoXN = xnKetQuaVmChiTietVm.MaThongSoXN;
            xnKetQuaVmChiTiet.TenThongSo = xnKetQuaVmChiTietVm.TenThongSo;
            xnKetQuaVmChiTiet.TenKyThuat = xnKetQuaVmChiTietVm.TenKyThuat;
            xnKetQuaVmChiTiet.MaKyThuat = xnKetQuaVmChiTietVm.MaKyThuat;
            xnKetQuaVmChiTiet.GiaTri = xnKetQuaVmChiTietVm.GiaTri;
            xnKetQuaVmChiTiet.GiaTriMinNu = xnKetQuaVmChiTietVm.GiaTriMinNu;
            xnKetQuaVmChiTiet.GiaTriMaxNu = xnKetQuaVmChiTietVm.GiaTriMaxNu;
            xnKetQuaVmChiTiet.GiaTriTrungBinhNu = xnKetQuaVmChiTietVm.GiaTriTrungBinhNu;
            xnKetQuaVmChiTiet.GiaTriMinNam = xnKetQuaVmChiTietVm.GiaTriMinNam;
            xnKetQuaVmChiTiet.GiaTriMaxNam = xnKetQuaVmChiTietVm.GiaTriMaxNam;
            xnKetQuaVmChiTiet.GiaTriTrungBinhNam = xnKetQuaVmChiTietVm.GiaTriTrungBinhNam;
            xnKetQuaVmChiTiet.DonViTinh = xnKetQuaVmChiTietVm.DonViTinh;
            xnKetQuaVmChiTiet.MaDonViTinh = xnKetQuaVmChiTietVm.MaDonViTinh;
            xnKetQuaVmChiTiet.isNguyCo = xnKetQuaVmChiTietVm.isNguyCo;
            xnKetQuaVmChiTiet.MaXetNghiem = xnKetQuaVmChiTietVm.MaXetNghiem;
            xnKetQuaVmChiTiet.isDongBo = xnKetQuaVmChiTietVm.isDongBo;
            xnKetQuaVmChiTiet.isXoa = xnKetQuaVmChiTietVm.isXoa;
            xnKetQuaVmChiTiet.IDNhanVienXoa = xnKetQuaVmChiTietVm.IDNhanVienXoa;
            xnKetQuaVmChiTiet.NgayGioXoa = xnKetQuaVmChiTietVm.NgayGioXoa;
            xnKetQuaVmChiTiet.MaDVCS = xnKetQuaVmChiTietVm.MaDVCS;
            xnKetQuaVmChiTiet.MaTrungTam = xnKetQuaVmChiTietVm.MaTrungTam;
        }

        public static void UpdateXN_TraKetQua(this XN_TraKetQua xnTraKetQua, XN_TraKetQuaViewModel xnTraKetQuaVm)
        {
            xnTraKetQua.RowIDXN_TraKetQua = xnTraKetQuaVm.RowIDXN_TraKetQua;
            xnTraKetQua.NgayTraKQ = xnTraKetQuaVm.NgayTraKQ;
            xnTraKetQua.UserTraKQ = xnTraKetQuaVm.UserTraKQ;
            xnTraKetQua.MaPhieu = xnTraKetQuaVm.MaPhieu;
            xnTraKetQua.KetLuanTongQuat = xnTraKetQuaVm.KetLuanTongQuat;
            xnTraKetQua.GhiChu = xnTraKetQuaVm.GhiChu;
            xnTraKetQua.IDCoSo = xnTraKetQuaVm.IDCoSo;
            xnTraKetQua.MaTiepNhan = xnTraKetQuaVm.MaTiepNhan;
            xnTraKetQua.isDaDuyetKQ = xnTraKetQuaVm.isDaDuyetKQ;
            xnTraKetQua.NgayCoKQ = xnTraKetQuaVm.NgayCoKQ;
            xnTraKetQua.NgayTiepNhan = xnTraKetQuaVm.NgayTiepNhan;
            xnTraKetQua.NgayChiDinh = xnTraKetQuaVm.NgayChiDinh;
            xnTraKetQua.NgayLamXetNghiem = xnTraKetQuaVm.NgayLamXetNghiem;
            xnTraKetQua.MaXetNghiem = xnTraKetQuaVm.MaXetNghiem;
            xnTraKetQua.isTraKQ = xnTraKetQuaVm.isTraKQ;
            xnTraKetQua.MaPhieuCu = xnTraKetQuaVm.MaPhieuCu;
            xnTraKetQua.GhiChuPhongXetNghiem = xnTraKetQuaVm.GhiChuPhongXetNghiem;
            xnTraKetQua.isDongBo = xnTraKetQuaVm.isDongBo;
            xnTraKetQua.isXoa = xnTraKetQuaVm.isXoa;
            xnTraKetQua.IDNhanVienXoa = xnTraKetQuaVm.IDNhanVienXoa;
            xnTraKetQua.NgayGioXoa = xnTraKetQuaVm.NgayGioXoa;
            xnTraKetQua.LyDoXoa = xnTraKetQuaVm.LyDoXoa;
            xnTraKetQua.MaGoiXN = xnTraKetQuaVm.MaGoiXN;
            xnTraKetQua.isNguyCoCao = xnTraKetQuaVm.isNguyCoCao;
            xnTraKetQua.MaDVCS = xnTraKetQuaVm.MaDVCS;
            xnTraKetQua.MaTrungTam = xnTraKetQuaVm.MaTrungTam;
        }

        public static void UpdateXN_TraKetQuaChiTiet(this XN_TraKQ_ChiTiet xnTraKetQuaChiTiet, XN_TraKQ_ChiTietViewModel xnTraKetQuaChiTietVm)
        {
            xnTraKetQuaChiTietVm.RowIDXN_TraKetQua_ChiTiet = xnTraKetQuaChiTietVm.RowIDXN_TraKetQua_ChiTiet;
            xnTraKetQuaChiTietVm.MaDichVu = xnTraKetQuaChiTietVm.MaDichVu;
            xnTraKetQuaChiTietVm.IDThongSoXN = xnTraKetQuaChiTietVm.IDThongSoXN;
            xnTraKetQuaChiTietVm.TenThongSo = xnTraKetQuaChiTietVm.TenThongSo;
            xnTraKetQuaChiTietVm.TenKyThuat = xnTraKetQuaChiTietVm.TenKyThuat;
            xnTraKetQuaChiTietVm.IDKyThuat = xnTraKetQuaChiTietVm.IDKyThuat;
            xnTraKetQuaChiTietVm.GiaTri1 = xnTraKetQuaChiTietVm.GiaTri1;
            xnTraKetQuaChiTietVm.GiaTriMin = xnTraKetQuaChiTietVm.GiaTriMin;
            xnTraKetQuaChiTietVm.GiaTriMax = xnTraKetQuaChiTietVm.GiaTriMax;
            xnTraKetQuaChiTietVm.DonViTinh = xnTraKetQuaChiTietVm.DonViTinh;
            xnTraKetQuaChiTietVm.isNguyCo = xnTraKetQuaChiTietVm.isNguyCo;
            xnTraKetQuaChiTietVm.GiaTriTrungBinh = xnTraKetQuaChiTietVm.GiaTriTrungBinh;
            xnTraKetQuaChiTietVm.GiaTri2 = xnTraKetQuaChiTietVm.GiaTri2;
            xnTraKetQuaChiTietVm.GiaTriCuoi = xnTraKetQuaChiTietVm.GiaTriCuoi;
            xnTraKetQuaChiTietVm.IDDonViTinh = xnTraKetQuaChiTietVm.IDDonViTinh;
            xnTraKetQuaChiTietVm.KetLuan = xnTraKetQuaChiTietVm.KetLuan;
            xnTraKetQuaChiTietVm.MaTiepNhan = xnTraKetQuaChiTietVm.MaTiepNhan;
            xnTraKetQuaChiTietVm.MaPhieu = xnTraKetQuaChiTietVm.MaPhieu;
            xnTraKetQuaChiTietVm.isDaDuyetKQ = xnTraKetQuaChiTietVm.isDaDuyetKQ;
            xnTraKetQuaChiTietVm.isMauXNLai = xnTraKetQuaChiTietVm.isMauXNLai;
            xnTraKetQuaChiTietVm.Stt = xnTraKetQuaChiTietVm.Stt;
            xnTraKetQuaChiTietVm.isDongBo = xnTraKetQuaChiTietVm.isDongBo;
            xnTraKetQuaChiTietVm.isXoa = xnTraKetQuaChiTietVm.isXoa;
            xnTraKetQuaChiTietVm.IDNhanVienXoa = xnTraKetQuaChiTietVm.IDNhanVienXoa;
            xnTraKetQuaChiTietVm.NgayGioXoa = xnTraKetQuaChiTietVm.NgayGioXoa;
            xnTraKetQuaChiTietVm.MaDVCS = xnTraKetQuaChiTietVm.MaDVCS;
            xnTraKetQuaChiTietVm.MaTrungTam = xnTraKetQuaChiTietVm.MaTrungTam;
        }
        public static void UpdateKyThuatXN(this DanhMucKyThuatXN kythuatXN, DanhMucKyThuatXNViewModel kythuatXNVM)
        {
            kythuatXN.RowIDKyThuatXn = kythuatXNVM.RowIDKyThuatXn;
            kythuatXN.IDKyThuatXN = kythuatXNVM.IDKyThuatXN;
            kythuatXN.TenHienThiKyThuat = kythuatXNVM.TenHienThiKyThuat;
            kythuatXN.TenKyThuat = kythuatXNVM.TenKyThuat;
            kythuatXN.isLocked = kythuatXNVM.isLocked??false;
            kythuatXN.STT   = kythuatXNVM.STT;
           
        }

        public static void UpdateKChiTietKQXN(this XN_KetQua_ChiTiet ketQuaXNCT,XN_KetQua_ChiTietViewModel ketQuaXNCTVM)
        {
            ketQuaXNCT.DonViTinh = ketQuaXNCTVM.DonViTinh;
            ketQuaXNCT.GiaTri = ketQuaXNCTVM.GiaTri;
            ketQuaXNCT.GiaTriMaxNam = ketQuaXNCTVM.GiaTriMaxNam;
            ketQuaXNCT.GiaTriMaxNu = ketQuaXNCTVM.GiaTriMaxNu;
            ketQuaXNCT.GiaTriMinNam = ketQuaXNCTVM.GiaTriMinNam;
            ketQuaXNCT.GiaTriMinNu = ketQuaXNCTVM.GiaTriMinNu;
            ketQuaXNCT.GiaTriTrungBinhNam = ketQuaXNCTVM.GiaTriTrungBinhNam;
            ketQuaXNCT.GiaTriTrungBinhNu = ketQuaXNCTVM.GiaTriTrungBinhNu;
            ketQuaXNCT.IDNhanVienXoa = ketQuaXNCTVM.IDNhanVienXoa;
            ketQuaXNCT.isDongBo = ketQuaXNCTVM.isDongBo;
            ketQuaXNCT.isNguyCo = ketQuaXNCTVM.isNguyCo;
            ketQuaXNCT.isXoa = ketQuaXNCTVM.isXoa;
            ketQuaXNCT.MaDichVu = ketQuaXNCTVM.MaDichVu;
            ketQuaXNCT.MaDonViTinh = ketQuaXNCTVM.MaDonViTinh;
            ketQuaXNCT.MaDVCS = ketQuaXNCTVM.MaDVCS;
            ketQuaXNCT.MaKQ = ketQuaXNCTVM.MaKQ;
            ketQuaXNCT.MaKyThuat = ketQuaXNCTVM.MaKyThuat;
            ketQuaXNCT.MaThongSoXN = ketQuaXNCTVM.MaThongSoXN;
            ketQuaXNCT.MaTrungTam = ketQuaXNCTVM.MaTrungTam;
            ketQuaXNCT.MaXetNghiem = ketQuaXNCTVM.MaXetNghiem;
            ketQuaXNCT.NgayGioXoa = ketQuaXNCTVM.NgayGioXoa;
            ketQuaXNCT.RowIDKetQuaChiTiet = ketQuaXNCTVM.RowIDKetQuaChiTiet;
            ketQuaXNCT.TenKyThuat = ketQuaXNCTVM.TenKyThuat;
            ketQuaXNCT.TenThongSo = ketQuaXNCTVM.TenThongSo;
        }

        public static void UpdateKChiTietTraKQXN(this XN_TraKetQua traKetQuaXNCT, XN_TraKetQuaViewModel traKetQuaXNCTVM)
        {
            traKetQuaXNCT.GhiChu = traKetQuaXNCTVM.GhiChu;
            traKetQuaXNCT.GhiChuPhongXetNghiem = traKetQuaXNCTVM.GhiChuPhongXetNghiem;
            traKetQuaXNCT.IDCoSo = traKetQuaXNCTVM.IDCoSo;
            traKetQuaXNCT.IDNhanVienXoa = traKetQuaXNCTVM.IDNhanVienXoa;
            traKetQuaXNCT.isDaDuyetKQ = traKetQuaXNCTVM.isDaDuyetKQ;
            traKetQuaXNCT.isDongBo = traKetQuaXNCTVM.isDongBo;
            traKetQuaXNCT.isNguyCoCao = traKetQuaXNCTVM.isNguyCoCao;
            traKetQuaXNCT.isTraKQ = traKetQuaXNCTVM.isTraKQ;
            traKetQuaXNCT.KetLuanTongQuat = traKetQuaXNCTVM.KetLuanTongQuat;
            traKetQuaXNCT.LyDoXoa = traKetQuaXNCTVM.LyDoXoa;
            traKetQuaXNCT.MaDVCS = traKetQuaXNCTVM.MaDVCS;
            traKetQuaXNCT.MaGoiXN = traKetQuaXNCTVM.MaGoiXN;
            traKetQuaXNCT.MaPhieu = traKetQuaXNCTVM.MaPhieu;
            traKetQuaXNCT.MaPhieuCu = traKetQuaXNCTVM.MaPhieuCu;
            traKetQuaXNCT.MaTiepNhan = traKetQuaXNCTVM.MaTiepNhan;
            traKetQuaXNCT.MaTrungTam = traKetQuaXNCTVM.MaTrungTam;
            traKetQuaXNCT.MaXetNghiem = traKetQuaXNCTVM.MaXetNghiem;
            traKetQuaXNCT.NgayChiDinh = traKetQuaXNCTVM.NgayChiDinh;
            traKetQuaXNCT.NgayCoKQ = traKetQuaXNCTVM.NgayCoKQ;
            traKetQuaXNCT.NgayGioXoa = traKetQuaXNCTVM.NgayGioXoa;
            traKetQuaXNCT.NgayLamXetNghiem = traKetQuaXNCTVM.NgayLamXetNghiem;
            traKetQuaXNCT.NgayTiepNhan = traKetQuaXNCTVM.NgayTiepNhan;
            traKetQuaXNCT.NgayTraKQ = traKetQuaXNCTVM.NgayTraKQ;
            traKetQuaXNCT.RowIDXN_TraKetQua = traKetQuaXNCTVM.RowIDXN_TraKetQua;
        }

        public static void UpdateTiepNhan(this TiepNhan tiepNhan, TiepNhanViewModel tiepnhanVM)
        {
            tiepNhan.isDaDanhGia = tiepnhanVM.isDaDanhGia;
            tiepNhan.isDaNhapLieu = tiepnhanVM.isDaNhapLieu;
            tiepNhan.MaDonVi = tiepnhanVM.MaDonVi;
            tiepNhan.MaDVCS = tiepnhanVM.MaDVCS;
            tiepNhan.MaNVTiepNhan = tiepnhanVM.MaNVTiepNhan;
            tiepNhan.MaPhieu = tiepnhanVM.MaPhieu;
            tiepNhan.MaTiepNhan = tiepnhanVM.MaTiepNhan;
            tiepNhan.MaTrungTam = tiepnhanVM.MaTrungTam;
            tiepNhan.NgayTiepNhan = tiepnhanVM.NgayTiepNhan;
            tiepNhan.RowIDPhieu = tiepnhanVM.RowIDPhieu;
            tiepNhan.RowIDTiepNhan = tiepnhanVM.RowIDTiepNhan;
        }

        public static void UpdateChiDinh(this ChiDinhDichVu chiDinhDichVu,ChiDinhDichVuViewModel chiDinhDichVuVM)
        {
            chiDinhDichVu.DonGia = chiDinhDichVuVM.DonGia;
            chiDinhDichVu.IDGoiDichVu = chiDinhDichVuVM.IDGoiDichVu;
            chiDinhDichVu.IDNhanVienChiDinh = chiDinhDichVuVM.IDNhanVienChiDinh;
            chiDinhDichVu.isLayMauLai = chiDinhDichVuVM.isLayMauLai;
            chiDinhDichVu.MaChiDinh = chiDinhDichVuVM.MaChiDinh;
            chiDinhDichVu.MaDonVi = chiDinhDichVuVM.MaDonVi;
            chiDinhDichVu.MaNVChiDinh = chiDinhDichVuVM.MaNVChiDinh;
            chiDinhDichVu.MaPhieu = chiDinhDichVuVM.MaPhieu;
            chiDinhDichVu.MaPhieuLan1 = chiDinhDichVuVM.MaPhieuLan1;
            chiDinhDichVu.MaTiepNhan = chiDinhDichVuVM.MaTiepNhan;
            chiDinhDichVu.NgayChiDinhHienTai = chiDinhDichVuVM.NgayChiDinhHienTai;
            chiDinhDichVu.NgayChiDinhLamViec = chiDinhDichVuVM.NgayChiDinhLamViec;
            chiDinhDichVu.NgayTiepNhan = chiDinhDichVuVM.NgayTiepNhan;
            chiDinhDichVu.RowIDChiDinh = chiDinhDichVuVM.RowIDChiDinh;
            chiDinhDichVu.SoLuong = chiDinhDichVuVM.SoLuong;
            chiDinhDichVu.TrangThai = chiDinhDichVuVM.TrangThai;
            chiDinhDichVu.isNhapLieu = chiDinhDichVuVM.isNhapLieu;

        }


        
    }
}