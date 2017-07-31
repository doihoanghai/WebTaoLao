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
    public interface IDanhMucThongSoXNService
    {
        IEnumerable<DanhMucThongSoXN> GetAll(string keywork);

        DanhMucThongSoXN GetById(int id);

        DanhMucThongSoXN GetByMa(string id);

        void Add(DanhMucThongSoXN dmThongSo);

        void Update(DanhMucThongSoXN dmThongSo);

        void Delete(int id);

        void Save();
    }
    public class DanhMucThongSoXNService : IDanhMucThongSoXNService
    {
        private IDanhMucThongSoXNRepository danhMucThongSoXNRepository;
        private IDanhMucDonViCoSoRepository danhMucDonViCSRepository;
        private IUnitOfWork unitOfWork;
        public DanhMucThongSoXNService(IDanhMucThongSoXNRepository _danhMucThongSoXNRepository, IDanhMucDonViCoSoRepository _danhMucDonViCSRepository, IUnitOfWork _unitOfWork)
        {
            this.danhMucThongSoXNRepository = _danhMucThongSoXNRepository;
            this.danhMucDonViCSRepository = _danhMucDonViCSRepository;
            this.unitOfWork = _unitOfWork;
        }

        public void Add(DanhMucThongSoXN dmThongSo)
        {
            if (!string.IsNullOrEmpty(dmThongSo.MaDVCS))
                dmThongSo.MaTrungTam = this.danhMucDonViCSRepository.GetMaTrungTamByMaDonViCS(dmThongSo.MaDVCS);
            danhMucThongSoXNRepository.Add(dmThongSo);
        }

        public void Delete(int id)
        {
            danhMucThongSoXNRepository.DeleteMulti(x => x.RowIDThongSo == id);
        }

        public IEnumerable<DanhMucThongSoXN> GetAll(string keyword)
        {
            if(!string.IsNullOrEmpty(keyword))
            {
                return this.danhMucThongSoXNRepository.GetMulti(x => x.IDThongSoXN.Contains(keyword) || x.TenThongSo.Contains(keyword) || x.DonViTinh.Contains(keyword));
            }
            else
            {
                return this.danhMucThongSoXNRepository.GetAll();
            }
        }

        public DanhMucThongSoXN GetById(int id)
        {
            return danhMucThongSoXNRepository.GetSingleByCondition(x => x.RowIDThongSo == id);
        }

        public DanhMucThongSoXN GetByMa(string id)
        {
            return danhMucThongSoXNRepository.GetSingleByCondition(x => x.IDThongSoXN == id);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public void Update(DanhMucThongSoXN dmThongSo)
        {
            if (!string.IsNullOrEmpty(dmThongSo.MaDVCS))
                dmThongSo.MaTrungTam = this.danhMucDonViCSRepository.GetMaTrungTamByMaDonViCS(dmThongSo.MaDVCS);
            danhMucThongSoXNRepository.Update(dmThongSo);
        }
    }
}
