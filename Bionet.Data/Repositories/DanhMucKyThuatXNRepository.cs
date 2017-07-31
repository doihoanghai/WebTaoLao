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
    public interface IDanhMucKyThuatXNRepository : IRepository<DanhMucKyThuatXN>
    {
    }

    public class DanhMucKyThuatXNRepository : RepositoryBase<DanhMucKyThuatXN>, IDanhMucKyThuatXNRepository
    {
        public DanhMucKyThuatXNRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}