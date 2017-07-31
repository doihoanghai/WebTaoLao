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
    public interface IXN_KetQua_ChiTietService
    {
        IEnumerable<XN_KetQua_ChiTiet> GetAll();

        IEnumerable<XN_KetQua_ChiTiet> GetAllByMaKQ(string maKq);

        void AddUpd(XN_KetQua_ChiTiet xnKetQuaChiTiet);

        void Save();
    }
    public class XN_KetQua_ChiTietService : IXN_KetQua_ChiTietService
    {
        private IXN_KetQua_ChiTietRepository xN_KetQua_ChiTietRepository;
        private IUnitOfWork unitOfWork;

        public XN_KetQua_ChiTietService(IXN_KetQua_ChiTietRepository _xN_KetQua_ChiTietRepository, IUnitOfWork _unitOfWork)
        {
            this.xN_KetQua_ChiTietRepository = _xN_KetQua_ChiTietRepository;
            this.unitOfWork = _unitOfWork;
        }
        public IEnumerable<XN_KetQua_ChiTiet> GetAll()
        {
            return this.xN_KetQua_ChiTietRepository.GetAll();
        }

        public void AddUpd(XN_KetQua_ChiTiet xnKetQuaChiTiet)
        {
            var model = this.xN_KetQua_ChiTietRepository.GetMulti(x => x.RowIDKetQuaChiTiet == xnKetQuaChiTiet.RowIDKetQuaChiTiet).FirstOrDefault();
            if (model != null)
                this.xN_KetQua_ChiTietRepository.Update(model);
            else
                this.xN_KetQua_ChiTietRepository.Add(model);
        }

        public void Save()
        {
            this.unitOfWork.Commit();
        }

        public IEnumerable<XN_KetQua_ChiTiet> GetAllByMaKQ(string maKq)
        {
            return this.xN_KetQua_ChiTietRepository.GetMulti(x => x.MaKQ == maKq);
        }
    }
}
