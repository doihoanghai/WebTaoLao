using Bionet.Data.Infrastructure;
using Bionet.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Data.Repositories
{
    public interface IDotChuanDoanRepository : IRepository<DotChuanDoan>
    {
    }

    public class DotChuanDoanRepository : RepositoryBase<DotChuanDoan>, IDotChuanDoanRepository
    {
        public DotChuanDoanRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
