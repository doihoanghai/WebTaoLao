using Bionet.Data.Infrastructure;
using Bionet.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Data.Repositories
{
    public interface IDanhMucDichVuTheoDonViRepository : IRepository<DanhMucDichVuTheoDonVi>
    {
        long GetMaxRow();
        IEnumerable<DanhMucDichVuTheoDonVi> GetListDichVuByServicePackage(string servicePackageCode);

 
       
    }

    public class DanhMucDichVuTheoDonViRepository : RepositoryBase<DanhMucDichVuTheoDonVi>, IDanhMucDichVuTheoDonViRepository
    {

      
        public DanhMucDichVuTheoDonViRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<DanhMucDichVuTheoDonVi> GetListDichVuByServicePackage(string servicePackageCode)
        {
            throw new NotImplementedException();
        }

        public long GetMaxRow()
        {
            return DbContext.DanhMucDichVuTheoDonVi.Max(p => p.RowIDDichVuTheoDonVi);
        }
    }
}