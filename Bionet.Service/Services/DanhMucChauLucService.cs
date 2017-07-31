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
    public interface IDanhMucChauLucService
    {
        IEnumerable<DanhMucChauLuc> GetAll();

        DanhMucChauLuc GetById(int id);

        void Add(DanhMucChauLuc danhMucChauLuc);

        void Delete(int id);


    }
    public class DanhMucChauLucService : IDanhMucChauLucService
    {
        private IDanhMucChauLucRepository _danhMucChauLucRepository;
        private IUnitOfWork _unitOfWork;

        public DanhMucChauLucService(IDanhMucChauLucRepository danhMucChauLucRepository, IUnitOfWork unitOfWork)
        {
            this._danhMucChauLucRepository = danhMucChauLucRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(DanhMucChauLuc danhMucChauLuc)
        {
            _danhMucChauLucRepository.Add(danhMucChauLuc);
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            _danhMucChauLucRepository.DeleteMulti(x => x.IDChauLuc == id);
            _unitOfWork.Commit();
        }

        public IEnumerable<DanhMucChauLuc> GetAll()
        {
            return _danhMucChauLucRepository.GetAll();
        }

        public DanhMucChauLuc GetById(int id)
        {
            return _danhMucChauLucRepository.GetSingleByCondition(x => x.IDChauLuc == id);
        }
    }
}
