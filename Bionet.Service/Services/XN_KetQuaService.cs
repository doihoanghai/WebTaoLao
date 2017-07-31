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
    public interface IXN_KetQuaService
    {
        IEnumerable<XN_KetQua> GetAll();

        void AddUpd(XN_KetQua xnKetQua);

        void Save();
    }

    public class XN_KetQuaService: IXN_KetQuaService
    {
        private IXN_KetQuaRepository xN_KetQuaRepository;
        private IUnitOfWork unitOfWork;

        public XN_KetQuaService(IXN_KetQuaRepository _xN_KetQuaRepository, IUnitOfWork _unitOfWork)
        {
            this.xN_KetQuaRepository = _xN_KetQuaRepository;
            this.unitOfWork = _unitOfWork;
        }
        public IEnumerable<XN_KetQua> GetAll()
        {
            return this.xN_KetQuaRepository.GetAll();
        }


        public void Save()
        {
            this.unitOfWork.Commit();
        }

        public void AddUpd(XN_KetQua xnKetQua)
        {
            var model = this.xN_KetQuaRepository.GetMulti(x => x.MaKetQua == xnKetQua.MaKetQua).FirstOrDefault();
            if (model != null)
                this.xN_KetQuaRepository.Update(model);
            else
                this.xN_KetQuaRepository.Add(model);
        }
    }
}
