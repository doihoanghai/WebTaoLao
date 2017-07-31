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
    public interface INhomService
    {
        IEnumerable<DanhMucNhom> GetAll();
        DanhMucNhom GetById(int id);
    }
    public class NhomService : INhomService
    {
        private IDanhMucNhomRepository nhomRepository;
        private IUnitOfWork unitOfWork;

        public NhomService(IDanhMucNhomRepository _nhomRepository, IUnitOfWork _unitOfWork)
        {
            this.nhomRepository = _nhomRepository;
            this.unitOfWork = _unitOfWork;
        }

        public IEnumerable<DanhMucNhom> GetAll()
        {
            return nhomRepository.GetAll();
        }

        public DanhMucNhom GetById(int id)
        {
            return nhomRepository.GetSingleByCondition(x => x.RowIDNhom == id);
        }

    }
}
