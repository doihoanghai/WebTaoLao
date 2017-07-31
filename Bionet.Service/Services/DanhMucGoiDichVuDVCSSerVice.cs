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
    public interface IGoiDichVuDVCSService
    {
        IEnumerable<DanhMucGoiDichVuDVCS> GetAll();

        IEnumerable<DanhMucGoiDichVuDVCS> GetAllTheoMaDonVi(string lvCode);

        void delete(string madv);

        void Add(string MaDVCS, List<DanhMucGoiDichVuChung> lstGDV);

        void Save();

        void Update(DanhMucGoiDichVuDVCS goidv);

        void Add(DanhMucGoiDichVuDVCS goidv);

        void addup(DanhMucGoiDichVuDVCS lst);
    }
    public class GoiDichVuDVCSService : IGoiDichVuDVCSService
    {
        private IDanhMucGoiDichVuDVCSRepository goiDichVuDVCSRepository;
        private IUnitOfWork unitOfWork;

        public GoiDichVuDVCSService(IDanhMucGoiDichVuDVCSRepository _goiDichVuChungoRepository, IUnitOfWork _unitOfWork)
        {
            this.goiDichVuDVCSRepository = _goiDichVuChungoRepository;
            this.unitOfWork = _unitOfWork;
        }

        public void Add(DanhMucGoiDichVuDVCS goidv)
        {
            throw new NotImplementedException();
        }

        public void Add(string MaDVCS, List<DanhMucGoiDichVuChung> lstGDV)
        {
            foreach(var a in lstGDV)
            {
                DanhMucGoiDichVuDVCS gdvdv = new DanhMucGoiDichVuDVCS();

                gdvdv.TenGoiDichVuChung = a.TenGoiDichVuChung;
                gdvdv.RowIDGoiDichVuTrungTam = a.RowIDGoiDichVuChung;
                gdvdv.IDGoiDichVuChung = a.IDGoiDichVuChung;
                gdvdv.DonGia = a.DonGia;
                gdvdv.ChietKhau = a.ChietKhau;
                gdvdv.MaDVCS = MaDVCS;

                this.goiDichVuDVCSRepository.Add(gdvdv);
            }
        }

        public void addup(DanhMucGoiDichVuDVCS goidv)
        {
           
            if (this.goiDichVuDVCSRepository.GetMulti(a => a.IDGoiDichVuChung == goidv.IDGoiDichVuChung) != null)
            {
                this.goiDichVuDVCSRepository.Update(goidv);
            }
            else
                this.goiDichVuDVCSRepository.Add(goidv);
            
        }

        public void delete(string madv)
        {
            this.goiDichVuDVCSRepository.DeleteMulti(x => x.MaDVCS == madv);
        }

        public IEnumerable<DanhMucGoiDichVuDVCS> GetAll()
        {
            return this.goiDichVuDVCSRepository.GetAll();
        }

        public IEnumerable<DanhMucGoiDichVuDVCS> GetAllTheoMaDonVi(string lvCode)
        {
            return this.goiDichVuDVCSRepository.GetMulti(x => x.MaDVCS.StartsWith(lvCode));
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public void Update(DanhMucGoiDichVuDVCS goidv)
        {
            this.goiDichVuDVCSRepository.Update(goidv);
        }
    }
}
