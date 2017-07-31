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
    public interface ITiepNhanService
    {
        IEnumerable<TiepNhan> GetAll();

        IEnumerable<TiepNhan> GetAll(string lvCode);

        void AddUpd(TiepNhan tiepNhan);

        void Save();
        
    }
    public class TiepNhanService : ITiepNhanService
    {
        private ITiepNhanRepository tiepNhanRepository;
        private IUnitOfWork unitOfWork;

        public void AddUpd(TiepNhan tiepNhan)
        {
            var model = this.tiepNhanRepository.GetMulti(x => x.MaPhieu == tiepNhan.MaPhieu && x.MaTiepNhan == tiepNhan.MaTiepNhan).FirstOrDefault();
            if (model != null)
                this.tiepNhanRepository.Update(model);
            else
                this.tiepNhanRepository.Add(model);
        }

        public TiepNhanService(ITiepNhanRepository _tiepNhanRepository, IUnitOfWork _unitOfWork)
        {
            this.tiepNhanRepository = _tiepNhanRepository;
            this.unitOfWork = _unitOfWork;
        }

        public void Save()
        {
            unitOfWork.Commit();
        }
       
        public IEnumerable<TiepNhan> GetAll()
        {
            return this.tiepNhanRepository.GetAll();
        }

        public IEnumerable<TiepNhan> GetAll(string lvCode)
        {
            if (lvCode != "0")
                return this.tiepNhanRepository.GetMulti(x => x.MaDVCS.StartsWith(lvCode));
            else
                return this.tiepNhanRepository.GetAll();
        }
    }
}
