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
    public interface IXN_TraKQ_ChiTietRepository : IRepository<XN_TraKQ_ChiTiet>
    {
    }

    public class XN_TraKQ_ChiTietRepository : RepositoryBase<XN_TraKQ_ChiTiet>, IXN_TraKQ_ChiTietRepository
    {
        public XN_TraKQ_ChiTietRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}