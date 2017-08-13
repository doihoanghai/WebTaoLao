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
    public interface IDanhMucDichVuTheoDonViService
    {
        IEnumerable<DanhMucDichVuTheoDonVi> GetAll();

        IEnumerable<DanhMucDichVuTheoDonVi> GetAll(string keyword);

        IEnumerable<DanhMucDichVuTheoDonVi> GetAllTheoDonVi(string levelCode);


        DanhMucDichVuTheoDonVi GetById(int id);

        void AddUp(DanhMucDichVuTheoDonVi DanhMucDichVuTheoDonVi);

        void Update(DanhMucDichVuTheoDonVi DanhMucDichVuTheoDonVi);

        void Delete(int id);

        void Save();
    }
    public class DanhMucDichVuTheoDonViService : IDanhMucDichVuTheoDonViService
    {
        private IDanhMucDichVuTheoDonViRepository _DanhMucDichVuTheoDonViRepository;
        private IUnitOfWork _unitOfWork;

        public DanhMucDichVuTheoDonViService(IDanhMucDichVuTheoDonViRepository DanhMucDichVuTheoDonViRepository, IUnitOfWork unitOfWork)
        {
            this._DanhMucDichVuTheoDonViRepository = DanhMucDichVuTheoDonViRepository;
            this._unitOfWork = unitOfWork;
        }

        public void AddUp(DanhMucDichVuTheoDonVi danhmucdvtheodv)
        {
            var dvtheodv = this._DanhMucDichVuTheoDonViRepository.GetSingleByCondition(x => x.IDDichVu == danhmucdvtheodv.IDDichVu && x.MaDonVi == danhmucdvtheodv.MaDonVi);
            if (dvtheodv == null)
            {
                this._DanhMucDichVuTheoDonViRepository.Add(danhmucdvtheodv);
            }
            else
            {
                var term = dvtheodv.RowIDDichVuTheoDonVi;
                DanhMucDichVuTheoDonVi newdmdv = new DanhMucDichVuTheoDonVi();
                newdmdv = dvtheodv;
                newdmdv.RowIDDichVuTheoDonVi = term;

                this._DanhMucDichVuTheoDonViRepository.Update(newdmdv);
            }
        }

   



        //public void Add(DanhMucDichVuTheoDonVi DanhMucDichVuTheoDonVi)
        //{
        //    long maxRow = _DanhMucDichVuTheoDonViRepository.GetMaxRow();
        //    string lastID = _DanhMucDichVuTheoDonViRepository.GetMulti(p => p.RowIDDichVuTheoDonVi == maxRow).FirstOrDefault().IDDichVu;
        //    int numID = Convert.ToInt32(lastID.Substring(4)) + 1;
        //    string idDV = string.Empty;
        //    if (numID <= 9)
        //        idDV = "DVXN0000" + numID;
        //    else if (numID > 9 && numID <= 99)
        //        idDV = "DVXN000" + numID;
        //    else if (numID > 99 && numID <= 999)
        //        idDV = "DVXN00" + numID;
        //    else if (numID > 999 && numID <= 9999)
        //        idDV = "DVXN0" + numID;
        //    else
        //        idDV = "DVXN" + numID;
        //    DanhMucDichVuTheoDonVi.IDDichVu = idDV;
        //    _DanhMucDichVuTheoDonViRepository.Add(DanhMucDichVuTheoDonVi);
        //}

        public void Delete(int id)
        {
            _DanhMucDichVuTheoDonViRepository.DeleteMulti(x => x.RowIDDichVuTheoDonVi == id);
        }

        public IEnumerable<DanhMucDichVuTheoDonVi> GetAll()
        {
            return _DanhMucDichVuTheoDonViRepository.GetAll();
        }

        public IEnumerable<DanhMucDichVuTheoDonVi> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _DanhMucDichVuTheoDonViRepository.GetMulti(x => x.TenDichVu.Contains(keyword) || x.TenHienThi.Contains(keyword));
            else
                return _DanhMucDichVuTheoDonViRepository.GetAll();
        }

        public IEnumerable<DanhMucDichVuTheoDonVi> GetAllTheoDonVi(string levelCode)
        {
            return _DanhMucDichVuTheoDonViRepository.GetMulti(x => x.MaDonVi == levelCode);
            
        }

        public DanhMucDichVuTheoDonVi GetById(int id)
        {
            return _DanhMucDichVuTheoDonViRepository.GetSingleByCondition(x => x.RowIDDichVuTheoDonVi == id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

       

        public void Update(DanhMucDichVuTheoDonVi DanhMucDichVuTheoDonVi)
        {
            _DanhMucDichVuTheoDonViRepository.Update(DanhMucDichVuTheoDonVi);
        }

  
    }
}
