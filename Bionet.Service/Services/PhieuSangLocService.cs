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

        void Add(PhieuSangLoc PhieuSangLoc);

        void Update(PhieuSangLoc PhieuSangLoc);

        PhieuSangLoc GetByMaBenhNhan(string maBenhNhan);


        void Save();
    }
    public class PhieuSangLocService : IPhieuSangLocService
    {
        private IPhieuSangLocRepository PhieuSangLocRepository;
        private IDanhMucDonViCoSoRepository donViCoSoRepository;
        private IUnitOfWork unitOfWork;

        public PhieuSangLocService(IPhieuSangLocRepository _PhieuSangLocRepository, IDanhMucDonViCoSoRepository _donViCoSoRepository, IUnitOfWork _unitOfWork)
        {
            this.PhieuSangLocRepository = _PhieuSangLocRepository;
            this.donViCoSoRepository = _donViCoSoRepository;
            this.unitOfWork = _unitOfWork;
        }

        public void Add(PhieuSangLoc PhieuSangLoc)
        {
            PhieuSangLoc.TrangThaiPhieu = false;
            PhieuSangLoc.isKhongDat = false;
            PhieuSangLoc.isDongBo = false;
            PhieuSangLoc.isXoa = false;
            PhieuSangLoc.isXNLan2 = false;
            PhieuSangLoc.IDNhanVienXoa = string.Empty;
            PhieuSangLoc.NgayGioXoa = null;
            PhieuSangLoc.NgayTaoPhieu = DateTime.Now;
            if (!string.IsNullOrEmpty(PhieuSangLoc.MaDVCS))
                PhieuSangLoc.MaTrungTam = this.donViCoSoRepository.GetMaTrungTamByMaDonViCS(PhieuSangLoc.MaDVCS);
            this.PhieuSangLocRepository.Add(PhieuSangLoc);
        }

        public IEnumerable<PhieuSangLoc> GetAll()
        {
            return this.PhieuSangLocRepository.GetAll();
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<PhieuSangLoc> GetAllHasCondition(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return PhieuSangLocRepository.GetMulti(x => x.IDPhieu.Contains(keyword));
            else
                return PhieuSangLocRepository.GetAll();
        }

        public PhieuSangLoc GetById(string id)
        {
            return PhieuSangLocRepository.GetSingleByCondition(x => x.IDPhieu == id);
        }

        public PhieuSangLoc GetByMaBenhNhan(string maBenhNhan)
        {
            return PhieuSangLocRepository.GetSingleByCondition(x => x.MaBenhNhan == maBenhNhan);
        }

        public void Update(PhieuSangLoc PhieuSangLoc)
        {
            if (!string.IsNullOrEmpty(PhieuSangLoc.MaDVCS))
                PhieuSangLoc.MaTrungTam = this.donViCoSoRepository.GetMaTrungTamByMaDonViCS(PhieuSangLoc.MaDVCS);
            PhieuSangLocRepository.Update(PhieuSangLoc);
        }

        public IEnumerable<PhieuSangLoc> GetAll(string lvCode)
        {
            if (lvCode != "0")
                return PhieuSangLocRepository.GetMulti(x => x.MaDVCS.StartsWith(lvCode));
            else
                return PhieuSangLocRepository.GetAll();
        }
    }
}
