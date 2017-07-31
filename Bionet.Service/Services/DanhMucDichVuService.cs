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
    public interface IDanhMucDichVuService
    {
        IEnumerable<DanhMucDichVu> GetAll();

        IEnumerable<DanhMucDichVu> GetAll(string keyword);

        DanhMucDichVu GetById(int id);

        void Add(DanhMucDichVu danhmucDichVu);

        void Update(DanhMucDichVu danhmucDichVu);

        void Delete(int id);

        void Save();
    }
    public class DanhMucDichVuService : IDanhMucDichVuService
    {
        private IDanhMucDichVuRepository _danhMucDichVuRepository;
        private IUnitOfWork _unitOfWork;

        public DanhMucDichVuService(IDanhMucDichVuRepository danhMucDichVuRepository, IUnitOfWork unitOfWork)
        {
            this._danhMucDichVuRepository = danhMucDichVuRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(DanhMucDichVu danhMucDichVu)
        {
            int maxRow = _danhMucDichVuRepository.GetMaxRow();
            string lastID = _danhMucDichVuRepository.GetMulti(p => p.RowIDDichVu == maxRow).FirstOrDefault().IDDichVu;
            int numID = Convert.ToInt32(lastID.Substring(4)) + 1;
            string idDV = string.Empty;
            if (numID <= 9)
                idDV = "DVXN0000" + numID;
            else if (numID > 9 && numID <= 99)
                idDV = "DVXN000" + numID;
            else if (numID > 99 && numID <= 999)
                idDV = "DVXN00" + numID;
            else if (numID > 999 && numID <= 9999)
                idDV = "DVXN0" + numID;
            else
                idDV = "DVXN" + numID;
            danhMucDichVu.IDDichVu = idDV;
            _danhMucDichVuRepository.Add(danhMucDichVu);
        }

        public void Delete(int id)
        {
            _danhMucDichVuRepository.DeleteMulti(x => x.RowIDDichVu == id);
        }

        public IEnumerable<DanhMucDichVu> GetAll()
        {
            return _danhMucDichVuRepository.GetAll();
        }

        public IEnumerable<DanhMucDichVu> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _danhMucDichVuRepository.GetMulti(x => x.TenDichVu.Contains(keyword) || x.TenHienThiDichVu.Contains(keyword));
            else
                return _danhMucDichVuRepository.GetAll();
        }

        public DanhMucDichVu GetById(int id)
        {
            return _danhMucDichVuRepository.GetSingleByCondition(x => x.RowIDDichVu == id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(DanhMucDichVu danhmucDichVu)
        {
            _danhMucDichVuRepository.Update(danhmucDichVu);
        }
    }
}
