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
    public interface IChiDinhDichVuRepository : IRepository<ChiDinhDichVu>
    {
        long getMaxRow();
    }

    public class ChiDinhDichVuRepository : RepositoryBase<ChiDinhDichVu>, IChiDinhDichVuRepository
    {
        public ChiDinhDichVuRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public long getMaxRow()
        {
            return DbContext.ChiDinhDichVu.Max(p => p.RowIDChiDinh);
        }
    }
}
