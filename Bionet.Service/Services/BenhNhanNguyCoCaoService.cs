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
    public interface IBenhNhanNguyCoCaoService
    {
        IEnumerable<BenhNhanNguyCoCao> GetAll();

        IEnumerable<BenhNhanNguyCoCao> GetAll(string lvCode);
    }
    public class BenhNhanNguyCoCaoService : IBenhNhanNguyCoCaoService
    {
        private IBenhNhanNguyCoCaoRepository benhNhanNguyCoCaoRepository;
        private IUnitOfWork unitOfWork;

        public BenhNhanNguyCoCaoService(IBenhNhanNguyCoCaoRepository _benhNhanNguyCoCaoRepository, IUnitOfWork _unitOfWork)
        {
            this.benhNhanNguyCoCaoRepository = _benhNhanNguyCoCaoRepository;
            this.unitOfWork = _unitOfWork;
        }
        public IEnumerable<BenhNhanNguyCoCao> GetAll()
        {
            return this.benhNhanNguyCoCaoRepository.GetAll();
        }

        public IEnumerable<BenhNhanNguyCoCao> GetAll(string lvCode)
        {
            if (lvCode != "0")
                return benhNhanNguyCoCaoRepository.GetMulti(x => x.MaDonVi.StartsWith(lvCode));
            else
                return benhNhanNguyCoCaoRepository.GetAll();
        }
    }
}
