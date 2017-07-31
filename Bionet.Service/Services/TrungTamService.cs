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
    public interface ITrungTamService
    {
        IEnumerable<DanhMucTrungTamSangLoc> GetAll();
        IEnumerable<DanhMucTrungTamSangLoc> GetAll(string keyword);
        DanhMucTrungTamSangLoc GetById(int id);
        DanhMucTrungTamSangLoc GetByMa(string id);
        void Add(DanhMucTrungTamSangLoc dmTrungTam);
        void Update(DanhMucTrungTamSangLoc dmTrungTam);
        void Delete(int id);
        void Save();
    }
    public class TrungTamService : ITrungTamService
    {
        private IDanhMucTrungTamSangLocRepository trungtamRepository;
        private IUnitOfWork unitOfWork;

        public TrungTamService(IDanhMucTrungTamSangLocRepository _trungtamRepository, IUnitOfWork _unitOfWork)
        {
            this.trungtamRepository = _trungtamRepository;
            this.unitOfWork = _unitOfWork;
        }

        public void Add(DanhMucTrungTamSangLoc dmTrungTam)
        {
            trungtamRepository.Add(dmTrungTam);
        }

        public void Delete(int id)
        {
            trungtamRepository.DeleteMulti(x => x.RowIDTTSL == id);
        }

        public IEnumerable<DanhMucTrungTamSangLoc> GetAll()
        {
            return trungtamRepository.GetAll();
        }

        public IEnumerable<DanhMucTrungTamSangLoc> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return trungtamRepository.GetMulti(x => x.MaTTSL.Contains(keyword) || x.TenTTSL.Contains(keyword) || x.DiaChiTTSL.Contains(keyword) || x.SDTTTSL.Contains(keyword));
            else
                return trungtamRepository.GetAll();
        }

        public DanhMucTrungTamSangLoc GetById(int id)
        {
            return trungtamRepository.GetSingleByCondition(x => x.RowIDTTSL == id);
        }

        public DanhMucTrungTamSangLoc GetByMa(string id)
        {
            return trungtamRepository.GetSingleByCondition(x => x.MaTTSL == id);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public void Update(DanhMucTrungTamSangLoc dmTrungTam)
        {
            trungtamRepository.Update(dmTrungTam);
        }
    }
}
