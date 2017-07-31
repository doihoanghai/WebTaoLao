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
    public interface IXN_TraKetQuaService
    {
        IEnumerable<XN_TraKetQua> GetAll();

        void AddUpd(XN_TraKetQua xnTraKetQua);

        void Save();
    }
    public class XN_TraKetQuaService : IXN_TraKetQuaService
    {
        private IXN_TraKetQuaRepository xN_TraKetQuaRepository;
        private IUnitOfWork unitOfWork;

        public XN_TraKetQuaService(IXN_TraKetQuaRepository _xN_TraKetQuaRepository, IUnitOfWork _unitOfWork)
        {
            this.xN_TraKetQuaRepository = _xN_TraKetQuaRepository;
            this.unitOfWork = _unitOfWork;
        }
        public IEnumerable<XN_TraKetQua> GetAll()
        {
            return this.xN_TraKetQuaRepository.GetAll();
        }

        public void AddUpd(XN_TraKetQua xnTraKetQua)
        {
            var model = this.xN_TraKetQuaRepository.GetMulti(x => x.MaPhieu == xnTraKetQua.MaPhieu && x.MaTiepNhan == xnTraKetQua.MaTiepNhan).FirstOrDefault();
            if (model != null)
                this.xN_TraKetQuaRepository.Update(model);
            else
                this.xN_TraKetQuaRepository.Add(model);
        }

        public void Save()
        {
            this.unitOfWork.Commit();
        }
    }
}
