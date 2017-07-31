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
    public interface IXN_TraKetQuaRepository : IRepository<XN_TraKetQua>
    {
    }

    public class XN_TraKetQuaRepository : RepositoryBase<XN_TraKetQua>, IXN_TraKetQuaRepository
    {
        public XN_TraKetQuaRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}