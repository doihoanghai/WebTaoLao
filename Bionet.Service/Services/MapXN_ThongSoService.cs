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
    public interface IMapsXNThongSoService
    {
        IEnumerable<MapsXN_ThongSo> getall();

        IEnumerable<MapsXN_ThongSo> getall(string maKyThuat);

        void Add(MapsXN_ThongSo map);

        void Delete(int rowID);

        void Update(MapsXN_ThongSo map);

        void Save();
    }

    public class MapsXNThongSoService : IMapsXNThongSoService
    {
        private MapsXNThongSoRepository _mapX_ThongSoRepository;
        private UnitOfWork _unitOfWork;

        public MapsXNThongSoService(MapsXNThongSoRepository mapX_ThongSoRepository,UnitOfWork unitOfWork)
        {
            _mapX_ThongSoRepository = mapX_ThongSoRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(MapsXN_ThongSo map)
        {
            this._mapX_ThongSoRepository.Add(map);
        }

        public void Delete(int rowID)
        {
            this._mapX_ThongSoRepository.DeleteMulti(x => x.RowIDMaps == rowID);
        }

        public IEnumerable<MapsXN_ThongSo> getall()
        {
            return this._mapX_ThongSoRepository.GetAll();
        }

        public IEnumerable<MapsXN_ThongSo> getall(string maKyThuat)
        {
            return this._mapX_ThongSoRepository.GetMulti(x => x.IDKyThuatXN == maKyThuat);
        }

        public void Save()
        {
            this._unitOfWork.Commit();
        }

        public void Update(MapsXN_ThongSo map)
        {
            this._mapX_ThongSoRepository.Update(map);
        }
    }
}
