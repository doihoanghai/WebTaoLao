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
    public interface IChiTietGoiDichVuService
    {
        IEnumerable<DanhMucDichVu> GetServiceByServicePackage(string servicePackageCode);

        IEnumerable<ChiTietGoiDichVuChung> getAll();

        void DeleteServicePackage(string servicePackageCode);

        void AddServicePackageAndService(string servicePackageCode, List<DanhMucDichVu> lstService);

        void Save();

    }
    public class ChiTietGoiDichVuService : IChiTietGoiDichVuService
    {
        private IChiTietGoiDichVuChungRepository chiTietGoiDichVuChungRepository;
        private IDanhMucDichVuRepository danhMucDichVuRepository;
        private IUnitOfWork unitOfWork;

        public ChiTietGoiDichVuService(IChiTietGoiDichVuChungRepository _chiTietGoiDichVuChungRepository, IDanhMucDichVuRepository _danhMucDichVuRepository, IUnitOfWork _unitOfWork)
        {
            this.chiTietGoiDichVuChungRepository = _chiTietGoiDichVuChungRepository;
            this.danhMucDichVuRepository = _danhMucDichVuRepository;
            this.unitOfWork = _unitOfWork;
        }

        public void AddServicePackageAndService(string servicePackageCode, List<DanhMucDichVu> lstService)
        {
            foreach(DanhMucDichVu service in lstService)
            {
                ChiTietGoiDichVuChung serviceDetail = new ChiTietGoiDichVuChung();
                serviceDetail.IDGoiDichVuChung = servicePackageCode;
                serviceDetail.IDDichVu = service.IDDichVu;
                this.chiTietGoiDichVuChungRepository.Add(serviceDetail);
            }
        }

        public void DeleteServicePackage(string servicePackageCode)
        {
            this.chiTietGoiDichVuChungRepository.DeleteMulti(x => x.IDGoiDichVuChung == servicePackageCode);
        }

        public IEnumerable<ChiTietGoiDichVuChung> getAll()
        {
            return this.chiTietGoiDichVuChungRepository.GetAll();
        }

        public IEnumerable<DanhMucDichVu> GetAllService()
        {
            throw new NotImplementedException();
        }


        public IEnumerable<DanhMucDichVu> GetServiceByServicePackage(string servicePackageCode)
        {
            return this.danhMucDichVuRepository.GetListDichVuByServicePackage(servicePackageCode);
        }

        public void Save()
        {
            this.unitOfWork.Commit();
        }
    }
}
