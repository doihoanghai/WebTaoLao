using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bionet.Web.Models;
using Bionet.Data.Repositories;
using Bionet.Data.Infrastructure;

namespace Bionet.Service.Services
{
    public interface IGoiDichVuTheoTrungTamService
    {
        IEnumerable<DanhMucGoiDichVuTrungTam> GetAll();
        IEnumerable<DanhMucGoiDichVuTrungTam> getAllTheoMaTT(string maTT);

        void delete(string MaTT);

        void Add(string maTT,List<DanhMucGoiDichVuChung> lstGoiDV);

        void Save();
    }

    public class GoiDichVuTrungTamService : IGoiDichVuTheoTrungTamService
    {
        private IGoiDichVuTrungTamRepository goiDichVuTheoTrungTamRepository;
        private IUnitOfWork _unitOfWork;

        public GoiDichVuTrungTamService(IGoiDichVuTrungTamRepository _goiDichVuTheoTrungTamRepository, IUnitOfWork unitOfWork)
        {
            this.goiDichVuTheoTrungTamRepository = _goiDichVuTheoTrungTamRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(string maTT, List<DanhMucGoiDichVuChung> lstGoiDV)
        {
           foreach(var goidv in lstGoiDV)
            {
                DanhMucGoiDichVuTrungTam gdvtt = new DanhMucGoiDichVuTrungTam();
                gdvtt.TenGoiDichVuChung = goidv.TenGoiDichVuChung;
                gdvtt.RowIDGoiDichVuTrungTam = goidv.RowIDGoiDichVuChung;
                gdvtt.IDGoiDichVuChung = goidv.IDGoiDichVuChung;
                gdvtt.DonGia = goidv.DonGia;
                gdvtt.ChietKhau = goidv.ChietKhau;
                gdvtt.MaTT = maTT;

                this.goiDichVuTheoTrungTamRepository.Add(gdvtt);
            }
        }

        public void delete(string MaTT)
        {
            this.goiDichVuTheoTrungTamRepository.DeleteMulti(x => x.MaTT == MaTT);
        }

        public IEnumerable<DanhMucGoiDichVuTrungTam> GetAll()
        {
            return this.goiDichVuTheoTrungTamRepository.GetAll();
        }

        public IEnumerable<DanhMucGoiDichVuTrungTam> getAllTheoMaTT(string maTT)
        {
            return goiDichVuTheoTrungTamRepository.GetMulti(x => x.MaTT == maTT);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
