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
    public interface IThongTinTrungTamRepository : IRepository<ThongTinTrungTam>
    {
    }

    public class ThongTinTrungTamRepository : RepositoryBase<ThongTinTrungTam>, IThongTinTrungTamRepository
    {
        public ThongTinTrungTamRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}