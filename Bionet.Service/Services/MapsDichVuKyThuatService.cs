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
    public interface IMapDichVuKyThuatService
    {
        IEnumerable<MapsXN_DichVu> getall();

        IEnumerable<MapsXN_DichVu> getall(string maDichVU);

        void Add(MapsXN_DichVu map);

        void Delete(int rowID);

        void DeleteMulti(string maDichVu);
        void Update(MapsXN_DichVu map);

        void Save();
    }

    public class MapDichVuKyThuatService : IMapDichVuKyThuatService
    {
        private IMapsXN_DichVuRepository _mapXNKyThuatRepository;
        private IUnitOfWork _unitOfWork;

        public MapDichVuKyThuatService(IMapsXN_DichVuRepository mapXNKyThuatRepository, IUnitOfWork unitOfWork)
        {
            _mapXNKyThuatRepository = mapXNKyThuatRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(MapsXN_DichVu map)
        {
            this._mapXNKyThuatRepository.Add(map);
        }

        public void Delete(int rowID)
        {
            this._mapXNKyThuatRepository.DeleteMulti(x => x.RowIDDichVuMaps == rowID);
        }

        public void DeleteMulti(string maDichVu)
        {
            this._mapXNKyThuatRepository.DeleteMulti(x => x.IDDichVu == maDichVu);
        }

        public IEnumerable<MapsXN_DichVu> getall()
        {
            return this._mapXNKyThuatRepository.GetAll();
        }

        public IEnumerable<MapsXN_DichVu> getall(string maDichVu)
        {
            return this._mapXNKyThuatRepository.GetMulti(x => x.IDDichVu == maDichVu);
        }

        public void Save()
        {
            this._unitOfWork.Commit();
        }

        public void Update(MapsXN_DichVu map)
        {
            this._mapXNKyThuatRepository.Update(map);
        }
    }
}
