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
    public interface IDanhMucChuongTrinhService
    {
        IEnumerable<DanhMucChuongTrinh> GetAll();
        IEnumerable<DanhMucChuongTrinh> GetAll(string keyword);

        DanhMucChuongTrinh GetById(long id);

        void Add(DanhMucChuongTrinh danhmucDichVu);

        void Update(DanhMucChuongTrinh danhmucDichVu);

        void Delete(long id);

        void Save();
    }
    public class DanhMucChuongTrinhService : IDanhMucChuongTrinhService
    {
        private IDanhMucChuongTrinhRepository danhMucChuongTrinhRepository;
        private IUnitOfWork unitOfWork;

        public DanhMucChuongTrinhService(IDanhMucChuongTrinhRepository _danhMucChuongTrinhRepository, IUnitOfWork _unitOfWork)
        {
            this.danhMucChuongTrinhRepository = _danhMucChuongTrinhRepository;
            this.unitOfWork = _unitOfWork;
        }

        public void Add(DanhMucChuongTrinh danhmucDichVu)
        {
            danhMucChuongTrinhRepository.Add(danhmucDichVu);
        }

        public void Delete(long id)
        {
            danhMucChuongTrinhRepository.DeleteMulti(x => x.RowIDChuongTrinh == id);
        }

        public IEnumerable<DanhMucChuongTrinh> GetAll()
        {
            return this.danhMucChuongTrinhRepository.GetAll();
        }

        public IEnumerable<DanhMucChuongTrinh> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return danhMucChuongTrinhRepository.GetMulti(x => x.IDChuongTrinh.Contains(keyword) || x.TenChuongTrinh.Contains(keyword));
            else
                return danhMucChuongTrinhRepository.GetAll();
        }

        public DanhMucChuongTrinh GetById(long id)
        {
            return danhMucChuongTrinhRepository.GetSingleByCondition(x => x.RowIDChuongTrinh == id);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public void Update(DanhMucChuongTrinh danhmucDichVu)
        {
            danhMucChuongTrinhRepository.Update(danhmucDichVu);
        }
    }
}
