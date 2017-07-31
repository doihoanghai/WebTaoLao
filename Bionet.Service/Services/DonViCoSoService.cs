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
    public interface IDonViCoSoService
    {
        string GetMaTTSL(string maDV);
        IEnumerable<DanhMucDonViCoSo> GetAll();
        IEnumerable<DanhMucDonViCoSo> GetAll(string lvCode);


        IEnumerable<DanhMucDonViCoSo> GetAllHasCondition(string keyword);
        IEnumerable<DanhMucDonViCoSo> GetAllByMaTT(string MaTT);

        DanhMucDonViCoSo GetById(int id);

        void Add(DanhMucDonViCoSo danhmucDonVi);

        void Update(DanhMucDonViCoSo danhmucDonVi);

        void Delete(int id);

        void Save();
    }
    public class DonViCoSoService : IDonViCoSoService
    {
        private IDanhMucDonViCoSoRepository donvicosoRepository;
        private IUnitOfWork unitOfWork;

        public DonViCoSoService(IDanhMucDonViCoSoRepository _donvicosoRepository, IUnitOfWork _unitOfWork)
        {
            this.donvicosoRepository = _donvicosoRepository;
            this.unitOfWork = _unitOfWork;
        }

        public void Add(DanhMucDonViCoSo danhmucDonVi)
        {
            string code = string.Empty;
            var lstDonVi = this.donvicosoRepository.GetAll();
            string maChiCuc = danhmucDonVi.MaChiCuc;
            for (int i = 1; i < 100; i++)
            {
                string maDonVi = string.Empty;
                if (i <= 9)
                    maDonVi = maChiCuc + "0" + i;
                else
                    maDonVi = maChiCuc + i;
                var checkExist = lstDonVi.Where(x => x.MaDVCS == maDonVi).ToList();
                if (checkExist.Count == 0)
                {
                    code = maDonVi;
                    break;
                }
            }
            danhmucDonVi.MaDVCS = code;
            donvicosoRepository.Add(danhmucDonVi);
        }

        public void Delete(int id)
        {
            donvicosoRepository.DeleteMulti(x => x.RowIDDVCS == id);
        }

        public IEnumerable<DanhMucDonViCoSo> GetAll()
        {
            return donvicosoRepository.GetAll();
        }


        public IEnumerable<DanhMucDonViCoSo> GetAllHasCondition(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return donvicosoRepository.GetMulti(x => x.MaDVCS.Contains(keyword) || x.TenDVCS.Contains(keyword) || x.DiaChiDVCS.Contains(keyword) || x.SDTCS.Contains(keyword));
            else
                return donvicosoRepository.GetAll();
        }

        public IEnumerable<DanhMucDonViCoSo> GetAllByMaTT(string MaTT)
        {
            return donvicosoRepository.GetListDonViCSByMaTT(MaTT);
        }

        public DanhMucDonViCoSo GetById(int id)
        {
            return donvicosoRepository.GetSingleByCondition(x => x.RowIDDVCS == id);
        }

        public string GetMaTTSL(string maDV)
        {
            return this.donvicosoRepository.GetMaTrungTamByMaDonViCS(maDV);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public void Update(DanhMucDonViCoSo danhmucDonVi)
        {
            donvicosoRepository.Update(danhmucDonVi);
        }

        public IEnumerable<DanhMucDonViCoSo> GetAll(string lvCode)
        {
            if (lvCode == "0")
            {
                return donvicosoRepository.GetAll();
            }
            else
                return donvicosoRepository.GetMulti(x => x.MaDVCS.StartsWith(lvCode));
        }
    }
}
