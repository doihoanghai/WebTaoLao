using Bionet.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bionet.Web.Models
{
    public class ChiTietGoiDichVuViewModel
    {
        public string IDGoiDichVuChung { get; set; }
        public List<DanhMucDichVu> lstDanhMucDichVu { get; set; }
    }
}