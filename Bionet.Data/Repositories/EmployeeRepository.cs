using Bionet.Data.Infrastructure;
using Bionet.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bionet.Data.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
    }
    public class EmployeeRepository : RepositoryBase<Employee> ,IEmployeeRepository
    {
        public EmployeeRepository(IDbFactory dbFactory) : base (dbFactory)
        {

        }
    }
}
