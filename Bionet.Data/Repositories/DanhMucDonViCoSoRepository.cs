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
    public interface IDanhMucDonViCoSoRepository : IRepository<DanhMucDonViCoSo>
    {
        string GetMaTrungTamByMaDonViCS(string maDonVi);
        IEnumerable<DanhMucDonViCoSo> GetListDonViCSByMaTT(string maTT);
    }

    public class DanhMucDonViCoSoRepository : RepositoryBase<DanhMucDonViCoSo>, IDanhMucDonViCoSoRepository
    {
        public DanhMucDonViCoSoRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<DanhMucDonViCoSo> GetListDonViCSByMaTT(string maTT)
        {
            var result = (from donvi in DbContext.DanhMucDonViCoSo
                          join chicuc in DbContext.DanhMucChiCuc on donvi.MaChiCuc equals chicuc.MaChiCuc
                          where chicuc.MaTrungTam == maTT
                          select donvi);
            return result;
        }

        public string GetMaTrungTamByMaDonViCS(string maDonVi)
        {
            var result = (from donvi in DbContext.DanhMucDonViCoSo
                          join chicuc in DbContext.DanhMucChiCuc on donvi.MaChiCuc equals chicuc.MaChiCuc
                          where donvi.MaDVCS == maDonVi
                          select new { MaTrungTam = chicuc.MaTrungTam });
            return result.FirstOrDefault().MaTrungTam;
        }
    }
}