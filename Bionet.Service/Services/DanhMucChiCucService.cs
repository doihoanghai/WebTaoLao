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
    public interface IDanhMucChiCucService
    {
        IEnumerable<DanhMucChiCuc> GetAll(string lvCode);

        IEnumerable<DanhMucChiCuc> GetAllHasCondition(string keyword);

        IEnumerable<DanhMucChiCuc> GetAllByMaTT(string maTT);

        DanhMucChiCuc GetById(int id);

        DanhMucChiCuc GetByMa(string ma);

        void Add(DanhMucChiCuc danhmucDichVu);

        void Update(DanhMucChiCuc danhmucDichVu);

        void Delete(int id);

        void Save();
    }
    public class DanhMucChiCucService : IDanhMucChiCucService
    {

        private IDanhMucChiCucRepository danhMucChiCucRepository;
        private IUnitOfWork _unitOfWork;

        public DanhMucChiCucService(IDanhMucChiCucRepository _danhMucChiCucRepository, IUnitOfWork unitOfWork)
        {
            this.danhMucChiCucRepository = _danhMucChiCucRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(DanhMucChiCuc danhmucChiCuc)
        {
            string code = string.Empty;
            var lstChiCuc = this.danhMucChiCucRepository.GetAll();
            string maTrungTam = danhmucChiCuc.MaTrungTam;
            for (int i = 1; i < 100; i++)
            {
                string maChicuc = string.Empty;
                if (i <= 9)
                    maChicuc = maTrungTam + "0" + i;
                else
                    maChicuc = maTrungTam + i;
                var checkExist = lstChiCuc.Where(x => x.MaChiCuc == maChicuc).ToList();
                if (checkExist.Count == 0)
                {
                    code = maChicuc;
                    break;
                }
            }
            danhmucChiCuc.MaChiCuc = code;
            danhMucChiCucRepository.Add(danhmucChiCuc);
        }

        public void Delete(int id)
        {
            danhMucChiCucRepository.DeleteMulti(x => x.RowIDChiCuc == id);
        }

        public IEnumerable<DanhMucChiCuc> GetAll(string lvCode)
        {
            if(lvCode == "0")
            {
                return danhMucChiCucRepository.GetAll();
            }
            else
            {
                return danhMucChiCucRepository.GetMulti(x => x.MaChiCuc.StartsWith(lvCode));
            }
        }

        public IEnumerable<DanhMucChiCuc> GetAllHasCondition(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return danhMucChiCucRepository.GetMulti(x => x.MaChiCuc.Contains(keyword) || x.TenChiCuc.Contains(keyword) || x.DiaChiChiCuc.Contains(keyword) || x.SdtChiCuc.Contains(keyword));
            else
                return danhMucChiCucRepository.GetAll();
        }

        public IEnumerable<DanhMucChiCuc> GetAllByMaTT(string maTT)
        {
            return danhMucChiCucRepository.GetMulti(x => x.MaTrungTam == maTT);
        }

        public DanhMucChiCuc GetById(int id)
        {
            return danhMucChiCucRepository.GetMulti(x => x.RowIDChiCuc == id).FirstOrDefault();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(DanhMucChiCuc danhmucChiCuc)
        {
            danhMucChiCucRepository.Update(danhmucChiCuc);
        }

        public DanhMucChiCuc GetByMa(string ma)
        {
            return danhMucChiCucRepository.GetSingleByCondition(x => x.MaChiCuc == ma);
        }
    }
}
