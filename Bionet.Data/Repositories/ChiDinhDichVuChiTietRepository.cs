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
    public interface IChiDinhDichVuChiTietRepository : IRepository<ChiDinhDichVuChiTiet>
    {
        long getMaxRow();
    }

    public class ChiDinhDichVuChiTietRepository : RepositoryBase<ChiDinhDichVuChiTiet>, IChiDinhDichVuChiTietRepository
    {
        public ChiDinhDichVuChiTietRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public long getMaxRow()
        {
            return DbContext.ChiDinhDichVuChiTiet.Max(p => p.RowIDDichVuChiTiet);
        }
    }
}
