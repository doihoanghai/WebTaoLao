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
    public interface IXN_KetQua_ChiTietRepository : IRepository<XN_KetQua_ChiTiet>
    {
    }

    public class XN_KetQua_ChiTietRepository : RepositoryBase<XN_KetQua_ChiTiet>, IXN_KetQua_ChiTietRepository
    {
        public XN_KetQua_ChiTietRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}