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
    public interface IMapsXN_DichVuRepository : IRepository<MapsXN_DichVu>
    {
    }

    public class MapsXN_DichVuRepository : RepositoryBase<MapsXN_DichVu>, IMapsXN_DichVuRepository
    {
        public MapsXN_DichVuRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}