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
    public interface IGoiDichVuChungService
    {
        IEnumerable<DanhMucGoiDichVuChung> GetAll();


        IEnumerable<DanhMucGoiDichVuChung> GetAll(List<string> maGoi);

        DanhMucGoiDichVuChung getByMa(string ma);

        void Add(DanhMucGoiDichVuChung goiDVChung);

        void Update(DanhMucGoiDichVuChung goiDVChung);

        void Delete(string ma);

        void Save();

    }
    public class GoiDichVuChungService : IGoiDichVuChungService
    {
        private IDanhMucGoiDichVuChungRepository goiDichVuChungoRepository;
        private IUnitOfWork unitOfWork;

        public GoiDichVuChungService(IDanhMucGoiDichVuChungRepository _goiDichVuChungoRepository, IUnitOfWork _unitOfWork)
        {
            this.goiDichVuChungoRepository = _goiDichVuChungoRepository;
            this.unitOfWork = _unitOfWork;
        }

        public void Add(DanhMucGoiDichVuChung goiDVChung)
        {

            int maxRow = goiDichVuChungoRepository.GetMaxRow();
            string lastID = goiDichVuChungoRepository.GetMulti(p => p.RowIDGoiDichVuChung == maxRow).FirstOrDefault().IDGoiDichVuChung;
            int numID = Convert.ToInt32(lastID.Substring(5)) + 1;
            string idDV = string.Empty;
            if (numID <= 9)
                idDV = "DVGXN000" + numID;
            else if (numID > 9 && numID <= 99)
                idDV = "DVGXN00" + numID;
            else if (numID > 99 && numID <= 999)
                idDV = "DVGXN0" + numID;
            else
                idDV = "DVGXN" + numID;
            goiDVChung.IDGoiDichVuChung = idDV;
            goiDichVuChungoRepository.Add(goiDVChung);

    }

        public void Delete(string ma)
        {
            this.goiDichVuChungoRepository.DeleteMulti(x => x.IDGoiDichVuChung == ma);
        }

        public IEnumerable<DanhMucGoiDichVuChung> GetAll()
        {
            return this.goiDichVuChungoRepository.GetAll();
        }

        public IEnumerable<DanhMucGoiDichVuChung> GetAll(List<string> maGoi)
        {
            return this.goiDichVuChungoRepository.GetMulti(x => maGoi.Contains(x.IDGoiDichVuChung));
                 
        }

        public DanhMucGoiDichVuChung getByMa(string ma)
        {
            return this.goiDichVuChungoRepository.GetSingleByCondition(x => x.TenGoiDichVuChung == ma);
        }

        public void Save()
        {
            this.unitOfWork.Commit();
        }

        public void Update(DanhMucGoiDichVuChung goiDVChung)
        {
            this.goiDichVuChungoRepository.Update(goiDVChung);
        }
    }
}
