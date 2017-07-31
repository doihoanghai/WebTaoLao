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
    public interface IXN_KetQuaRepository : IRepository<XN_KetQua>
    {
    }

    public class XN_KetQuaRepository : RepositoryBase<XN_KetQua>, IXN_KetQuaRepository
    {
        public XN_KetQuaRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}