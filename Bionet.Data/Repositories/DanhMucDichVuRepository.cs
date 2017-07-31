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
    public interface IDanhMucDichVuRepository : IRepository<DanhMucDichVu>
    {
        int GetMaxRow();

        IEnumerable<DanhMucDichVu> GetListDichVuByServicePackage(string servicePackageCode);
    }

    public class DanhMucDichVuRepository : RepositoryBase<DanhMucDichVu>, IDanhMucDichVuRepository
    {
        public DanhMucDichVuRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<DanhMucDichVu> GetListDichVuByServicePackage(string servicePackageCode)
        {
            var query = from dv in DbContext.DanhMucDichVu
                        join ct in DbContext.ChiTietGoiDichVuChung on dv.IDDichVu equals ct.IDDichVu
                        where ct.IDGoiDichVuChung == servicePackageCode
                        select dv;
            return query;
        }

        public int GetMaxRow()
        {
            return DbContext.DanhMucDichVu.Max(p => p.RowIDDichVu);
        }
    }
}