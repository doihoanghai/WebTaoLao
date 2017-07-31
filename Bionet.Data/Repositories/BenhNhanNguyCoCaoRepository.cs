using Bionet.Data.Infrastructure;
using Bionet.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Data.Repositories
{
    public interface IBenhNhanNguyCoCaoRepository : IRepository<BenhNhanNguyCoCao>
    {
    }
    public class BenhNhanNguyCoCaoRepository : RepositoryBase<BenhNhanNguyCoCao>, IBenhNhanNguyCoCaoRepository
    {
        public BenhNhanNguyCoCaoRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
