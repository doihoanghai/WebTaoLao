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
    public interface IXN_TraKQ_ChiTietService
    {
        IEnumerable<XN_TraKQ_ChiTiet> GetAll();

        IEnumerable<XN_TraKQ_ChiTiet> GetAllByMaPhieuTiepNhan(string maPhieu, string maTiepNhan);

        void AddUpd(XN_TraKQ_ChiTiet xnTraKetQuaChiTiet);

        void Save();
    }
    public class XN_TraKQ_ChiTietService : IXN_TraKQ_ChiTietService
    {
        private IXN_TraKQ_ChiTietRepository xN_TraKQ_ChiTietRepository;
        private IUnitOfWork unitOfWork;
        
        public XN_TraKQ_ChiTietService(IXN_TraKQ_ChiTietRepository _xN_TraKQ_ChiTietRepository, IUnitOfWork _unitOfWork)
        {
            this.xN_TraKQ_ChiTietRepository = _xN_TraKQ_ChiTietRepository;
            this.unitOfWork = _unitOfWork;
        }
        public IEnumerable<XN_TraKQ_ChiTiet> GetAll()
        {
            return this.xN_TraKQ_ChiTietRepository.GetAll();
        }

        public IEnumerable<XN_TraKQ_ChiTiet> GetAllByMaPhieuTiepNhan(string maPhieu, string maTiepNhan)
        {
            return this.xN_TraKQ_ChiTietRepository.GetMulti(x => x.MaPhieu == maPhieu && x.MaTiepNhan == maTiepNhan);
        }

        public void AddUpd(XN_TraKQ_ChiTiet xnTraKetQuaChiTiet)
        {
            var model = this.xN_TraKQ_ChiTietRepository.GetMulti(x => x.RowIDXN_TraKetQua_ChiTiet == xnTraKetQuaChiTiet.RowIDXN_TraKetQua_ChiTiet).FirstOrDefault();
            if (model != null)
                this.xN_TraKQ_ChiTietRepository.Update(model);
            else
                this.xN_TraKQ_ChiTietRepository.Add(model);
        }

        public void Save()
        {
            this.unitOfWork.Commit();
        }
    }
}
