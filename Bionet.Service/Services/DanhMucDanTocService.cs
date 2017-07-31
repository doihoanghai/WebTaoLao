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
    public interface IDanhMucDanTocService
    {
        IEnumerable<DanhMucDanToc> GetAll();
    }
    public class DanhMucDanTocService : IDanhMucDanTocService
    {
        private IDanhMucDanTocRepository danTocRepository;
        private IUnitOfWork unitOfWork;

        public DanhMucDanTocService(IDanhMucDanTocRepository _danTocRepository, IUnitOfWork _unitOfWork)
        {
            this.danTocRepository = _danTocRepository;
            this.unitOfWork = _unitOfWork;
        }
        public IEnumerable<DanhMucDanToc> GetAll()
        {
            return this.danTocRepository.GetAll();
        }
    }
}
