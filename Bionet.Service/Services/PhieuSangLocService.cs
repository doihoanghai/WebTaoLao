using Bionet.Data.Infrastructure;
using Bionet.Data.Repositories;
using Bionet.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Service.Services
{
    public interface IPhieuSangLocService
    {
        IEnumerable<PhieuSangLoc> GetAll();

        IEnumerable<PhieuSangLoc> GetAll(string lvCode);


        PhieuSangLoc GetById(string id);

        IEnumerable<PhieuSangLoc> GetAllHasCondition(string keyword);

        void Add(PhieuSangLoc phieuSangLoc);

        void Update(PhieuSangLoc phieuSangLoc);

        PhieuSangLoc GetByMaBenhNhan(string maBenhNhan);


        void Save();
    }
    public class PhieuSangLocService : IPhieuSangLocService
    {
        private IPhieuSangLocRepository phieuSangLocRepository;
        private IDanhMucDonViCoSoRepository donViCoSoRepository;
        private IUnitOfWork unitOfWork;

        public PhieuSangLocService(IPhieuSangLocRepository _phieuSangLocRepository, IDanhMucDonViCoSoRepository _donViCoSoRepository, IUnitOfWork _unitOfWork)
        {
            this.phieuSangLocRepository = _phieuSangLocRepository;
            this.donViCoSoRepository = _donViCoSoRepository;
            this.unitOfWork = _unitOfWork;
        }

        public void Add(PhieuSangLoc phieuSangLoc)
        {
            phieuSangLoc.TrangThaiPhieu = false;
            phieuSangLoc.isKhongDat = false;
            phieuSangLoc.isDongBo = false;
            phieuSangLoc.isXoa = false;
            phieuSangLoc.isXNLan2 = false;
            phieuSangLoc.IDNhanVienXoa = string.Empty;
            phieuSangLoc.NgayGioXoa = null;
            phieuSangLoc.NgayTaoPhieu = DateTime.Now;
            if (!string.IsNullOrEmpty(phieuSangLoc.MaDVCS))
                phieuSangLoc.MaTrungTam = this.donViCoSoRepository.GetMaTrungTamByMaDonViCS(phieuSangLoc.MaDVCS);
            this.phieuSangLocRepository.Add(phieuSangLoc);
        }

        public IEnumerable<PhieuSangLoc> GetAll()
        {
            return this.phieuSangLocRepository.GetAll();
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<PhieuSangLoc> GetAllHasCondition(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return phieuSangLocRepository.GetMulti(x => x.IDPhieu.Contains(keyword));
            else
                return phieuSangLocRepository.GetAll();
        }

        public PhieuSangLoc GetById(string id)
        {
            return phieuSangLocRepository.GetSingleByCondition(x => x.IDPhieu == id);
        }

        public PhieuSangLoc GetByMaBenhNhan(string maBenhNhan)
        {
            return phieuSangLocRepository.GetSingleByCondition(x => x.MaBenhNhan == maBenhNhan);
        }

        public void Update(PhieuSangLoc phieuSangLoc)
        {
            if (!string.IsNullOrEmpty(phieuSangLoc.MaDVCS))
                phieuSangLoc.MaTrungTam = this.donViCoSoRepository.GetMaTrungTamByMaDonViCS(phieuSangLoc.MaDVCS);
            phieuSangLocRepository.Update(phieuSangLoc);
        }

        public IEnumerable<PhieuSangLoc> GetAll(string lvCode)
        {
            if (lvCode != "0")
                return phieuSangLocRepository.GetMulti(x => x.MaDVCS.StartsWith(lvCode));
            else
                return phieuSangLocRepository.GetAll();
        }
    }
}
