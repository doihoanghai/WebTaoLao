using Bionet.Common.Exceptions;
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
    public interface IDanhGiaChatLuongService
    {
        IEnumerable<DanhMucDanhGiaChatLuongMau> GetAll();
        IEnumerable<DanhMucDanhGiaChatLuongMau> GetAll(string keyword);

        DanhMucDanhGiaChatLuongMau GetById(int id);

        void Add(DanhMucDanhGiaChatLuongMau danhmucDichVu);

        void Update(DanhMucDanhGiaChatLuongMau danhmucDichVu);

        void Delete(int id);

        void Save();
    }
    public class DanhGiaChatLuongService : IDanhGiaChatLuongService
    {
        private IDanhMucDanhGiaChatLuongMauRepository danhGiaChatLuongRepository;
        private IUnitOfWork unitOfWork;

        public DanhGiaChatLuongService(IDanhMucDanhGiaChatLuongMauRepository _danhGiaChatLuongRepository, IUnitOfWork _unitOfWork)
        {
            this.danhGiaChatLuongRepository = _danhGiaChatLuongRepository;
            this.unitOfWork = _unitOfWork;
        }

        public void Add(DanhMucDanhGiaChatLuongMau danhGiaChatLuong)
        {
            if (danhGiaChatLuongRepository.CheckContains(x => x.IDDanhGiaChatLuongMau == danhGiaChatLuong.IDDanhGiaChatLuongMau))
                throw new NameDuplicatedException("Mã không được trùng");
            danhGiaChatLuongRepository.Add(danhGiaChatLuong);
        }

        public void Delete(int id)
        {
            danhGiaChatLuongRepository.DeleteMulti(x => x.RowIDChatLuongMau == id);
        }

        public IEnumerable<DanhMucDanhGiaChatLuongMau> GetAll()
        {
            return this.danhGiaChatLuongRepository.GetAll();
        }

        public IEnumerable<DanhMucDanhGiaChatLuongMau> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return danhGiaChatLuongRepository.GetMulti(x => x.IDDanhGiaChatLuongMau.Contains(keyword) || x.ChatLuongMau.Contains(keyword));
            else
                return danhGiaChatLuongRepository.GetAll();
        }

        public DanhMucDanhGiaChatLuongMau GetById(int id)
        {
            return danhGiaChatLuongRepository.GetSingleByCondition(x => x.RowIDChatLuongMau == id);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public void Update(DanhMucDanhGiaChatLuongMau danhGiaChatLuong)
        {
            danhGiaChatLuongRepository.Update(danhGiaChatLuong);
        }
    }
}
