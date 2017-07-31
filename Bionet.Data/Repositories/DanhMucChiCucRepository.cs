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
    public interface IDanhMucChiCucRepository : IRepository<DanhMucChiCuc>
    {
        int GetMaxRow();
    }

    public class DanhMucChiCucRepository : RepositoryBase<DanhMucChiCuc>, IDanhMucChiCucRepository
    {
        public DanhMucChiCucRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public int GetMaxRow()
        {
            return DbContext.DanhMucChiCuc.Max(p => p.RowIDChiCuc);
        }

    }
}