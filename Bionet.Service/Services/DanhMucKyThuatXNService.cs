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
    public interface IDanhMucKyThuatXNService
    {
        IEnumerable<DanhMucKyThuatXN> GetAll(string keywork);

        IEnumerable<DanhMucKyThuatXN> GetAll();

        DanhMucKyThuatXN GetById(string id);

        DanhMucKyThuatXN GetByMa(string ma);

        void Update(DanhMucKyThuatXN dmKyThuatXN);

        void Create(DanhMucKyThuatXN dmKyThuatXN);

        void Delete(int id);

        void Save();
    }
    public class DanhMucKyThuatXNService : IDanhMucKyThuatXNService
    {
        private IDanhMucKyThuatXNRepository dmKyThuatXNRepository;
        private IUnitOfWork unitOfWork;

        public DanhMucKyThuatXNService(IDanhMucKyThuatXNRepository _dmKyThuatXNRepository, IUnitOfWork _unitOfWork)
        {
            this.dmKyThuatXNRepository = _dmKyThuatXNRepository;
            this.unitOfWork = _unitOfWork;
        }

        public void Create(DanhMucKyThuatXN dmKyThuatXN)
        {
            dmKyThuatXNRepository.Add(dmKyThuatXN);
        }

        public void Update(DanhMucKyThuatXN dmKyThuatXN)
        {
            DanhMucKyThuatXN dm = dmKyThuatXNRepository.GetMulti(x => x.IDKyThuatXN == dmKyThuatXN.IDKyThuatXN).FirstOrDefault();
            if(dm != null)
                dmKyThuatXNRepository.Update(dmKyThuatXN);
            else
                 dmKyThuatXNRepository.Add(dmKyThuatXN);
        }

        public void Delete(int id)
        {
            dmKyThuatXNRepository.DeleteMulti(x => x.RowIDKyThuatXn == id);
        }

        public IEnumerable<DanhMucKyThuatXN> GetAll()
        {
            return dmKyThuatXNRepository.GetAll();
        }

        public DanhMucKyThuatXN GetById(string id)
        {
            int rowID = Int32.Parse(id);
            return dmKyThuatXNRepository.GetMulti(x => x.RowIDKyThuatXn == rowID).FirstOrDefault();
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<DanhMucKyThuatXN> GetAll(string keywork)
        {
            if (!string.IsNullOrEmpty(keywork))
                return this.dmKyThuatXNRepository.GetMulti(x => x.IDKyThuatXN.Contains(keywork) || x.TenHienThiKyThuat.Contains(keywork) || x.TenKyThuat.Contains(keywork));
            else
                return this.dmKyThuatXNRepository.GetAll();
        }

        public DanhMucKyThuatXN GetByMa(string ma)
        {
            return this.dmKyThuatXNRepository.GetSingleByCondition(x => x.IDKyThuatXN == ma);
        }
    }
}
