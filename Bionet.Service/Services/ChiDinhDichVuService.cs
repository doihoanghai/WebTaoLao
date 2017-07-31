using Bionet.Data.Infrastructure;
using Bionet.Data.Repositories;
using Bionet.Web.Models;
using System;
using System.Collections.Generic;

namespace Bionet.Service.Services
{
    public interface IChiDinhDichVuService
    {
        IEnumerable<ChiDinhDichVu> GetAllDichVu();
        IEnumerable<ChiDinhDichVu> GetAllDichVu(string maDonVi);

        IEnumerable<ChiDinhDichVuChiTiet> GetAllChiTietDV(string maDichVu);
        

        void Delete(string maChiDinh);

        void Add(ChiDinhDichVu chiDinhDichVu,List<ChiDinhDichVuChiTiet> lstChiTiet); 

        void Save();

        ChiDinhDichVu getChiDinhTheoId(string maChiDinh);

        void UpdateCDDV(ChiDinhDichVu cddv);
        void UpdateCDDVCT(ChiDinhDichVuChiTiet cddvct);

    }

    public class ChiDinhDichVuService : IChiDinhDichVuService
    {
        private IChiDinhDichVuRepository chiDinhDichVuRepository;
        private IChiDinhDichVuChiTietRepository chiDinhDichVuChiTietRepository;
        private IUnitOfWork unitOfWork;

        public ChiDinhDichVuService(IChiDinhDichVuRepository _chiDinhDichVuRepository,IChiDinhDichVuChiTietRepository _chiDinhDichVuChiTietRepository, IUnitOfWork _unitOfWork)
        {
            this.chiDinhDichVuRepository = _chiDinhDichVuRepository;
            this.chiDinhDichVuChiTietRepository = _chiDinhDichVuChiTietRepository;
            this.unitOfWork = _unitOfWork;
        }

        public void Add(ChiDinhDichVu chiDinhDichVu, List<ChiDinhDichVuChiTiet> lstChiTiet)
        {
            this.chiDinhDichVuChiTietRepository.GetAll();
            this.chiDinhDichVuRepository.GetAll();

            long maxRowChiDinh = chiDinhDichVuRepository.getMaxRow() + 1;
            chiDinhDichVu.RowIDChiDinh = maxRowChiDinh;
            chiDinhDichVuRepository.Add(chiDinhDichVu);

            long maxRowChiTiet = chiDinhDichVuChiTietRepository.getMaxRow() + 1;
            foreach (var c in lstChiTiet)
            {
                c.RowIDDichVuChiTiet = maxRowChiTiet++;
                this.chiDinhDichVuChiTietRepository.Add(c);
            }
            
        }

        public void Delete(string maChiDinh)
        {
            this.chiDinhDichVuChiTietRepository.DeleteMulti(p => p.MaChiDinh == maChiDinh);
            this.chiDinhDichVuRepository.DeleteMulti(p => p.MaChiDinh == maChiDinh);
        }


        public IEnumerable<ChiDinhDichVuChiTiet> GetAllChiTietDV(string maDichVu)
        {
            return this.chiDinhDichVuChiTietRepository.GetMulti(p => p.MaDichVu == maDichVu);
        }

        public IEnumerable<ChiDinhDichVu> GetAllDichVu()
        {
            return this.chiDinhDichVuRepository.GetAll();
        }

        public IEnumerable<ChiDinhDichVu> GetAllDichVu(string maDonVi)
        {
            return this.chiDinhDichVuRepository.GetMulti(p => maDonVi.StartsWith(p.MaDonVi));
        }

        public ChiDinhDichVu getChiDinhTheoId(string maChiDinh)
        {
            return this.chiDinhDichVuRepository.GetSingleByCondition(p => p.MaChiDinh == maChiDinh);
        }

       
        public void Save()
        {
            this.unitOfWork.Commit();
        }

        public void UpdateCDDV(ChiDinhDichVu cddv)
        {
            this.chiDinhDichVuRepository.Update(cddv);
        }

        public void UpdateCDDVCT(ChiDinhDichVuChiTiet cddvct)
        {
            this.chiDinhDichVuChiTietRepository.Update(cddvct);
        }
    }
}
