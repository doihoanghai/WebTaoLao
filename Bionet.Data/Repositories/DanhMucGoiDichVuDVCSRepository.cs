using Bionet.Data.Infrastructure;
using Bionet.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Data.Repositories
{
    public interface IDanhMucGoiDichVuDVCSRepository : IRepository<DanhMucGoiDichVuDVCS>
    {
    }

    public class DanhMucGoiDichVuDVCSRepository : RepositoryBase<DanhMucGoiDichVuDVCS>, IDanhMucGoiDichVuDVCSRepository { 
        public DanhMucGoiDichVuDVCSRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
