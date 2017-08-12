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
    public interface IChiTietDanhGiaChatLuongService
    {
        void AddUp(ChiTietDanhGiaChatLuong ctDanhGia);

        ChiTietDanhGiaChatLuong GetByCondition(string keyword);

        IEnumerable<ChiTietDanhGiaChatLuong> GetAll();

        void Delete(string matiepnhan,string idphieu);

        void Save();
    }

    public class ChiTietDanhGiaChatLuongService : IChiTietDanhGiaChatLuongService
    {
        private IChiTietDanhGiaChatLuongRepository chiTietDanhGiaChatLuongRepository;
        private IUnitOfWork unitOfWork;

        public ChiTietDanhGiaChatLuongService(IChiTietDanhGiaChatLuongRepository _chiTietDanhGiaChatLuongRepository, IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
            this.chiTietDanhGiaChatLuongRepository = _chiTietDanhGiaChatLuongRepository;
        }

        public void Delete(string matiepnhan,string idphieu)
        {
            this.chiTietDanhGiaChatLuongRepository.DeleteMulti(x => x.MaTiepNhan == matiepnhan && x.IDPhieu == idphieu);
        }

        public void Save()
        {
            this.unitOfWork.Commit();
        }

        public void AddUp(ChiTietDanhGiaChatLuong ctDanhGia)
        {
            var ctdanhgiachatluong = this.chiTietDanhGiaChatLuongRepository.GetSingleByCondition(x => x.IDDanhGiaChatLuongMau == ctDanhGia.IDDanhGiaChatLuongMau);
            if(ctdanhgiachatluong == null)
                this.chiTietDanhGiaChatLuongRepository.Add(ctDanhGia);
            else
            {
                var term = ctdanhgiachatluong.IDMapsLyDoKhongDat;
                ctdanhgiachatluong = ctDanhGia;
                ctdanhgiachatluong.IDMapsLyDoKhongDat = term;
                this.chiTietDanhGiaChatLuongRepository.Update(ctdanhgiachatluong);
            }
        }

        public ChiTietDanhGiaChatLuong GetByCondition(string keyword)
        {
            return this.chiTietDanhGiaChatLuongRepository.GetSingleByCondition(x => x.MaTiepNhan == keyword || x.IDPhieu == keyword || x.IDDanhGiaChatLuongMau == keyword);
        }

        public IEnumerable<ChiTietDanhGiaChatLuong> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
