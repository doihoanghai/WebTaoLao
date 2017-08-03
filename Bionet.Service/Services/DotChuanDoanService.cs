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
    public interface IDotChuanDoanService
    {

        IEnumerable<DotChuanDoan> GetAll();
        IEnumerable<DotChuanDoan> GetByMaBN(string idBN);
        void Add(DotChuanDoan patient);

        DotChuanDoan GetByMa(string maCD);

        IEnumerable<DotChuanDoan> GetByMaKH(string maKH);

        void Update(DotChuanDoan patient);
        void Save();
    }
    public class DotChuanDoanService : IDotChuanDoanService
    {
        private IDotChuanDoanRepository dotChuanDoanRepository;
        private IUnitOfWork unitOfWork;

        public DotChuanDoanService(IDotChuanDoanRepository _dotChuanDoanRepository, IUnitOfWork _unitOfWork)
        {
            this.dotChuanDoanRepository = _dotChuanDoanRepository;
            this.unitOfWork = _unitOfWork;
        }


        public void Add(DotChuanDoan dotchuandoan)
        {
            dotChuanDoanRepository.Add(dotchuandoan);
        }

        public IEnumerable<DotChuanDoan> GetAll()
        {
            return this.dotChuanDoanRepository.GetAll();
        }

        public IEnumerable<DotChuanDoan> GetByMaBN(string idBN)
        {
            return dotChuanDoanRepository.GetMulti(x => x.MaBenhNhan == idBN);
        }

        public IEnumerable<DotChuanDoan> GetByMaKH(string maKH)
        {
            return dotChuanDoanRepository.GetMulti(x => x.MaKhachHang == maKH);
        }
        public void Save()
        {
            unitOfWork.Commit();
        }

        public void Update(DotChuanDoan patient)
        {
            dotChuanDoanRepository.Update(patient);
        }

        public DotChuanDoan GetByMa(string maCD)
        {
            return this.dotChuanDoanRepository.GetSingleByCondition(x => x.MaDotChuanDoan == maCD);
        }
    }
}
