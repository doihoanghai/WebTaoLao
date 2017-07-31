using Bionet.Data.Infrastructure;
using Bionet.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Data.Repositories
{
    public interface IApplicationUserRoleRepository : IRepository<ApplicationUserRole>
    {

    }
    public class ApplicationUserRoleRepository : RepositoryBase<ApplicationUserRole>, IApplicationUserRoleRepository
    {
        public ApplicationUserRoleRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
